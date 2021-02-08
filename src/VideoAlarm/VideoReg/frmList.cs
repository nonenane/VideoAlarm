using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.Connection;
using Nwuram.Framework.Settings.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoAlarm.VideoReg
{
    public partial class frmList : Form
    {
        public bool isUpdate { private set; get; }
        public bool isSelect { set; private get; }
        public string listIdReg { private set;  get; }
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
            tp.SetToolTip(btAlarmUpdatre, "Обновить");
            //btAdd.Visible = btEdit.Visible = btDelete.Visible = new List<string> { "ИНФ", "СОП" }.Contains(UserSettings.User.StatusCode);

            Task<DataTable> task = Config.hCntMain.GetShopName(true);
            task.Wait();
            DataTable dtDeps = task.Result;

            cmbShop.DisplayMember = "cName";
            cmbShop.ValueMember = "id";
            cmbShop.DataSource = dtDeps;            
        }

        private void frmList_Load(object sender, EventArgs e)
        {
            get_data();
            cSelect.Visible = isSelect;
            if (isSelect)
            {
                btAdd.Visible = btEdit.Visible = btDelete.Visible = false;
                panel1.Visible = chbNotActive.Visible = false;
                btSelect.Visible = true;
                label1.Visible = label2.Visible = tbFio.Visible = tbDate.Visible = false;
            }
        }

        private void frmList_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAdd fAdd = new frmAdd() { Text = "Добавить видеорегистратор" };
            fAdd.ShowDialog();
            if (fAdd.isSaveData)
            {
                get_data();
                isUpdate = true;
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];
                if (DialogResult.OK == new frmAdd() { Text = "Редактировать видеорегистратор", row = row }.ShowDialog())
                {
                    get_data();
                    isUpdate = true;
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
                bool isActive = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"];
                string RegName = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["RegName"];
                string RegIP = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["RegIP"];
                string Place = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["Place"];
                string PathLog = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["PathLog"];
                string Comment = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["Comment"];
                int id_shop = dtData.DefaultView[dgvData.CurrentRow.Index]["id_shop"] == DBNull.Value ? 0 : (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id_shop"];


                Task<DataTable> task = Config.hCntMain.SetVideoReg(id, RegName, RegIP, Place, PathLog, Comment, id_shop, isActive, 0, true);
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
                    isUpdate = true;
                    get_data();
                    return;
                }

                if (result == -2 && isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show(Config.centralText("Выбранная для удаления запись\nиспользуется в программе.\nСделать запись недействующей?\n"), "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        //setLog(id, 1542);
                        task = Config.hCntMain.SetVideoReg(id, RegName, RegIP, Place, PathLog, Comment, id_shop, isActive, 0, false);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        isUpdate = true;
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
                        task = Config.hCntMain.SetVideoReg(id, RegName, RegIP, Place, PathLog, Comment, id_shop, isActive, 1, true);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        isUpdate = true;
                        get_data();
                        return;
                    }
                }
                else if (!isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show("Сделать выбранную запись действующей?", "Восстановление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        //setLog(id, 1543);
                        task = Config.hCntMain.SetVideoReg(id, RegName, RegIP, Place, PathLog, Comment, id_shop, !isActive, 0, false);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        isUpdate = true;
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

                if (tbNumber.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"RegName like '%{tbNumber.Text.Trim()}%'";

                if (tbPlace.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"Place like '%{tbPlace.Text.Trim()}%'";

                if (tbComment.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"Comment like '%{tbComment.Text.Trim()}%'";

                if (!chbNotActive.Checked)
                    filter += (filter.Length == 0 ? "" : " and ") + $"isActive = 1";

                if ((int)cmbShop.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_shop = {cmbShop.SelectedValue}";

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
                tbFio.Text = tbDate.Text = "";
                return;
            }

            btDelete.Enabled = true;
            btEdit.Enabled = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"];

            tbFio.Text = dtData.DefaultView[dgvData.CurrentRow.Index]["FIO"].ToString();
            tbDate.Text = dtData.DefaultView[dgvData.CurrentRow.Index]["DateEdit"].ToString();
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

                Task<DataTable> task = Config.hCntMain.GetVideoReg();
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

                if (col.Name.Equals(cName.Name))
                {
                    tbNumber.Location = new Point(dgvData.Location.X + 1 + width, tbNumber.Location.Y);
                    tbNumber.Size = new Size(cName.Width, tbNumber.Height);
                }

                if (col.Name.Equals(cPlace.Name))
                {
                    tbPlace.Location = new Point(dgvData.Location.X + 1 + width, tbNumber.Location.Y);
                    tbPlace.Size = new Size(cPlace.Width, tbNumber.Height);
                }

                if (col.Name.Equals(cComment.Name))
                {
                    tbComment.Location = new Point(dgvData.Location.X + 1 + width, tbNumber.Location.Y);
                    tbComment.Size = new Size(cComment.Width, tbNumber.Height);
                }

                width += col.Width;

            }
        }

        private void btAlarmUpdatre_Click(object sender, EventArgs e)
        {
            get_data();
        }

        private void cmbShop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cShopName.Visible = (int)cmbShop.SelectedValue == 0;
            setFilter();
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            EnumerableRowCollection<DataRow> rowCOllect = dtData.AsEnumerable().Where(r => r.Field<bool>("isSelect"));
            if (rowCOllect.Count() < 2) { MessageBox.Show("Необходимо выбрать более одного регистратора!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            listIdReg = "";
            foreach (DataRow row in rowCOllect)
            {
                listIdReg += listIdReg.Length == 0 ? "" : ",";
                listIdReg += row["id"].ToString();
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}