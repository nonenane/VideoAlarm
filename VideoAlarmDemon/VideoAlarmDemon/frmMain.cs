using System;
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
    public partial class frmMain : Form
    {
        private bool isStartApp = true;
        public frmMain()
        {
            InitializeComponent();

            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);

            initWatchers();
            FindFilesOnPath();
            isStartApp = false;


            Task.Run(() => TaskParsData());
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // проверяем наше окно, и если оно было свернуто, делаем событие        
            if (WindowState == FormWindowState.Minimized)
            {
                // прячем наше окно из панели
                this.ShowInTaskbar = false;
                // делаем нашу иконку в трее активной
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                // делаем нашу иконку скрытой
                notifyIcon1.Visible = true;
                // возвращаем отображение окна в панели
                this.ShowInTaskbar = true;
                //разворачиваем окно
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                // прячем наше окно из панели
                this.ShowInTaskbar = false;
                // делаем нашу иконку в трее активной
                notifyIcon1.Visible = true;
            }
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

        DataTable dtData, dtRegChannel;
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

            ClearListBox();

            foreach (DataRow row in dtData.Rows)
            {
                int idVideoReg = (int)row["id"];
                string PathLog = (string)row["PathLog"];
                string RegName = (string)row["RegName"];

                string[] StringArray = { RegName, PathLog };
                var listViewItem = new ListViewItem(StringArray);
                AddItemToListBox(listViewItem);


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

        private void FindFilesOnPath()
        {
            foreach (string path in DicPathToVideoReg.Values)
            {
                if (Directory.Exists(path))
                {
                    string[] files = Directory.GetFiles(path, "*.txt");
                    foreach (string file in files)
                    {
                        int idVideoReg = DicPathToVideoReg.FirstOrDefault(x => x.Value == path).Key;

                        ListFile lFile = new ListFile();
                        lFile.idReg = idVideoReg;
                        lFile.Path = path;
                        lFile.file = file;

                        InsertDataToDataTable(lFile);

                    }
                }
            }
        }

        private void addWatcher(string Path)
        {
            try
            {
                FileSystemWatcher oFileWatcher = new FileSystemWatcher();
                oFileWatcher.Path = Path;
                oFileWatcher.Filter = "*.txt";
                oFileWatcher.Created +=
                          new FileSystemEventHandler(FileSystemWatcherCreated);
                oFileWatcher.EnableRaisingEvents = true;
                DicPathToWatcher.Add(Path, oFileWatcher);
            }
            catch
            {

            }
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
                lstResultBody.Items.Add(Convert.ToString(DateTime.Now) +
                                       " - " + sLog);
        }

        private void AppendTextToLog(string sLog)
        {
            if (lstResultBody.InvokeRequired)
                lstResultBody.Invoke(new AppendListHandler(AppendTextToLog),
                                    new object[] { sLog });
            else
            {
                if (lstResultBody.Items.Count > 1000)
                    lstResultBody.Items.Clear();
                lstResultBody.Items.Add(Convert.ToString(DateTime.Now) +
                                       " - " + sLog);
            }
        }

        private delegate void AddItemToListBoxHandler(ListViewItem listViewItem);
        private void AddItemToListBox(ListViewItem listViewItem)
        {
            if (listView1.InvokeRequired)
                listView1.Invoke(new AddItemToListBoxHandler(AddItemToListBox),
                                    new object[] { listViewItem });
            else
                listView1.Items.Add(listViewItem);
        }

        private delegate void ClearListBoxHandler();

        private void ClearListBox()
        {
            if (listView1.InvokeRequired)
                listView1.Invoke(new ClearListBoxHandler(ClearListBox));
            else
                listView1.Items.Clear();
        }

        private DateTime StartTime, TimeSearchFile;
        private async void TaskParsData()
        {
            StartTime = DateTime.Now;
            TimeSearchFile = DateTime.Now;
            while (true)
            {
                while (listFileToAdd.Count > 0)
                {
                    ListFile lFile = listFileToAdd.FirstOrDefault();
                    InsertDataToDataTable(lFile);
                    listFileToAdd.Remove(lFile);
                }

                if ((DateTime.Now - TimeSearchFile).TotalMinutes >= 5)
                {
                    TimeSearchFile = DateTime.Now;
                    FindFilesOnPath();
                }


                if ((DateTime.Now - StartTime).TotalMinutes >= 30)
                {
                    StartTime = DateTime.Now;
                    initWatchers();
                }

                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = DialogResult.No == MessageBox.Show("Закрыть программу?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void свернутьРазвернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(null, null);
        }

        private void btUpdatePath_Click(object sender, EventArgs e)
        {
            initWatchers();
        }

        private void InsertDataToDataTable(ListFile lFile)
        {
            string path = lFile.Path;
            string file = lFile.file;
            FileInfo fInfo = new FileInfo(file);

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

                Task<int?> taskInt = Config.hCntMain.GetSchedule(delta, isStartApp);
                taskInt.Wait();

                if (taskInt.Result != null)
                {

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
                                        EnumerableRowCollection<DataRow> rowCollect = dtRegChannel.AsEnumerable().Where(r => r.Field<string>("RegChannel").Equals(Channel.ToString()) && r.Field<int>("id_VideoReg") == lFile.idReg);
                                        if (rowCollect.Count() > 0)
                                            idChannel = (int)rowCollect.FirstOrDefault()["id"];
                                    }
                                    catch { }

                                    AppendTextToLog($"Тип события:{TypeEvent}  Канал:{Channel}  Время:{DateEvent}  Начало:{(isStartTime ? "Да" : "Нет")}");
                                    dtAlarm.Rows.Add(lFile.idReg, TypeEvent, idChannel, Channel, DateEvent, isStartTime);
                                }
                                TypeEvent = null;
                                Channel = null;
                                DateEvent = null;
                                FindData = false;
                            }
                        }
                    }

                    dtAlarm.DefaultView.Sort = "Channel asc,DateEvent asc";
                    dtAlarm = dtAlarm.DefaultView.ToTable().Copy();

                    Task<DataTable> taskResp = Config.hCntMain.GetResponsibleInWork();
                    taskResp.Wait();

                    Task task;
                    string id_Responsible = "";
                    if (taskResp.Result != null && taskResp.Result.Rows.Count > 0) id_Responsible = (string)taskResp.Result.Rows[0]["listIdResponsible"];

                    int id_Schedule = (int)taskInt.Result;

                    foreach (DataRowView row in dtAlarm.DefaultView)
                    {
                        int id_VideoReg = (int)row["id_VideoReg"];
                        int? id_Camera_vs_Channel = null; if (row["idChannel"] != DBNull.Value) id_Camera_vs_Channel = (int?)row["idChannel"];
                        string TypeEvent = (string)row["TypeEvent"];
                        DateTime? DateStartAlarm = null;
                        DateTime? DateEndAlarm = null;
                        int Channel = (int)row["Channel"];


                        if ((bool)row["isStartTime"]) DateStartAlarm = (DateTime?)row["DateEvent"]; else DateEndAlarm = (DateTime?)row["DateEvent"];

                        task = Config.hCntMain.SetAlarmVideoReg(id_VideoReg, id_Camera_vs_Channel, TypeEvent, id_Responsible, DateStartAlarm, DateEndAlarm, Channel, id_Schedule);
                        task.Wait();

                    }

                    //int delta = 0;
                    //Task<DataTable> taskTable = Config.hCntMain.getSettings("dlsc");
                    //taskTable.Wait();
                    //if (taskTable.Result != null && taskTable.Result.Rows.Count > 0 && taskTable.Result.Rows[0]["value"] != null)
                    //{
                    //    decimal valueDec;
                    //    if (decimal.TryParse(taskTable.Result.Rows[0]["value"].ToString(), out valueDec))
                    //    {
                    //        delta = decimal.ToInt32(valueDec);
                    //    }
                    //}

                    

                    task = Config.hCntMain.SetTAlarmVideoReg(lFile.idReg, fInfo.Name, delta, id_Responsible,id_Schedule);
                    task.Wait();
                }


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
