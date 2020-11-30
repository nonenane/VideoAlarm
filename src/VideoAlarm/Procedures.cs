using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;
using System.Threading.Tasks;
using System.Threading;


namespace VideoAlarm
{
    class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
              : base(server, database, username, password, appName)
        {
        }
        ArrayList ap = new ArrayList();

        #region "Видео регистратор"
        public async Task<DataTable> GetVideoReg()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[CheckVideoReg].[GetVideoReg]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        public async Task<DataTable> SetVideoReg(int id, string RegName, string RegIP, string Place, string PathLog, string Comment, bool isActive,int result,bool isDel)
        {
            ap.Clear();

            ap.Add(id);
            ap.Add(RegName);
            ap.Add(RegIP);
            ap.Add(Place);
            ap.Add(PathLog);
            ap.Add(Comment);
            ap.Add(isActive);
            ap.Add(UserSettings.User.Id);
            ap.Add(result);
            ap.Add(isDel);

            DataTable dtResult = executeProcedure("[CheckVideoReg].[SetVideoReg]",
                 new string[10] {"@id", "@RegName", "@RegIP", "@Place", "@PathLog", "@Comment", "@isActive", "@id_user", "@result", "@isDel" },
                 new DbType[10] {DbType.Int32,DbType.String, DbType.String, DbType.String, DbType.String, DbType.String,DbType.Boolean,DbType.Int32,DbType.Int32,DbType.Boolean }, ap);

            return dtResult;
        }

        #endregion

        #region "Ответственные"

        public async Task<DataTable> GetDepartments(bool withAllDeps = false)
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[CheckVideoReg].[GetDepartments]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            if (withAllDeps)
            {
                if (dtResult != null)
                {
                    if (!dtResult.Columns.Contains("isMain"))
                    {
                        DataColumn col = new DataColumn("isMain", typeof(int));
                        col.DefaultValue = 1;
                        dtResult.Columns.Add(col);
                        dtResult.AcceptChanges();
                    }

                    DataRow row = dtResult.NewRow();

                    row["cName"] = "Все Отделы";
                    row["id"] = 0;
                    row["isMain"] = 0;
                    dtResult.Rows.Add(row);
                    dtResult.AcceptChanges();
                    dtResult.DefaultView.Sort = "isMain asc, cName asc";
                    dtResult = dtResult.DefaultView.ToTable().Copy();
                }
            }
            else
            {
                dtResult.DefaultView.Sort = "cName asc";
                dtResult = dtResult.DefaultView.ToTable().Copy();
            }

            return dtResult;
        }

        public async Task<DataTable> GetResponsible()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[CheckVideoReg].[GetResponsible]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        public async Task<DataTable> SetResponsible(int id, int id_kadr, bool isActive, int result, bool isDel)
        {
            ap.Clear();

            ap.Add(id);
            ap.Add(id_kadr);
            ap.Add(isActive);
            ap.Add(UserSettings.User.Id);
            ap.Add(result);
            ap.Add(isDel);

            DataTable dtResult = executeProcedure("[CheckVideoReg].[SetResponsible]",
                 new string[6] { "@id", "@id_kadr", "@isActive", "@id_user", "@result", "@isDel" },
                 new DbType[6] { DbType.Int32, DbType.Int32, DbType.Boolean, DbType.Int32, DbType.Int32, DbType.Boolean }, ap);

            return dtResult;
        }

        public async Task<DataTable> GetListKadr()
        {
            ap.Clear();
            ap.Add(ConnectionSettings.GetIdProgram());

            DataTable dtResult = executeProcedure("[CheckVideoReg].[GetListKadr]",
                 new string[1] { "@id_prog" },
                 new DbType[1] {DbType.Int32 }, ap);

            return dtResult;
        }

        #endregion

        #region "Справочник каналов видеорегистраторов"

        public async Task<DataTable> GetVideoRegList(bool withAllDeps = false)
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[CheckVideoReg].[GetVideoReg]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            if (withAllDeps)
            {
                if (dtResult != null)
                {
                    if (!dtResult.Columns.Contains("isMain"))
                    {
                        DataColumn col = new DataColumn("isMain", typeof(int));
                        col.DefaultValue = 1;
                        dtResult.Columns.Add(col);
                        dtResult.AcceptChanges();
                    }

                    DataRow row = dtResult.NewRow();

                    row["RegName"] = "Все";
                    row["id"] = 0;
                    row["isMain"] = 0;
                    row["isActive"] = 1;
                    dtResult.Rows.Add(row);
                    dtResult.AcceptChanges();
                    dtResult.DefaultView.RowFilter = "isActive = 1";
                    dtResult.DefaultView.Sort = "isMain asc, RegName asc";
                    dtResult = dtResult.DefaultView.ToTable().Copy();
                }
            }
            else
            {
                dtResult.DefaultView.RowFilter = "isActive = 1";
                dtResult.DefaultView.Sort = "RegName asc";
                dtResult = dtResult.DefaultView.ToTable().Copy();
            }

            return dtResult;
        }

        public async Task<DataTable> GetCameraVsChannel()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[CheckVideoReg].[GetCameraVsChannel]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        public async Task<DataTable> SetCameraVsChannel(int id, string CamName, string CamIP, string RegChannel,int id_VideoReg, string PathScan,byte[] Scan, string Comment, bool isActive, int result, bool isDel)
        {
            ap.Clear();

            ap.Add(id);
            ap.Add(CamName);
            ap.Add(CamIP);
            ap.Add(RegChannel);
            ap.Add(id_VideoReg);
            ap.Add(PathScan);
            ap.Add(Scan);
            ap.Add(Comment);
            ap.Add(isActive);
            ap.Add(UserSettings.User.Id);
            ap.Add(result);
            ap.Add(isDel);

            DataTable dtResult = executeProcedure("[CheckVideoReg].[SetCameraVsChannel]",
                 new string[12] { "@id", "@CamName", "@CamIP", "@RegChannel", "@id_VideoReg", "@PathScan", "@Scan", "@Comment", "@isActive", "@id_user", "@result", "@isDel" },
                 new DbType[12] { DbType.Int32, DbType.String, DbType.String, DbType.String, DbType.Int32, DbType.String, DbType.Binary, DbType.String, DbType.Boolean, DbType.Int32, DbType.Int32, DbType.Boolean }, ap);

            return dtResult;
        }

        public async Task<DataTable> GetImageCameraVsChannel(int id)
        {
            ap.Clear();
            ap.Add(id);

            DataTable dtResult = executeProcedure("[CheckVideoReg].[GetImageCameraVsChannel]",
                 new string[1] { "@id_CameraVsChannel" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }
        #endregion

        #region "Настройки"
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

        public async Task<DataTable> setSettings(string id_value,string value)
        {
            ap.Clear();
            ap.Add(ConnectionSettings.GetIdProgram());
            ap.Add(id_value);
            ap.Add(value);


            DataTable dtResult = executeProcedure("[CheckVideoReg].[setSettings]",
                 new string[3] { "@id_prog", "@id_value", "@value" },
                 new DbType[3] { DbType.Int32, DbType.String, DbType.String }, ap);

            return dtResult;
        }


        #endregion

        #region "Расписание"

        public async Task<DataTable> GetSchedule()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[CheckVideoReg].[GetSchedule]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        public async Task<DataTable> SetSchedule(int id,bool isOn)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(isOn);
            ap.Add(UserSettings.User.Id);

            DataTable dtResult = executeProcedure("[CheckVideoReg].[SetSchedule]",
                 new string[3] { "@id", "@isOn", "@id_user" },
                 new DbType[3] { DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);

            return dtResult;
        }

        #endregion
    }
}