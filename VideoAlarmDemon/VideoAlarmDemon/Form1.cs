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

            using (StreamReader sr = new StreamReader(@"D:\WatchPath\text.txt", System.Text.Encoding.Default))
            {
                string line;
                //while ((line = await sr.ReadLineAsync()) != null)
                while ((line = sr.ReadLine()) != null)
                {
                    
                    Int64 tmpInt64;
                    if (Int64.TryParse(line, out tmpInt64)) { Console.WriteLine(line); }
                }
            }

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
