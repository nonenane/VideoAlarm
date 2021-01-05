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

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"Запуск программы",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //Console.WriteLine(ex.Message);
            }
        }
    }
}
