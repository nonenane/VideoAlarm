﻿using Nwuram.Framework.Logging;
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
        private string oldName, oldCode;
        private int id = 0;

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
                oldName = tbCamName.Text.Trim();

                tbCamIP.Text = (string)row["CamIP"];
                oldCode = tbCamName.Text.Trim();

                tbPathScan.Text = (string)row["PathScan"];
                tbComment.Text = (string)row["Comment"];
                tbRegChannel.Text = (string)row["RegChannel"];
                cmbVideoReg.SelectedValue = (int)row["id_VideoReg"];

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

            if (id == 0)
            {
                id = (int)dtResult.Rows[0]["id"];
                Logging.StartFirstLevel(1564);
                //Logging.Comment("Добавить Тип документа");
                Logging.Comment($"ID: {id}");
                Logging.Comment($"Наименование: {tbCamName.Text.Trim()}");
                Logging.StopFirstLevel();
            }
            else
            {
                Logging.StartFirstLevel(1565);
                //Logging.Comment("Редактировать Тип документа");
                Logging.Comment($"ID: {id}");
                Logging.VariableChange("Наименование", tbCamName.Text.Trim(), oldName);
                Logging.StopFirstLevel();
            }

            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
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
            DialogResult result = fileBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = fileBrowserDialog.FileName;
                tbPathScan.Text = folderName;
                img = File.ReadAllBytes(folderName);
            }
        }     
    }
}