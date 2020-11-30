using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoAlarm.Shedule
{
    public partial class frmList : Form
    {
        private bool isEditData = false;
        private DataTable dtData, dtDataCopy;


        public frmList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
        }

        private void frmList_Load(object sender, EventArgs e)
        {
            get_data();
            isEditData = false;
        }

        private void frmList_FormClosing(object sender, FormClosingEventArgs e)
        {
            var differences = dtData.AsEnumerable()
               .Except(dtDataCopy.AsEnumerable(), DataRowComparer.Default);

            isEditData = differences.Count() != 0;
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            var differences = dtData.AsEnumerable()
                .Except(dtDataCopy.AsEnumerable(), DataRowComparer.Default);

            foreach (DataRow row in differences)
            {
                Task<DataTable> task = Config.hCntMain.SetSchedule((int)row["id"], (bool)row["isOn"]);
                task.Wait();
            }

            dtDataCopy = dtData.Copy();
            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void get_data()
        {
            Task.Run(() =>
            {
                Config.DoOnUIThread(() => { this.Enabled = false; }, this);

                Task<DataTable> task = Config.hCntMain.GetSchedule();
                task.Wait();
                dtData = task.Result;
                dtDataCopy = dtData.Copy();

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
    }
}
