﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoAlarmDemon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            initWatchers();
            Task.Run(() => TaskParsData());
        }

        class ListFile
        {
            public int idReg;
            public string Path;
            public string file;
        }

        ArrayList aFileWatcherInstance = new ArrayList();
        List<ListFile> listFileToAdd = new List<ListFile>();
        Dictionary<int, string> DicPathToVideoReg = new Dictionary<int, string>();
        Dictionary<string, FileSystemWatcher> DicPathToWatcher = new Dictionary<string, FileSystemWatcher>();

        DataTable dtData,dtRegChannel;
        private void GetVideoReg()
        {
            Task<DataTable> task = Config.hCntMain.GetVideoReg();
            task.Wait();
            dtData = task.Result;
            dtData.DefaultView.RowFilter = "isActive = 1";
            dtData = dtData.DefaultView.ToTable().Copy();
        }

        private void GetCameraVsChannel()
        {
            Task<DataTable> task = Config.hCntMain.GetCameraVsChannel();
            task.Wait();
            dtRegChannel = task.Result;
        }

        private void initWatchers()
        {
            GetVideoReg();
            GetCameraVsChannel();
            if (dtData == null) return;
            if (dtData.Rows.Count == 0) return;

            foreach (DataRow row in dtData.Rows)
            {
                int idVideoReg = (int)row["id"];
                string PathLog = (string)row["PathLog"];

                if (!DicPathToVideoReg.ContainsKey(idVideoReg))
                {
                    DicPathToVideoReg.Add(idVideoReg, PathLog);
                    addWatcher(PathLog);
                }
                else
                    if (!DicPathToVideoReg[idVideoReg].Equals(PathLog))
                {
                    changePathWatcher(DicPathToVideoReg[idVideoReg], PathLog);
                    DicPathToVideoReg[idVideoReg] = PathLog;
                }
            }

            List<int> delId = new List<int>();
            foreach (int idVideoReg in DicPathToVideoReg.Keys)
            {
                if (dtData.AsEnumerable().Where(r => r.Field<int>("id") == idVideoReg).Count() == 0)
                    delId.Add(idVideoReg);
            }


            foreach (int id in delId)
            {
                deleteWatcher(DicPathToVideoReg[id]);
                DicPathToVideoReg.Remove(id);
            }

        }

        private void addWatcher(string Path)
        {
            FileSystemWatcher oFileWatcher = new FileSystemWatcher();
            oFileWatcher.Path = Path;
            oFileWatcher.Filter = "*.txt";
            oFileWatcher.Created +=
                      new FileSystemEventHandler(FileSystemWatcherCreated);
            oFileWatcher.EnableRaisingEvents = true;
            DicPathToWatcher.Add(Path, oFileWatcher);
        }

        private void changePathWatcher(string oldPath, string newPath)
        {
            FileSystemWatcher oFileWatcher = DicPathToWatcher[oldPath];
            oFileWatcher.EnableRaisingEvents = false;
            oFileWatcher.Path = newPath;
            oFileWatcher.EnableRaisingEvents = true;
        }

        private void deleteWatcher(string Path)
        {
            FileSystemWatcher oFileWatcher = DicPathToWatcher[Path];
            oFileWatcher.EnableRaisingEvents = false;
            oFileWatcher.Dispose();
            DicPathToWatcher.Remove(Path);
        }

        void FileSystemWatcherCreated(object sender, FileSystemEventArgs e)
        {
            int idVideoReg = DicPathToVideoReg.FirstOrDefault(x => x.Value == ((FileSystemWatcher)sender).Path).Key;
            //A file has been deleted from the monitor directory.
            string sLog = $"File Path:{new FileInfo(e.FullPath).Directory} File Created: " + e.Name + $"  IdVideoReg:{idVideoReg}  FileSize:{new FileInfo(e.FullPath).Length}";
            

            listFileToAdd.Add(new ListFile()
            {
                idReg = idVideoReg,
                Path = new FileInfo(e.FullPath).Directory.FullName,
                file = e.FullPath
            });


            AppendText(sLog);
        }

        private delegate void AppendListHandler(string sLog);
        private void AppendText(string sLog)
        {
            if (lstResultLog.InvokeRequired)
                lstResultLog.Invoke(new AppendListHandler(AppendText),
                                    new object[] { sLog });
            else
                lstResultLog.Items.Add(Convert.ToString(DateTime.Now) +
                                       " - " + sLog);
        }

        private void AppendTextToLog(string sLog)
        {
            if (lstResultBody.InvokeRequired)
                lstResultBody.Invoke(new AppendListHandler(AppendTextToLog),
                                    new object[] { sLog });
            else
                lstResultBody.Items.Add(Convert.ToString(DateTime.Now) +
                                       " - " + sLog);
        }

        private DateTime StartTime;
        private async void TaskParsData()
        {
            StartTime = DateTime.Now;
            while (true)
            {
                while (listFileToAdd.Count > 0)
                {
                    ListFile lFile = listFileToAdd.FirstOrDefault();
                    InsertDataToDataTable(lFile);
                    listFileToAdd.Remove(lFile);
                }

                if ((DateTime.Now - StartTime).TotalMinutes >= 5)
                {
                    StartTime = DateTime.Now;
                    initWatchers();
                }

                Thread.Sleep(TimeSpan.FromSeconds(10));
            }        
        }

        private void InsertDataToDataTable(ListFile lFile)
        {
            string path = lFile.Path;
            string file = lFile.file;

            DataTable dtAlarm = new DataTable();
            dtAlarm.Columns.Add("id_VideoReg", typeof(int));
            dtAlarm.Columns.Add("TypeEvent", typeof(string));
            dtAlarm.Columns.Add("idChannel", typeof(int));
            dtAlarm.Columns.Add("Channel", typeof(int));
            dtAlarm.Columns.Add("DateEvent", typeof(DateTime));
            dtAlarm.Columns.Add("isStartTime", typeof(bool));
            dtAlarm.AcceptChanges();


            dtAlarm.Clear();
            try
            {
                if (!File.Exists(file)) return;

                using (StreamReader sr = new StreamReader(file, Encoding.Default))
                {
                    string line;
                    string TypeEvent = null;
                    int? Channel = null;
                    DateTime? DateEvent = null;
                    bool isStartTime = true;
                    bool FindData = false;

                    while ((line = sr.ReadLine()) != null)
                    {

                        Int64 tmpInt64;
                        if (Int64.TryParse(line, out tmpInt64)) { FindData = true; }
                        if (FindData && line.StartsWith("Тип события")) { TypeEvent = line.Replace("Тип события:", "").Trim(); }
                        if (FindData && line.StartsWith("Канал")) { Channel = int.Parse(line.Replace("Канал:", "").Trim()); }
                        if (FindData && line.StartsWith("Начало")) { DateEvent = DateTime.Parse(line.Replace("Начало:", "").Trim()); isStartTime = true; }

                        if (FindData && line.StartsWith("Завершение")) { DateEvent = DateTime.Parse(line.Replace("Завершение:", "").Trim()); isStartTime = false; }

                        if (line.Trim().Length == 0)
                        {
                            if (FindData && TypeEvent != null && Channel != null && DateEvent != null)
                            {
                                int? idChannel = null;
                                try
                                {
                                    EnumerableRowCollection<DataRow> rowCollect = dtRegChannel.AsEnumerable().Where(r => r.Field<string>("RegChannel").Equals(Channel.ToString()));
                                    if (rowCollect.Count() > 0)
                                        idChannel = (int)rowCollect.FirstOrDefault()["id"];
                                }
                                catch { }

                                AppendTextToLog($"Тип события:{TypeEvent}  Канал:{Channel}  Время:{DateEvent}  Начало:{(isStartTime ? "Да" : "Нет")}");
                                dtAlarm.Rows.Add(lFile.idReg, TypeEvent, idChannel,Channel, DateEvent, isStartTime);
                            }
                            TypeEvent = null;
                            Channel = null;
                            DateEvent = null;
                            FindData = false;
                        }
                    }
                }

                //dtAlarm.DefaultView.RowFilter = "idChannel is not null";
                dtAlarm.DefaultView.Sort = "Channel asc,DateEvent asc";
                dtAlarm = dtAlarm.DefaultView.ToTable().Copy();

                Task<DataTable> taskResp = Config.hCntMain.GetResponsibleInWork();
                taskResp.Wait();

                Task task;
               string id_Responsible = "";
                if (taskResp.Result != null && taskResp.Result.Rows.Count > 0) id_Responsible = (string)taskResp.Result.Rows[0]["listIdResponsible"];

                foreach (DataRowView row in dtAlarm.DefaultView)
                {
                    int id_VideoReg = (int)row["id_VideoReg"];
                    int? id_Camera_vs_Channel = null; if (row["idChannel"] != DBNull.Value) id_Camera_vs_Channel = (int?)row["idChannel"];
                    string TypeEvent = (string)row["TypeEvent"];
                    DateTime? DateStartAlarm = null;
                    DateTime? DateEndAlarm = null;
                    int Channel = (int)row["Channel"];


                    if ((bool)row["isStartTime"]) DateStartAlarm = (DateTime?)row["DateEvent"]; else DateEndAlarm = (DateTime?)row["DateEvent"];

                    task = Config.hCntMain.SetAlarmVideoReg(id_VideoReg, id_Camera_vs_Channel, TypeEvent, id_Responsible, DateStartAlarm, DateEndAlarm, Channel);
                    task.Wait();

                }

                int delta = 0;
                Task<DataTable> taskTable = Config.hCntMain.getSettings("dlsc");
                taskTable.Wait();
                if (taskTable.Result != null && taskTable.Result.Rows.Count > 0 && taskTable.Result.Rows[0]["value"] != null)
                {
                    decimal valueDec;
                    if (decimal.TryParse(taskTable.Result.Rows[0]["value"].ToString(), out valueDec))
                    {
                        delta = decimal.ToInt32(valueDec);
                    }
                }

                FileInfo fInfo = new FileInfo(file);

                task = Config.hCntMain.SetTAlarmVideoReg(lFile.idReg, fInfo.Name, delta, id_Responsible);
                task.Wait();

                if (!Directory.Exists(path + @"\End")) Directory.CreateDirectory(path + @"\End");
                if (File.Exists(path + @"\End\" + fInfo.Name)) File.Delete(path + @"\End\" + fInfo.Name);
                File.Move(file, path + @"\End\" + fInfo.Name);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        

    }
}
