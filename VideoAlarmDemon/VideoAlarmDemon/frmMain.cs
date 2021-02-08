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
        private ArrayList aFileWatcherInstance = new ArrayList();
        private List<ListFile> listFileToAdd = new List<ListFile>();
        private Dictionary<int, string> DicPathToVideoReg = new Dictionary<int, string>();
        private Dictionary<string, FileSystemWatcher> DicPathToWatcher = new Dictionary<string, FileSystemWatcher>();
        private DataTable dtData, dtRegChannel;
        private DateTime StartTime, TimeSearchFile, TimeViewResponsible;
        private ParseFileAlarmVideo pFAV;
        public frmMain()
        {
            InitializeComponent();

            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);

            initWatchers();
            FindFilesOnPath();
            isStartApp = false;
            Task<DataTable> taskResp = Config.hCntMain.SetViewNotFileAlarm();
            taskResp.Wait();

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
            pFAV = new ParseFileAlarmVideo(dtRegChannel);
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

                        pFAV.InsertDataToDataTable(lFile,isStartApp);

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
            try
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
            catch
            {
                AppendText("Что-то сломалось, плак плак!");
            }
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

        //private void AppendTextToLog(string sLog)
        //{
        //    if (lstResultBody.InvokeRequired)
        //        lstResultBody.Invoke(new AppendListHandler(AppendTextToLog),
        //                            new object[] { sLog });
        //    else
        //    {
        //        if (lstResultBody.Items.Count > 1000)
        //            lstResultBody.Items.Clear();
        //        lstResultBody.Items.Add(Convert.ToString(DateTime.Now) +
        //                               " - " + sLog);
        //    }
        //}

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
       
        private async void TaskParsData()
        {
            StartTime = DateTime.Now;
            TimeSearchFile = DateTime.Now;
            TimeViewResponsible = DateTime.Now;
            while (true)
            {
                while (listFileToAdd.Count > 0)
                {
                    ListFile lFile = listFileToAdd.FirstOrDefault();
                    pFAV.InsertDataToDataTable(lFile, isStartApp);
                    listFileToAdd.Remove(lFile);
                }

                if ((DateTime.Now - TimeSearchFile).TotalMinutes >= 5)
                {
                    TimeSearchFile = DateTime.Now;
                    FindFilesOnPath();
                }


                if ((DateTime.Now - TimeViewResponsible).TotalMinutes >= 10)
                {
                    TimeViewResponsible = DateTime.Now;
                    Task<DataTable> taskResp = Config.hCntMain.SetViewNotFileAlarm();
                    taskResp.Wait();
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

    }
}
