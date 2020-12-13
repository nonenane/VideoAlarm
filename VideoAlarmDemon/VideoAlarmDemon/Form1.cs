using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoAlarmDemon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private List<Watcher> listWatcher = new List<Watcher>();
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Watcher w = new Watcher(@"D:\WatchPath");
            w.CurEvents += ShowStr;
            listWatcher.Add(w);
            w = new Watcher(@"D:\WatchPath4");
            w.CurEvents += ShowStr;
            listWatcher.Add(w);                        
            */

            DataTable dtAlarm = new DataTable();
            dtAlarm.Columns.Add("TypeEvent", typeof(string));
            dtAlarm.Columns.Add("Channel", typeof(int));
            dtAlarm.Columns.Add("DateEvent", typeof(DateTime));
            dtAlarm.Columns.Add("isStartTime", typeof(bool));
            dtAlarm.AcceptChanges();


            using (StreamReader sr = new StreamReader(@"D:\WatchPath\text.txt", System.Text.Encoding.Default))
            {
                string line;
                string TypeEvent = null;
                int? Channel = null;
                DateTime? DateEvent = null;
                bool isStartTime = true;
                bool FindData = false;

                //while ((line = await sr.ReadLineAsync()) != null)
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
                            Console.WriteLine($"Тип события:{TypeEvent}  Канал:{Channel}  Время:{DateEvent}  Начало:{(isStartTime ? "Да" : "Нет")}");
                            dtAlarm.Rows.Add(TypeEvent,Channel, DateEvent, isStartTime);
                        }
                        TypeEvent = null;
                        Channel = null;
                        DateEvent = null;
                        FindData = false;
                    }                   
                }
            }
            dtAlarm.DefaultView.Sort = "Channel asc,TypeEvent asc,DateEvent asc";
        }

        private void ShowStr(string st)
        {
            Console.WriteLine(st);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var w in listWatcher)
            {
                w.WatcherStartStop(!w.getStatus());
                w.Dispose();                
            }
        }
    }
}
