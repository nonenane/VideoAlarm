using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoAlarm.Settings
{
    public partial class frmList : Form
    {
        private bool isEditData = false;
        public frmList()
        {
            InitializeComponent();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
        }

        private void frmList_Load(object sender, EventArgs e)
        {
            getSetting("dlmn", tbMinut);
            getSetting("dlsc", tbSecond);
            isEditData = false;
        }

        private void getSetting(string id_value, TextBox tb)
        {
            Task<DataTable> task = Config.hCntMain.getSettings(id_value);
            task.Wait();
            if (task.Result != null && task.Result.Rows.Count > 0 && task.Result.Rows[0]["value"] != null)
            {
                decimal valueDec;
                if (decimal.TryParse(task.Result.Rows[0]["value"].ToString(), out valueDec))
                {
                    tb.Text = valueDec.ToString("0");
                }
            }
        }

        private void setSetting(string id_value, TextBox tb)
        {
            Task<DataTable> task = Config.hCntMain.setSettings(id_value, tb.Text);
            task.Wait();          
        }

        private void frmList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void tbMinut_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private void tbMinut_Leave(object sender, EventArgs e)
        {
            decimal valueDec;
            TextBox tb = (sender as TextBox);
            if (decimal.TryParse(tb.Text, out valueDec))
            {
                tb.Text = valueDec.ToString("0");
            }
            else
            {
                tb.Text = "0";
            }

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            setSetting("dlmn", tbMinut);
            setSetting("dlsc", tbSecond);

            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void tbMinut_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
