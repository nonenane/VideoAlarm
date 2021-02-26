using Nwuram.Framework.Settings.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoAlarmDemon
{
    class Config
    {
        public static readonly string PathFile = Application.StartupPath;

        public static Procedures hCntMain { get; set; } //осн. коннект
        public static Settings ProgSettngs;
        public static int? idUser = null;
    }

    public class Settings
    {
        public string IdProg { set; get; }
        public string Login { set; get; }

        public string Password { set; get; }

        public string ServerK21 { set; get; }

        public string DataBaseK21 { set; get; }
    }

    public class myParserTime
    {
        public static DateTime parseTime(string str)
        {
            string strTime = str;
            if (strTime.IndexOf(" ") == 8 && strTime.Contains("-"))
            {
                strTime = $"{DateTime.Now.Year.ToString().Substring(0, 2)}{strTime}";
            }

            //return DateTime.ParseExact(str, "yyyy-MM-dd mm:HH:ss", System.Globalization.CultureInfo.InvariantCulture);

            return DateTime.Parse(strTime);
        }
    }
}
