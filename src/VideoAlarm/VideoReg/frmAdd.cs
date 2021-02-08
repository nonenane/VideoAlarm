using Microsoft.WindowsAPICodePack.Dialogs;
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

namespace VideoAlarm.VideoReg
{
    public partial class frmAdd : Form
    {
        FolderBrowserDialog folderBrowserDialog1;

        public DataRowView row { set; private get; }

        private bool isEditData = false;
        private string oldName, oldCode;
        private int id = 0;
        public bool isSaveData = false;

        public frmAdd()
        {
            InitializeComponent();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");

            this.folderBrowserDialog1 = new FolderBrowserDialog();
            this.folderBrowserDialog1.Description = "Выберите каталог";

            // Do not allow the user to create new files via the FolderBrowserDialog.
            this.folderBrowserDialog1.ShowNewFolderButton = true;

            // Default to the My Documents folder.
            this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            Task<DataTable> task = Config.hCntMain.GetShopName(false);
            task.Wait();
            DataTable dtDeps = task.Result;

            cmbShop.DisplayMember = "cName";
            cmbShop.ValueMember = "id";
            cmbShop.DataSource = dtDeps;
            cmbShop.SelectedIndex = -1;
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            if (row != null)
            {
                id = (int)row["id"];
                tbRegName.Text = (string)row["RegName"];
                oldName = tbRegName.Text.Trim();

                tbRegIP.Text = (string)row["RegIP"];
                oldCode = tbRegName.Text.Trim();

                tbPlace.Text = (string)row["Place"];

                tbPathLog.Text = (string)row["PathLog"];

                tbComment.Text = (string)row["Comment"];

                cmbShop.SelectedValue = row["id_shop"] == DBNull.Value ? 0 : (int)row["id_shop"];
            }

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

            if (tbRegName.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{lName.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbRegName.Focus();
                return;
            }

            if (tbRegIP.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{label1.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbRegIP.Focus();
                return;
            }

            IPAddress address;
            if (!IPAddress.TryParse(tbRegIP.Text, out address))
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{label1.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbRegIP.Focus();
                return;
            }

            if (cmbShop.SelectedIndex == -1)
            {
                MessageBox.Show(Config.centralText($"Необходимо выбрать\n \"{label5.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbShop.Focus();
                return;
            }


            if (tbPlace.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{label2.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPlace.Focus();
                return;
            }

            //if (tbPathLog.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{label4.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    btFolderSelect.Focus();
            //    return;
            //}

            //if (!System.IO.Directory.Exists(tbPathLog.Text))
            //{
            //    MessageBox.Show(Config.centralText($"Текущий путь:\n{tbPathLog.Text}\n не существует!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            Task<DataTable> task = Config.hCntMain.SetVideoReg(id, tbRegName.Text, tbRegIP.Text, tbPlace.Text, tbPathLog.Text, tbComment.Text, (int)cmbShop.SelectedValue, true, 0, false);
            task.Wait();

            DataTable dtResult = task.Result;

            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if ((int)dtResult.Rows[0]["id"] == -1)
            {
                //MessageBox.Show("В справочнике уже присутствует запись с таким наименованием.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(Config.centralText($"{dtResult.Rows[0]["msg"].ToString().Replace("\\n", "\n")}"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)dtResult.Rows[0]["id"] == -9999)
            {
                MessageBox.Show($"{dtResult.Rows[0]["msg"]}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isClose = false;
            if (id == 0)
            {
                id = (int)dtResult.Rows[0]["id"];
                Logging.StartFirstLevel(1564);
                //Logging.Comment("Добавить Тип документа");
                Logging.Comment($"ID: {id}");
                Logging.Comment($"Наименование: {tbRegName.Text.Trim()}");
                Logging.StopFirstLevel();
                isSaveData = true;
            }
            else
            {
                Logging.StartFirstLevel(1565);
                //Logging.Comment("Редактировать Тип документа");
                Logging.Comment($"ID: {id}");
                Logging.VariableChange("Наименование", tbRegName.Text.Trim(), oldName);
                Logging.StopFirstLevel();
                isClose = true;
            }

            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (isClose) this.DialogResult = DialogResult.OK; else ClearForm() ;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void tbPathLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
                tbPathLog.Text = Clipboard.GetText();
        }

        private void btFolderSelect_Click(object sender, EventArgs e)
        {
            //DialogResult result = folderBrowserDialog1.ShowDialog();          
            //if (result == DialogResult.OK)
            //{
            //    string folderName = folderBrowserDialog1.SelectedPath;
            //    tbPathLog.Text = folderName;
            //}

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            //dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                //if (!validateFileAndFolder(dialog.FileName)) return;

                //btSave.Enabled = true;
                //tbPath.Text = dialog.FileName;
                string folderName = dialog.FileName;
                tbPathLog.Text = folderName;
            }
        }

        private void ClearForm()
        {
            tbRegName.Text = "";
            tbPathLog.Text = "";
            tbComment.Text = "";
            cmbShop.SelectedIndex = -1;
            tbRegIP.Text = "";
            tbPlace.Text = "";
            id = 0;
            isEditData = false;
        }
    }
}
