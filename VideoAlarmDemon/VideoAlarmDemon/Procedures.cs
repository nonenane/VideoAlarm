using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;
using System.Threading.Tasks;
using System.Threading;

namespace VideoAlarmDemon
{
    class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
              : base(server, database, username, password, appName)
        {
        }
        ArrayList ap = new ArrayList();

        public async Task<DataTable> GetVideoReg()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[CheckVideoReg].[GetVideoReg]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        public async Task<DataTable> GetCameraVsChannel()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[CheckVideoReg].[GetCameraVsChannel]",
                 new string[0] { },
                 new DbType[0] { }, ap);


            dtResult.DefaultView.RowFilter = "isActive = 1";
            dtResult.DefaultView.Sort = "RegName asc";
            dtResult = dtResult.DefaultView.ToTable().Copy();

            return dtResult;
        }

        public async Task SetAlarmVideoReg(int id_VideoReg,int? id_Camera_vs_Channel,string TypeEvent,string id_Responsible,DateTime? DateStartAlarm,DateTime? DateEndAlarm,int Channel)
        {
            ap.Clear();

            ap.Add(id_VideoReg);
            ap.Add(id_Camera_vs_Channel);
            ap.Add(TypeEvent);
            ap.Add(id_Responsible);
            ap.Add(DateStartAlarm);
            ap.Add(DateEndAlarm);
            ap.Add(Channel);

           executeProcedure("[CheckVideoReg].[SetAlarmVideoReg]",
                 new string[7] { "@id_VideoReg", "@id_Camera_vs_Channel", "@TypeEvent", "@id_Responsible", "@DateStartAlarm", "@DateEndAlarm", "@Channel" },
                 new DbType[7] { DbType.Int32, DbType.Int32, DbType.String, DbType.String, DbType.DateTime, DbType.DateTime, DbType.String }, ap);
        }

        public async Task<DataTable> GetResponsibleInWork()
        {
            ap.Clear();

            return executeProcedure("[CheckVideoReg].[GetResponsibleInWork]",
                  new string[0] { },
                  new DbType[0] { }, ap);
        }

        public async Task SetTAlarmVideoReg(int id_VideoReg, string NameFile, int Delta , string id_Responsible)
        {
            ap.Clear();

            ap.Add(id_VideoReg);
            ap.Add(NameFile);
            ap.Add(Delta);
            ap.Add(id_Responsible);

            executeProcedure("[CheckVideoReg].[SetTAlarmVideoReg]",
                  new string[4] { "@id_VideoReg", "@NameFile","@Delta", "@id_Responsible"},
                  new DbType[4] { DbType.Int32, DbType.String,DbType.Int32, DbType.String}, ap);
        }

        public async Task<DataTable> getSettings(string id_value)
        {
            ap.Clear();
            ap.Add(ConnectionSettings.GetIdProgram());
            ap.Add(id_value);

            DataTable dtResult = executeProcedure("[CheckVideoReg].[getSettings]",
                 new string[2] { "@id_prog", "@id_value" },
                 new DbType[2] { DbType.Int32, DbType.String }, ap);

            return dtResult;
        }

    }
}
