using System.Collections;
using Nwuram.Framework.Data;
using System.Data;
using System;
using System.Threading.Tasks;
using System.Linq;



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

        public async Task SetAlarmVideoReg(int id_VideoReg,int? id_Camera_vs_Channel,string TypeEvent,string id_Responsible,DateTime? DateStartAlarm,DateTime? DateEndAlarm,int Channel, int id_Schedule)
        {
            ap.Clear();

            ap.Add(id_VideoReg);
            ap.Add(id_Camera_vs_Channel);
            ap.Add(TypeEvent);
            ap.Add(id_Responsible);
            ap.Add(DateStartAlarm);
            ap.Add(DateEndAlarm);
            ap.Add(Channel);
            ap.Add(id_Schedule);

           executeProcedure("[CheckVideoReg].[SetAlarmVideoReg]",
                 new string[8] { "@id_VideoReg", "@id_Camera_vs_Channel", "@TypeEvent", "@id_Responsible", "@DateStartAlarm", "@DateEndAlarm", "@Channel","@id_Schedule" },
                 new DbType[8] { DbType.Int32, DbType.Int32, DbType.String, DbType.String, DbType.DateTime, DbType.DateTime, DbType.String,DbType.Int32 }, ap);
        }

        public async Task<DataTable> GetResponsibleInWork()
        {
            ap.Clear();

            return executeProcedure("[CheckVideoReg].[GetResponsibleInWork]",
                  new string[0] { },
                  new DbType[0] { }, ap);
        }

        public async Task SetTAlarmVideoReg(int id_VideoReg, string NameFile, int Delta , string id_Responsible, int id_Schedule)
        {
            ap.Clear();

            ap.Add(id_VideoReg);
            ap.Add(NameFile);
            ap.Add(Delta);
            ap.Add(id_Responsible);
            ap.Add(id_Schedule);

            executeProcedure("[CheckVideoReg].[SetTAlarmVideoReg]",
                  new string[5] { "@id_VideoReg", "@NameFile","@Delta", "@id_Responsible","@id_Schedule"},
                  new DbType[5] { DbType.Int32, DbType.String,DbType.Int32, DbType.String,DbType.Int32}, ap);
        }

        public async Task<DataTable> getSettings(string id_value)
        {
            ap.Clear();
            ap.Add(Config.ProgSettngs.IdProg);
            ap.Add(id_value);

            DataTable dtResult = executeProcedure("[CheckVideoReg].[getSettings]",
                 new string[2] { "@id_prog", "@id_value" },
                 new DbType[2] { DbType.Int32, DbType.String }, ap);

            return dtResult;
        }

        public async Task<int?> GetSchedule(int delta,bool isStartApp)
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[CheckVideoReg].[GetSchedule]",
                 new string[0] { },
                 new DbType[0] { }, ap);


            dtResult.DefaultView.RowFilter = "isOn = 1";            
            dtResult = dtResult.DefaultView.ToTable().Copy();
            EnumerableRowCollection<DataRow> rowCollect;
            if(isStartApp)
                rowCollect = dtResult.AsEnumerable().Where(r => r.Field<TimeSpan>("TimeRun")<= r.Field<DateTime>("timeNow").TimeOfDay);
            else
                rowCollect = dtResult.AsEnumerable().Where(r => r.Field<DateTime>("timeNow").AddMinutes(-delta).TimeOfDay <= r.Field<TimeSpan>("TimeRun") && r.Field<TimeSpan>("TimeRun") <= r.Field<DateTime>("timeNow").AddMinutes(delta).TimeOfDay);

            if (rowCollect.Count() > 0)
                return (int)rowCollect.Last()["id"];
            else
                return null;
        }

    }
}
