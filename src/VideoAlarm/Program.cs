﻿using System;
using System.Windows.Forms;
using Nwuram.Framework.Project;
using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.Connection;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;

namespace VideoAlarm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length != 0)
                if (Project.FillSettings(args))
                {
                    Logging.Init(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
                    Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
                  
                    Logging.StartFirstLevel(1);
                    Logging.Comment("Вход в программу");
                    Logging.StopFirstLevel();

                    //if (new List<string>(new string[] { "ркв", "кд", "пр" }).Contains(Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower()))
                    //{

                        //Application.Run(new OnlineStoreViewOrders.statisticOrder.frmStatistic());
                        Application.Run(new frmMain());
                        //Application.Run(new dictonaryCategory.frmListCategory());
                        //Application.Run(new dictonatyTovar.frmAddTovar());
                    //}
                    Logging.StartFirstLevel(2);
                    Logging.Comment("Выход из программы");
                    Logging.StopFirstLevel();

                    Project.clearBufferFiles();
                }
        }
    }
}
