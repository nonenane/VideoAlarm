using Microsoft.WindowsAPICodePack.Dialogs;
using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoAlarm.ChannelVsReg
{
    public partial class frmAdd : Form
    {
        OpenFileDialog fileBrowserDialog;
        private byte[] img;

        public DataRowView row { set; private get; }

        private bool isEditData = false;
        private string oldCamName, oldCamIP, oldPathScan, oldComment, oldRegChannel, oldVideoReg;
        private int id = 0, oldIdVideoReg;
        public bool isSaveData = false;


        public frmAdd()
        {
            InitializeComponent();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");

            this.fileBrowserDialog = new OpenFileDialog();
            this.fileBrowserDialog.Title = "Выберите изображение";

            fileBrowserDialog.InitialDirectory = "c:\\";
            fileBrowserDialog.Filter = "Image files |*.bmp;*.gif;*.jpg;*.jpeg;*.png";
            fileBrowserDialog.FilterIndex = 2;
            fileBrowserDialog.RestoreDirectory = true;

        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            img = null;
            Task<DataTable> task = Config.hCntMain.GetVideoRegList(false);
            task.Wait();
            DataTable dtVideoReg = task.Result;

            cmbVideoReg.DisplayMember = "RegName";
            cmbVideoReg.ValueMember = "id";
            cmbVideoReg.DataSource = dtVideoReg;
            cmbVideoReg.SelectedIndex = -1;


            if (row != null)
            {
                id = (int)row["id"];

                tbCamName.Text = (string)row["CamName"];
                oldCamName = tbCamName.Text.Trim();

                tbCamIP.Text = (string)row["CamIP"];
                oldCamIP = tbCamName.Text.Trim();

                tbPathScan.Text = (string)row["PathScan"];
                oldPathScan = tbPathScan.Text.Trim();

                tbComment.Text = (string)row["Comment"];
                oldComment = tbComment.Text.Trim();

                tbRegChannel.Text = (string)row["RegChannel"];
                oldRegChannel = tbRegChannel.Text.Trim();

                cmbVideoReg.SelectedValue = (int)row["id_VideoReg"];
                oldIdVideoReg = (int)row["id_VideoReg"];
                oldVideoReg = cmbVideoReg.Text.Trim();

                if ((bool)row["isScan"])
                {
                    task = Config.hCntMain.GetImageCameraVsChannel(id);
                    task.Wait();
                    if (task.Result != null && task.Result.Rows.Count > 0 && task.Result.Rows[0]["Scan"] != DBNull.Value)
                        if (task.Result.Rows[0]["Scan"] is byte[])
                            img = (byte[])task.Result.Rows[0]["Scan"];
                }
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
            if (cmbVideoReg.SelectedIndex==-1)
            {
                MessageBox.Show(Config.centralText($"Необходимо выбрать\n \"{label5.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVideoReg.Focus();
                return;
            }

            if (tbRegChannel.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{label6.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbRegChannel.Focus();
                return;
            }

            if (tbCamName.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{lName.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCamName.Focus();
                return;
            }

            if (tbCamIP.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{label1.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCamIP.Focus();
                return;
            }
            
            IPAddress address;
            if (!IPAddress.TryParse(tbCamIP.Text, out address))
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{label1.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCamIP.Focus();
                return;
            }

            Task<DataTable> task = Config.hCntMain.SetCameraVsChannel(id, tbCamName.Text, tbCamIP.Text,tbRegChannel.Text,(int)cmbVideoReg.SelectedValue,tbPathScan.Text, img, tbComment.Text, true, 0, false);
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
                Logging.StartFirstLevel((int)LogEvent.Добавление_канала_видеорегистратора);
                Logging.Comment($"ID: {id}");
                Logging.Comment($"Видеорегистратор ID: {cmbVideoReg.SelectedValue}; Наименование:{cmbVideoReg.Text}");
                Logging.Comment($"Канал: {tbRegChannel.Text.Trim()}");
                Logging.Comment($"Наименование камеры: {tbCamName.Text.Trim()}");
                Logging.Comment($"IP камеры: {tbCamIP.Text.Trim()}");
                Logging.Comment($"Комментарий: {tbComment.Text.Trim()}");
                Logging.Comment($"Путь к скриншоту и имя файла: {tbPathScan.Text.Trim()}");
                Logging.StopFirstLevel();
                isSaveData = true;

            }
            else
            {
                Logging.StartFirstLevel((int)LogEvent.Редактирование_канала_видеорегистратора);
                Logging.Comment($"ID: {id}");
                Logging.VariableChange("Видеорегистратор ID", cmbVideoReg.SelectedValue, oldIdVideoReg);
                Logging.VariableChange("Видеорегистратор Наименование", cmbVideoReg.Text.Trim(), oldVideoReg);
                Logging.VariableChange("Канал", tbRegChannel.Text.Trim(), oldRegChannel);
                Logging.VariableChange("Наименование камеры", tbCamName.Text.Trim(), oldCamName);
                Logging.VariableChange("IP камеры", tbCamIP.Text.Trim(), oldCamIP);
                Logging.VariableChange("Комментарий", tbComment.Text.Trim(), oldComment);
                Logging.VariableChange("Путь к скриншоту и имя файла", tbPathScan.Text.Trim(), oldPathScan);
                Logging.StopFirstLevel();
                isClose = true;                    
            }

            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (isClose) this.DialogResult = DialogResult.OK; else ClearForm();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void cmbVideoReg_SelectionChangeCommitted(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void btFolderSelect_Click(object sender, EventArgs e)
        {
            //DialogResult result = fileBrowserDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    string folderName = fileBrowserDialog.FileName;
            //    tbPathScan.Text = folderName;
            //    img = File.ReadAllBytes(folderName);
            //}

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            //dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = false;
            dialog.Multiselect = false;
            dialog.Filters.Add(new CommonFileDialogFilter("Image files", "*.bmp;*.gif;*.jpg;*.jpeg;*.png"));            
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                //if (!validateFileAndFolder(dialog.FileName)) return;

                //btSave.Enabled = true;
                //tbPath.Text = dialog.FileName;
                string folderName = dialog.FileName;
                tbPathScan.Text = folderName;
                img = File.ReadAllBytes(folderName);
            }
        }

        private void ClearForm()
        {
            tbCamName.Text = "";
            tbRegChannel.Text = "";
            tbComment.Text = "";
            cmbVideoReg.SelectedIndex = -1;
            tbCamIP.Text = "";
            tbPathScan.Text = "";
            img = null;
            id = 0;
            isEditData = false;
        }
    }
}
