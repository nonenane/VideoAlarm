using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.User;
using System;
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

namespace VideoAlarm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            dgvAlarm.AutoGenerateColumns = false;
            dgvReport.AutoGenerateColumns = false;

            ToolTip ttButton = new ToolTip();
            //ttButton.SetToolTip(btAdd, "Добавить");
            //ttButton.SetToolTip(btDel, "Удалить");
            //ttButton.SetToolTip(btEdit, "Изменить");
            //ttButton.SetToolTip(btPrint, "Печать");
            //ttButton.SetToolTip(btUpdate, "Обновить");
            //ttButton.SetToolTip(btnViewOrders, "Работа с заказами");
            //ttButton.SetToolTip(btChangePrice, "Обновить цены");
            //ttButton.SetToolTip(btnAddTovars, "Добавить товары");
            //ttButton.SetToolTip(btnEditAttribute, "Редактировать атрибуты");
            tsLabel.Text = Nwuram.Framework.Settings.Connection.ConnectionSettings.GetServer() + " " +
                Nwuram.Framework.Settings.Connection.ConnectionSettings.GetDatabase();
            this.Text = Nwuram.Framework.Settings.Connection.ConnectionSettings.ProgramName + " - " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername;


            //if (UserSettings.User.StatusCode == "РКВ") настройкиПроцентовToolStripMenuItem.Visible = false;
            //if (UserSettings.User.StatusCode.ToLower() == "пр")

        }

        private void frnMain_Load(object sender, EventArgs e)
        {
            dtpAlarmStart.Value = DateTime.Now.AddDays(-1);
            dtpReportStart.Value = DateTime.Now.AddDays(-1);

            Task<DataTable> task = Config.hCntMain.GetVideoRegList(true);
            task.Wait();
            DataTable dtAlarmVideoReg = task.Result.Copy();
            DataTable dtReportVideoReg = task.Result.Copy();


            cmbReportVideoReg.DisplayMember = "RegName";
            cmbReportVideoReg.ValueMember = "id";
            cmbReportVideoReg.DataSource = dtReportVideoReg;


            cmbAlarmVideoReg.DisplayMember = "RegName";
            cmbAlarmVideoReg.ValueMember = "id";
            cmbAlarmVideoReg.DataSource = dtAlarmVideoReg;

            task = Config.hCntMain.GetCameraVsChannelList(true);
            task.Wait();
            DataTable dtCameraVsChannelList = task.Result.Copy();

            cmbAlarmCameraVsChannel.DisplayMember = "nameRegCamName";
            cmbAlarmCameraVsChannel.ValueMember = "id";
            cmbAlarmCameraVsChannel.DataSource = dtCameraVsChannelList;


            task = Config.hCntMain.GetTypeEvent(true);
            task.Wait();
            DataTable dtTypeEvent = task.Result.Copy();

            cmbAlarmTypeEvent.DisplayMember = "TypeEvent";
            cmbAlarmTypeEvent.ValueMember = "TypeEvent";
            cmbAlarmTypeEvent.DataSource = dtTypeEvent;


            task = Config.hCntMain.getSettings("dlsc");
            task.Wait();
            if (task.Result != null && task.Result.Rows.Count > 0 && task.Result.Rows[0]["value"] != null)
            {
                decimal valueDec;
                if (decimal.TryParse(task.Result.Rows[0]["value"].ToString(), out valueDec))
                {
                    delta = decimal.ToInt32(valueDec);
                    tbAlarmDelta.Text = valueDec.ToString("0");
                }
            }

            dgvAlarm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //GetReport();
            //GetAlarm();
        }

        private void frnMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show(Config.centralText("Вы действительно хотите выйти\nиз программы?\n"), "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No;
        }

        #region "Меню"
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void справочникВидеорегистраторовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VideoReg.frmList().ShowDialog();
        }

        private void справочникОтветственныхСотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Responsible.frmList().ShowDialog();
        }

        private void справочникКаналовВидеорегистраторовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChannelVsReg.frmList().ShowDialog();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings.frmList().ShowDialog();
        }

        private void расписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Shedule.frmList().ShowDialog();
        }
        #endregion

        #region "Отчёт"
        private DataTable dtReport;
        private void dgvReport_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            //Рисуем рамку для выделеной строки
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void dgvReport_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtReport != null && dtReport.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                //if (!(bool)dtReport.DefaultView[e.RowIndex]["isActive"])
                //   rColor = panel1.BackColor;
                dgvReport.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvReport.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvReport.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void dgvReport_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvReport.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cReportComment.Name))
                {
                    tbReportComment.Location = new Point(dgvReport.Location.X + 1 + width, tbReportComment.Location.Y);
                    tbReportComment.Size = new Size(cReportComment.Width, tbReportComment.Height);
                }

                if (col.Name.Equals(cReportResponsible.Name))
                {
                    tbReportResponsible.Location = new Point(dgvReport.Location.X + 1 + width, tbReportComment.Location.Y);
                    tbReportResponsible.Size = new Size(cReportResponsible.Width, tbReportComment.Height);
                }

                width += col.Width;

            }
        }

        private void setFilterReport()
        {
            if (dtReport == null || dtReport.Rows.Count == 0)
            {
                btReportComment.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if ((int)cmbReportVideoReg.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_VideoReg  = {cmbReportVideoReg.SelectedValue}";

                if (tbReportResponsible.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"nameResponsible like '%{tbReportResponsible.Text.Trim()}%'";

                if (tbReportComment.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"Comment like '%{tbReportComment.Text.Trim()}%'";

                dtReport.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtReport.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btReportComment.Enabled =
                dtReport.DefaultView.Count != 0;
                //dgvData_SelectionChanged(null, null);
            }
        }

        private void GetReport()
        {
            Task.Run(() =>
            {
                Config.DoOnUIThread(() => { this.Enabled = false; }, this);

                Task<DataTable> task = Config.hCntMain.GetReportVideoReg(dtpReportStart.Value, dtpReportEnd.Value);
                task.Wait();
                dtReport = task.Result;

                Config.DoOnUIThread(() =>
                {
                    DataGridViewColumn oldCol = dgvReport.SortedColumn;
                    ListSortDirection direction = ListSortDirection.Ascending;
                    if (oldCol != null)
                    {
                        if (dgvReport.SortOrder == SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Ascending;
                        }
                        else
                        {
                            direction = ListSortDirection.Descending;
                        }
                    }
                    setFilterReport();
                    dgvReport.DataSource = dtReport;


                    if (oldCol != null)
                    {
                        dgvReport.Sort(oldCol, direction);
                        oldCol.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;
                    }

                }, this);

                Config.DoOnUIThread(() => { this.Enabled = true; }, this);
            });
        }

        private void dtpReportStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpReportStart.Value.Date > dtpReportEnd.Value.Date)
                dtpReportEnd.Value = dtpReportStart.Value.Date;
        }

        private void dtpReportEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpReportStart.Value.Date > dtpReportEnd.Value.Date)
                dtpReportStart.Value = dtpReportEnd.Value.Date;
        }

        private void cmbReportVideoReg_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilterReport();
        }

        private void tbReportComment_TextChanged(object sender, EventArgs e)
        {
            setFilterReport();
        }

        private void btReportUpdate_Click(object sender, EventArgs e)
        {
            GetReport();
        }

        private void btReportComment_Click(object sender, EventArgs e)
        {
            Comment.frmComment fComment = new Comment.frmComment();
            if (DialogResult.OK == fComment.ShowDialog())
            {
                int id = (int)dtReport.DefaultView[dgvReport.CurrentRow.Index]["id"];
                string comment = fComment.getComment();

                Task task = Config.hCntMain.SetCommentAlarmVideoReg(id, comment, 2);
                task.Wait();

                dtReport.DefaultView[dgvReport.CurrentRow.Index]["Comment"] = comment;
                dtReport.AcceptChanges();
            }
        }

        private void dtpReportStart_CloseUp(object sender, EventArgs e)
        {
            GetReport();
        }

        private void dtpReportStart_Leave(object sender, EventArgs e)
        {
            GetReport();
        }

        #endregion

        #region "Тревоги"
        private int delta = 0;
        private DataTable dtAlarm;
        private void chbAlarmTime_Click(object sender, EventArgs e)
        {
            dtpAlarmTimeStart.Enabled = dtpAlarmTimeEnd.Enabled = chbAlarmTime.Checked;
            setFilterAlarm();
        }

        private void btAlarmDropDelta_Click(object sender, EventArgs e)
        {
            tbAlarmDelta.Text = delta.ToString();
            setFilterAlarm();
        }

        private void tbAlarmDelta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private void tbAlarmDelta_Leave(object sender, EventArgs e)
        {
            decimal valueDec;
            TextBox tb = (sender as TextBox);
            if (decimal.TryParse(tb.Text, out valueDec))
            {
                tb.Text = valueDec.ToString("0");
            }
            else
            {
                tb.Text = delta.ToString();
            }
            setFilterAlarm();
        }

        private void dgvAlarm_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtAlarm != null && dtAlarm.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                if (dtAlarm.DefaultView[e.RowIndex]["DateEndAlarm"] == DBNull.Value)
                    rColor = pAlarmLegend.BackColor;
                dgvAlarm.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvAlarm.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvAlarm.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

            }
        }

        private void dgvAlarm_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            //Рисуем рамку для выделеной строки
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void dgvAlarm_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvAlarm.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cAlarmChannel.Name))
                {
                    tbAlarmChannel.Location = new Point(dgvAlarm.Location.X + 1 + width, tbAlarmChannel.Location.Y);
                    tbAlarmChannel.Size = new Size(cAlarmChannel.Width, tbAlarmChannel.Height);
                }

                if (col.Name.Equals(cAlarmNameCam.Name))
                {
                    tbAlarmNameCam.Location = new Point(dgvAlarm.Location.X + 1 + width, tbAlarmChannel.Location.Y);
                    tbAlarmNameCam.Size = new Size(cAlarmNameCam.Width, tbAlarmChannel.Height);
                }

                if (col.Name.Equals(cAlarmComment.Name))
                {
                    tbAlarmComment.Location = new Point(dgvAlarm.Location.X + 1 + width, tbAlarmChannel.Location.Y);
                    tbAlarmComment.Size = new Size(cAlarmComment.Width, tbAlarmChannel.Height);
                }

                if (col.Name.Equals(cAlarmResponcible.Name))
                {
                    tbAlarmResponsible.Location = new Point(dgvAlarm.Location.X + 1 + width, tbAlarmChannel.Location.Y);
                    tbAlarmResponsible.Size = new Size(cAlarmResponcible.Width, tbAlarmChannel.Height);
                }

                width += col.Width;

            }
        }

        private void GetAlarm()
        {
            Task.Run(() =>
            {                
                Config.DoOnUIThread(() => { this.Enabled = false; }, this);

                Task<DataTable> task = Config.hCntMain.GetAlarmVideoReg(dtpAlarmStart.Value, dtpAlarmEnd.Value);
                task.Wait();
                dtAlarm = task.Result;

                Config.DoOnUIThread(() =>
                {
                    DataGridViewColumn oldCol = dgvAlarm.SortedColumn;
                    ListSortDirection direction = ListSortDirection.Ascending;
                    if (oldCol != null)
                    {
                        if (dgvAlarm.SortOrder == SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Ascending;
                        }
                        else
                        {
                            direction = ListSortDirection.Descending;
                        }
                    }
                    setFilterAlarm();
                    dgvAlarm.DataSource = dtAlarm;


                    if (oldCol != null)
                    {
                        dgvAlarm.Sort(oldCol, direction);
                        oldCol.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;
                    }

                }, this);

                Config.DoOnUIThread(() => { this.Enabled = true; }, this);
            });
        }

        private void setFilterAlarm()
        {
            if (dtAlarm == null || dtAlarm.Rows.Count == 0)
            {
                btAlarmComment.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if ((int)cmbAlarmVideoReg.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_VideoReg  = {cmbAlarmVideoReg.SelectedValue}";

                if ((int)cmbAlarmCameraVsChannel.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_Camera_vs_Channel  = {cmbAlarmCameraVsChannel.SelectedValue}";

                if (!((string)cmbAlarmTypeEvent.SelectedValue).Equals("Все"))
                    filter += (filter.Length == 0 ? "" : " and ") + $"TypeEvent  = '{cmbAlarmTypeEvent.SelectedValue}'";

                if (tbAlarmChannel.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"RegChannel like '%{tbAlarmChannel.Text.Trim()}%'";

                if (tbAlarmNameCam.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"CamName like '%{tbAlarmNameCam.Text.Trim()}%'";

                if (tbAlarmComment.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"Comment like '%{tbAlarmComment.Text.Trim()}%'";

                if (tbAlarmResponsible.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"nameResponsible like '%{tbAlarmResponsible.Text.Trim()}%'";

                filter += (filter.Length == 0 ? "" : " and ") + $"(delta is null OR delta > '{tbAlarmDelta.Text}')";


                if (chbAlarmTime.Checked)
                {
                    filter += (filter.Length == 0 ? "" : " and ") + $"'{dtpAlarmStart.Value.Date.Add(dtpAlarmTimeStart.Value.TimeOfDay)}'<=DateCreate AND DateCreate<='{dtpAlarmEnd.Value.Date.Add(dtpAlarmTimeEnd.Value.TimeOfDay)}'";
                }

                dtAlarm.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtAlarm.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                //btEdit.Enabled =  
                btAlarmComment.Enabled =
                dtAlarm.DefaultView.Count != 0;
                //dgvData_SelectionChanged(null, null);
            }
        }

        private void cmbAlarmVideoReg_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilterAlarm();
        }

        private void tbAlarmChannel_TextChanged(object sender, EventArgs e)
        {
            setFilterAlarm();
        }

        private void btAlarmUpdatre_Click(object sender, EventArgs e)
        {
            GetAlarm();
        }

        private void btAlarmComment_Click(object sender, EventArgs e)
        {
            Comment.frmComment fComment = new Comment.frmComment();
            if (DialogResult.OK == fComment.ShowDialog())
            {
                int id = (int)dtAlarm.DefaultView[dgvAlarm.CurrentRow.Index]["id"];                
                string comment = fComment.getComment();

                Task task = Config.hCntMain.SetCommentAlarmVideoReg(id, comment, 1);
                task.Wait();

                dtAlarm.DefaultView[dgvAlarm.CurrentRow.Index]["Comment"] = comment;
                dtAlarm.AcceptChanges();
            }
        }

        private void dtpAlarmStart_CloseUp(object sender, EventArgs e)
        {
            GetAlarm();
        }

        private void dtpAlarmEnd_Leave(object sender, EventArgs e)
        {
            GetAlarm();
        }

        private void dtpAlarmStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpAlarmStart.Value.Date > dtpAlarmEnd.Value.Date)
                dtpAlarmEnd.Value = dtpAlarmStart.Value.Date;
        }

        private void dtpAlarmEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpAlarmStart.Value.Date > dtpAlarmEnd.Value.Date)
                dtpAlarmStart.Value = dtpAlarmEnd.Value.Date;
        }

        private void dtpAlarmTimeStart_ValueChanged(object sender, EventArgs e)
        {
            setFilterAlarm();
        }

        #endregion

       
    }
}
