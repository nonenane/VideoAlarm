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
        private DataTable dtData;
        FolderBrowserDialog folderBrowserDialog1;


        public frmMain()
        {
            InitializeComponent();

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
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            this.folderBrowserDialog1.Description = "Выберите каталог, для сохранения файлов CSV.";

            // Do not allow the user to create new files via the FolderBrowserDialog.
            this.folderBrowserDialog1.ShowNewFolderButton = true;

            // Default to the My Documents folder.
            this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            //if (UserSettings.User.StatusCode == "РКВ") настройкиПроцентовToolStripMenuItem.Visible = false;
            //if (UserSettings.User.StatusCode.ToLower() == "пр")

        }

        private void frnMain_Load(object sender, EventArgs e)
        {

        }

        private void frnMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show(Config.centralText("Вы действительно хотите выйти\nиз программы?\n"), "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No;
        }

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
    }
}
