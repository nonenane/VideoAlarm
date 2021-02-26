using Nwuram.Framework.Settings.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAlarmDemon
{
    public partial class ParseFileAlarmVideo
    {
        //public bool isStartApp = false;
        //public delegate void AppendTextToLog(string sLog);
        //public event AppendTextToLog Notify;

        private DataTable dtRegChannel;
        public ParseFileAlarmVideo()
        {
            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            if (Config.ProgSettngs == null)
            {
                Config.ProgSettngs = new Settings();
                Config.ProgSettngs.IdProg = Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram().ToString();
                Config.idUser = Nwuram.Framework.Settings.User.UserSettings.User.Id;
            }



            Task<DataTable> task = Config.hCntMain.GetCameraVsChannel();
            task.Wait();
            dtRegChannel = task.Result;
        }

        public ParseFileAlarmVideo(DataTable dtRegChannel)
        {
            this.dtRegChannel = dtRegChannel;
            if (dtRegChannel == null)
            {
                Task<DataTable> task = Config.hCntMain.GetCameraVsChannel();
                task.Wait();
                this.dtRegChannel = task.Result;
            }
        }

        public void InsertDataToDataTable(ListFile lFile,bool isStartApp)
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
                Task<DataTable> taskTable = Config.hCntMain.getSettings("dlmn");
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

                        DateTime? tmpTime = null, tmpTimeOff = null;
                        string tmpTypeName = "";

                        while ((line = sr.ReadLine()) != null)
                        {
                            Int64 tmpInt64;
                            if (Int64.TryParse(line, out tmpInt64)) { FindData = true; }
                            if (FindData && line.StartsWith("Тип события")) { TypeEvent = line.Replace("Тип события:", "").Trim(); }
                            if (FindData && line.StartsWith("Канал")) { Channel = int.Parse(line.Replace("Канал:", "").Trim()); }
                            if (FindData && line.StartsWith("Начало")) { DateEvent = myParserTime.parseTime(line.Replace("Начало:", "").Trim()); isStartTime = true; }

                            if (FindData && line.StartsWith("Завершение")) { DateEvent = myParserTime.parseTime(line.Replace("Завершение:", "").Trim()); isStartTime = false; }
                            if (FindData && line.StartsWith("Окончание")) { DateEvent = myParserTime.parseTime(line.Replace("Окончание:", "").Trim()); isStartTime = false; }


                            if (FindData && line.StartsWith("Время:")) { 
                                tmpTime = DateTime.Parse(line.Replace("Время:", "").Trim()); }
                            if (FindData && line.StartsWith("Время выключения:")) { tmpTimeOff = myParserTime.parseTime(line.Replace("Время выключения:", "").Trim()); }
                            if (FindData && line.StartsWith("Типы:")) { tmpTypeName = line.Replace("Типы:", "").Trim(); }


                            if (FindData && line.StartsWith("Тип:")) { tmpTypeName = line.Replace("Тип:", "").Trim(); }


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

                                    //AppendTextToLog($"Тип события:{TypeEvent}  Канал:{Channel}  Время:{DateEvent}  Начало:{(isStartTime ? "Да" : "Нет")}");
                                    dtAlarm.Rows.Add(lFile.idReg, TypeEvent, idChannel, Channel, DateEvent, isStartTime);
                                }

                                if (FindData && new List<string>() { "Выключение", "Перезагрузка" }.Contains(tmpTypeName))
                                {
                                    Channel = null;
                                    int? idChannel = null;

                                    if (tmpTypeName.Equals("Перезагрузка"))
                                    {
                                        isStartTime = true;
                                        DateEvent = tmpTime;
                                        TypeEvent = "Перезагрузка";
                                        dtAlarm.Rows.Add(lFile.idReg, TypeEvent, idChannel, Channel, DateEvent, isStartTime);
                                        dtAlarm.Rows.Add(lFile.idReg, TypeEvent, idChannel, Channel, DateEvent, !isStartTime);
                                    }
                                    else
                                    if (tmpTypeName.Equals("Выключение"))
                                    {
                                        isStartTime = false;
                                        DateEvent = tmpTime;
                                        TypeEvent = "Выключение";
                                        dtAlarm.Rows.Add(lFile.idReg, TypeEvent, idChannel, Channel, DateEvent, isStartTime);
                                        DateEvent = tmpTimeOff;
                                        dtAlarm.Rows.Add(lFile.idReg, TypeEvent, idChannel, Channel, DateEvent, !isStartTime);
                                    }                                                                    
                                }

                                if (FindData && new List<string>() { "Загрузка" }.Contains(tmpTypeName))
                                {
                                    Channel = null;
                                    int? idChannel = null;
                                    DateEvent = tmpTime;
                                    TypeEvent = "Загрузка";
                                    dtAlarm.Rows.Add(lFile.idReg, TypeEvent, idChannel, Channel, DateEvent, true);
                                    dtAlarm.Rows.Add(lFile.idReg, TypeEvent, idChannel, Channel, DateEvent, false);
                                }


                                TypeEvent = null;
                                Channel = null;
                                DateEvent = null;
                                FindData = false;
                            }
                        }
                    }

                    dtAlarm.DefaultView.Sort = "Channel asc, TypeEvent asc, DateEvent asc";
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
                        int? Channel = null; if (row["Channel"] != DBNull.Value) Channel = (int?)row["Channel"];

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



                    task = Config.hCntMain.SetTAlarmVideoReg(lFile.idReg, fInfo.Name, delta, id_Responsible, id_Schedule);
                    task.Wait();
                }
                else
                {
                    //AppendText($"Файл:\"{file}\". Не уложились в расписание");
                }


                if (!Directory.Exists(path + @"\End")) Directory.CreateDirectory(path + @"\End");
                
                string pathTo = path + @"\End\" + Path.GetFileNameWithoutExtension(fInfo.Name) + $" {DateTime.Now.ToShortDateString().Replace(".","-")} {DateTime.Now.ToLongTimeString().Replace(":", "-")}.txt";
                if (File.Exists(pathTo)) File.Delete(pathTo);
                //File.Move(file, path + @"\End\" + Path.GetFileNameWithoutExtension(fInfo.Name) + $" {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}.txt");
                File.Move(file, pathTo);

            }
            catch (Exception ex)
            {
                //AppendTextToLog($"Ошибка: \"{ex.Message}\"");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
