using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.Connection;
using Nwuram.Framework.Settings.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoAlarm.ChannelVsReg
{
    public partial class frmList : Form
    {
        private DataTable dtData;
        public frmList()
        {
            InitializeComponent();

            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            if (Config.hCntSecond == null)
                Config.hCntSecond = new Procedures(ConnectionSettings.GetServer("3"), ConnectionSettings.GetDatabase("3"), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            dgvData.AutoGenerateColumns = false;

            ToolTip tp = new ToolTip();
            tp.SetToolTip(btAdd, "Добавить");
            tp.SetToolTip(btEdit, "Редактировать");
            tp.SetToolTip(btDelete, "Удалить");
            tp.SetToolTip(btClose, "Выход");
            //btAdd.Visible = btEdit.Visible = btDelete.Visible = new List<string> { "ИНФ", "СОП" }.Contains(UserSettings.User.StatusCode);
        }

        private void frmList_Load(object sender, EventArgs e)
        {
            Task<DataTable> task = Config.hCntMain.GetVideoRegList(true);
            task.Wait();
            DataTable dtVideoReg = task.Result;

            cmbVideoReg.DisplayMember = "RegName";
            cmbVideoReg.ValueMember = "id";
            cmbVideoReg.DataSource = dtVideoReg;


            get_data();
        }

        private void frmList_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new frmAdd() { Text = "Добавить канал" }.ShowDialog())
                get_data();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];
                if (DialogResult.OK == new frmAdd() { Text = "Редактировать канал", row = row }.ShowDialog())
                    get_data();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                Task<DataTable> task;
                int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
                bool isActive = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"];

                string CamName = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["CamName"];
                string CamIP = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["CamIP"];
                string PathScan = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["PathScan"];
                string Comment = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["Comment"];
                string RegChannel = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["RegChannel"];
                int id_VideoReg = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id_VideoReg"];
                byte[] img = null;
                if ((bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isScan"])
                {
                   task = Config.hCntMain.GetImageCameraVsChannel(id);
                    task.Wait();
                    if (task.Result != null && task.Result.Rows.Count > 0 && task.Result.Rows[0]["Scan"] != DBNull.Value)
                        if (task.Result.Rows[0]["Scan"] is byte[])
                            img = (byte[])task.Result.Rows[0]["Scan"];
                }

                task = Config.hCntMain.SetCameraVsChannel(id, CamName, CamIP, RegChannel, id_VideoReg, PathScan, img, Comment, isActive, 0, true);
                task.Wait();

                if (task.Result == null)
                {
                    MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int result = (int)task.Result.Rows[0]["id"];

                if (result == -1)
                {
                    MessageBox.Show(Config.centralText("Запись уже удалена другим пользователем\n"), "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    get_data();
                    return;
                }

                if (result == -2 && isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show(Config.centralText("Выбранная для удаления запись\nиспользуется в программе.\nСделать запись недействующей?\n"), "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        //setLog(id, 1542);
                        task = Config.hCntMain.SetCameraVsChannel(id, CamName, CamIP, RegChannel, id_VideoReg, PathScan, img, Comment, !isActive, 0, false);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        get_data();
                        return;
                    }
                }
                else
                if (result == 0 && isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show("Удалить выбранную запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        //setLog(id, 1566);
                        task = Config.hCntMain.SetCameraVsChannel(id, CamName, CamIP, RegChannel, id_VideoReg, PathScan, img, Comment, isActive, 1, true);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        get_data();
                        return;
                    }
                }
                else if (!isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show("Сделать выбранную запись действующей?", "Восстановление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        //setLog(id, 1543);
                        task = Config.hCntMain.SetCameraVsChannel(id, CamName, CamIP, RegChannel, id_VideoReg, PathScan, img, Comment, !isActive, 0, false);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        get_data();
                        return;
                    }
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void chbNotActive_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void setFilter()
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                btEdit.Enabled = btDelete.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if((int)cmbVideoReg.SelectedValue!=0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_VideoReg  = {cmbVideoReg.SelectedValue}";

                if (tbChannel.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"RegChannel like '%{tbChannel.Text.Trim()}%'";

                if (tbNameCam.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"CamName like '%{tbNameCam.Text.Trim()}%'";

                if (tbComment.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"Comment like '%{tbComment.Text.Trim()}%'";

                if (!chbNotActive.Checked)
                    filter += (filter.Length == 0 ? "" : " and ") + $"isActive = 1";

                dtData.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btEdit.Enabled = btDelete.Enabled =
                dtData.DefaultView.Count != 0;
                dgvData_SelectionChanged(null, null);
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Index == -1 || dtData == null || dtData.DefaultView.Count == 0 || dgvData.CurrentRow.Index >= dtData.DefaultView.Count)
            {
                btDelete.Enabled = false;
                btEdit.Enabled = false;
                btViewScreenShot.Enabled = false;
                tbFio.Text = tbDate.Text = "";
                return;
            }

            btDelete.Enabled = true;
            btEdit.Enabled = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"];

            tbFio.Text = dtData.DefaultView[dgvData.CurrentRow.Index]["FIO"].ToString();
            tbDate.Text = dtData.DefaultView[dgvData.CurrentRow.Index]["DateEdit"].ToString();
            btViewScreenShot.Enabled = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isScan"];
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                if (!(bool)dtData.DefaultView[e.RowIndex]["isActive"])
                    rColor = panel1.BackColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

            }
        }

        private void get_data()
        {
            Task.Run(() =>
            {
                Config.DoOnUIThread(() => { this.Enabled = false; }, this);

                Task<DataTable> task = Config.hCntMain.GetCameraVsChannel();
                task.Wait();
                dtData = task.Result;

                Config.DoOnUIThread(() =>
                {
                    DataGridViewColumn oldCol = dgvData.SortedColumn;
                    ListSortDirection direction = ListSortDirection.Ascending;
                    if (oldCol != null)
                    {
                        if (dgvData.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Ascending;
                        }
                        else
                        {
                            direction = ListSortDirection.Descending;
                        }
                    }
                    setFilter();
                    dgvData.DataSource = dtData;


                    if (oldCol != null)
                    {
                        dgvData.Sort(oldCol, direction);
                        oldCol.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
                    }

                }, this);

                Config.DoOnUIThread(() => { this.Enabled = true; }, this);
            });
        }

        private void setLog(int id, int id_log)
        {
            Logging.StartFirstLevel(id_log);
            switch (id_log)
            {
                case 2: Logging.Comment("Удаление Типа документа"); break;
                case 3: Logging.Comment("Тип документа переведён в недействующие "); break;
                case 4: Logging.Comment("Тип документа переведён  в действующие"); break;
                default: break;
            }

            string cName = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["cName"];

            Logging.Comment($"ID:{id}");
            Logging.Comment($"Наименование: {cName}");

            Logging.StopFirstLevel();
        }

        private void dgvData_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cRegChannel.Name))
                {
                    tbChannel.Location = new Point(dgvData.Location.X + 1 + width, tbChannel.Location.Y);
                    tbChannel.Size = new Size(cRegChannel.Width, tbChannel.Height);
                }

                if (col.Name.Equals(cNameCam.Name))
                {
                    tbNameCam.Location = new Point(dgvData.Location.X + 1 + width, tbChannel.Location.Y);
                    tbNameCam.Size = new Size(cNameCam.Width, tbChannel.Height);
                }

                if (col.Name.Equals(cComment.Name))
                {
                    tbComment.Location = new Point(dgvData.Location.X + 1 + width, tbChannel.Location.Y);
                    tbComment.Size = new Size(cComment.Width, tbChannel.Height);
                }

                width += col.Width;

            }
        }

        private void btViewScreenShot_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];
                byte[] img = null;
                if ((bool)row["isScan"])
                {
                    int id = (int)row["id"];
                    Task<DataTable> task = Config.hCntMain.GetImageCameraVsChannel(id);
                    task.Wait();
                    if (task.Result != null && task.Result.Rows.Count > 0 && task.Result.Rows[0]["Scan"] != DBNull.Value)
                        if (task.Result.Rows[0]["Scan"] is byte[])
                        {
                            if (!Directory.Exists(Application.StartupPath + "//buffer//"))
                                Directory.CreateDirectory(Application.StartupPath + "//buffer//");

                            img = (byte[])task.Result.Rows[0]["Scan"];
                            FileInfo infoFile = new FileInfo(row["PathScan"].ToString());
                            string tmpFile = Application.StartupPath + "//buffer//" + $"{infoFile.Name}";//.{infoFile.Extension}";
                            File.WriteAllBytes(tmpFile, img);
                            Process.Start(tmpFile);
                        }
                }
            }
        }

        private void cmbVideoReg_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilter();
        }
    }
}