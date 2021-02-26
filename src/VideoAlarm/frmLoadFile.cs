using Microsoft.WindowsAPICodePack.Dialogs;
using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoAlarm
{
    public partial class frmLoadFile : Form
    {
        private string[] files;
        public frmLoadFile()
        {
            InitializeComponent();
            panel1.AllowDrop = true;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btClose, "Выход");
            tt.SetToolTip(btParse, "Обработать файл");
        }           
        
        private void panel1_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = false;
            dialog.Multiselect = false;
            dialog.Filters.Add(new CommonFileDialogFilter("Text files", "*.txt"));
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string folderName = dialog.FileName;
                files = new string[] { dialog.FileName };
                listBox1.Items.Add(folderName);
            }
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            label1.Text = "Перетащите файл сюда";
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                label1.Text = "Кидай сюда";
                e.Effect = DragDropEffects.All;
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            //string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            //foreach (string file in files) Console.WriteLine(file);
            listBox1.Items.Clear();
            files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                FileInfo fInfo = new FileInfo(file);

                if (fInfo.Extension.Equals(".txt"))
                    listBox1.Items.Add(file);
            }
            label1.Text = "Перетащите файл сюда \r\n" +
                "или \r\n" +
                "нажми на меня";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Pink, 3);
            pen.DashPattern = new float[] { 5, 1 };
            e.Graphics.DrawRectangle(pen, 1, 1, panel1.Width-3, panel1.Height-3 );
        }

        private void frmLoadFile_Load(object sender, EventArgs e)
        {
            Task<DataTable> task = Config.hCntMain.GetVideoRegList(false);
            task.Wait();
            DataTable dtVideoReg = task.Result;

            cmbVideoReg.DisplayMember = "RegName";
            cmbVideoReg.ValueMember = "id";
            cmbVideoReg.DataSource = dtVideoReg;
            cmbVideoReg.SelectedIndex = -1;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btParse_Click(object sender, EventArgs e)
        {
            if (cmbVideoReg.SelectedValue == null)
            {
                MessageBox.Show("Выберите регистратор!", "Выбор за тобой", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (files == null)
            {
                MessageBox.Show("Выберите файл(ы) для обработки!", "Выбор за тобой", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int id_videoreg = (int)cmbVideoReg.SelectedValue;
            string nameVideoreg = cmbVideoReg.Text;
            await Task.Run(() =>
             {
                 Config.DoOnUIThread(() => { this.Enabled = false; }, this);
                 VideoAlarmDemon.ParseFileAlarmVideo pa = new VideoAlarmDemon.ParseFileAlarmVideo();
                 Logging.StartFirstLevel(823);
                 foreach (string file in files)
                 {
                     if (File.Exists(file))
                     {
                         Logging.Comment($"Видеорегистратор [ID:{id_videoreg}; Наименование:{nameVideoreg}] Файл:[Наименование:{file}]");
                         VideoAlarmDemon.ListFile lFile = new VideoAlarmDemon.ListFile();
                         lFile.file = file;
                         lFile.idReg = id_videoreg;
                         lFile.Path = new FileInfo(file).Directory.FullName;
                         pa.InsertDataToDataTable(lFile, true);
                     }
                 }
                 Logging.StopFirstLevel();
                 Config.DoOnUIThread(() => { this.Enabled = true; MessageBox.Show("Ну всё, мы закончили!", "Это было приятно!", MessageBoxButtons.OK, MessageBoxIcon.Information);}, this);

             });
        }
    }
}
