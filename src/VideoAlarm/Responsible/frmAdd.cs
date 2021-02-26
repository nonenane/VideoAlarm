using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoAlarm.Responsible
{
    public partial class frmAdd : Form
    {
        private DataTable dtData;
        private bool isEditData = false;
        private int id = 0;

        public frmAdd()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            Task<DataTable> task = Config.hCntMain.GetDepartments(true);
            task.Wait();
            DataTable dtDeps = task.Result;

            cmbDeps.DisplayMember = "cName";
            cmbDeps.ValueMember = "id";
            cmbDeps.DataSource = dtDeps;

            get_data();
            isEditData = false;
        }

        private void frmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int id_kadr = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
            string nameKadr = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["nameKadr"];
            string nameDeps = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["nameDeps"];
            int id_departments = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id_departments"];

            Task<DataTable> task = Config.hCntMain.SetResponsible(id, id_kadr, true, 0, false);
            task.Wait();

            DataTable dtResult = task.Result;

            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)dtResult.Rows[0]["id"] == -1)
            {                
                MessageBox.Show(Config.centralText($"{dtResult.Rows[0]["msg"].ToString().Replace("\\n", "\n")}"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)dtResult.Rows[0]["id"] == -9999)
            {
                MessageBox.Show($"{dtResult.Rows[0]["msg"]}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (id == 0)
            {
                id = (int)dtResult.Rows[0]["id"];
                Logging.StartFirstLevel((int)LogEvent.Добавление_ответственного_сотрудника);
                Logging.Comment($"ID: {id}");
                Logging.Comment($"ID: {id_kadr}; ФИО:{nameKadr}");
                Logging.Comment($"Отдел ID: {id_departments}; Наименование:{nameDeps}");
                Logging.StopFirstLevel();
            }

            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void setFilter()
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                btSave.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if ((int)cmbDeps.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_departments = {cmbDeps.SelectedValue}";

                if (tbNumber.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"nameKadr like '%{tbNumber.Text.Trim()}%'";

                dtData.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btSave.Enabled =
                 dtData.DefaultView.Count != 0;
            }
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void dgvData_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cFIO.Name))
                {
                    tbNumber.Location = new Point(dgvData.Location.X + 1 + width, tbNumber.Location.Y);
                    tbNumber.Size = new Size(cFIO.Width, tbNumber.Height);
                }

                width += col.Width;

            }
        }

        private void get_data()
        {
            Task.Run(() =>
            {
                Config.DoOnUIThread(() => { this.Enabled = false; }, this);

                Task<DataTable> task = Config.hCntMain.GetListKadr();
                task.Wait();
                dtData = task.Result;

                Config.DoOnUIThread(() =>
                {
                    DataGridViewColumn oldCol = dgvData.SortedColumn;
                    ListSortDirection direction = ListSortDirection.Ascending;
                    if (oldCol != null)
                    {
                        if (dgvData.SortOrder == SortOrder.Ascending)
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
                            SortOrder.Ascending : SortOrder.Descending;
                    }

                }, this);

                Config.DoOnUIThread(() => { this.Enabled = true; }, this);
            });
        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilter();
        }

        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;

            btSave_Click(null, null);
        }
    }
}
