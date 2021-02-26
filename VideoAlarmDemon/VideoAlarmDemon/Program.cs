using System;
using System.Windows.Forms;
using Nwuram.Framework.Project;
using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.Connection;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace VideoAlarmDemon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Config.ProgSettngs = new Settings();

                string jsonString = File.ReadAllText(Config.PathFile + @"\settings.json");

                Config.ProgSettngs = JsonConvert.DeserializeObject<Settings>(jsonString);

                Config.hCntMain = new Procedures(Config.ProgSettngs.ServerK21, Config.ProgSettngs.DataBaseK21, Config.ProgSettngs.Login, Config.ProgSettngs.Password, "");

                Application.Run(new frmMain());

               /*
                string fileName = @"C:\Old_Disk_D\4534\text.txt";
                ParseFileAlarmVideo pa = new ParseFileAlarmVideo();
                VideoAlarmDemon.ListFile lFile = new ListFile();
                lFile.file = fileName;
                lFile.idReg = 8;
                lFile.Path = new FileInfo(fileName).Directory.FullName;                
                pa.InsertDataToDataTable(lFile, true);
                */

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"Запуск программы",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //Console.WriteLine(ex.Message);
            }
        }
    }
}
