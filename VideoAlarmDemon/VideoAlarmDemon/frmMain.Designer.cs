
namespace VideoAlarmDemon
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btUpdatePath = new System.Windows.Forms.Button();
            this.lstResultLog = new System.Windows.Forms.ListBox();
            this.lstResultBody = new System.Windows.Forms.ListBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.свернутьРазвернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cReg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btUpdatePath
            // 
            this.btUpdatePath.Image = global::VideoAlarmDemon.Properties.Resources.refresh;
            this.btUpdatePath.Location = new System.Drawing.Point(722, 12);
            this.btUpdatePath.Name = "btUpdatePath";
            this.btUpdatePath.Size = new System.Drawing.Size(66, 97);
            this.btUpdatePath.TabIndex = 0;
            this.btUpdatePath.UseVisualStyleBackColor = true;
            this.btUpdatePath.Click += new System.EventHandler(this.btUpdatePath_Click);
            // 
            // lstResultLog
            // 
            this.lstResultLog.FormattingEnabled = true;
            this.lstResultLog.Location = new System.Drawing.Point(12, 115);
            this.lstResultLog.Name = "lstResultLog";
            this.lstResultLog.Size = new System.Drawing.Size(776, 108);
            this.lstResultLog.TabIndex = 1;
            // 
            // lstResultBody
            // 
            this.lstResultBody.FormattingEnabled = true;
            this.lstResultBody.Location = new System.Drawing.Point(12, 229);
            this.lstResultBody.Name = "lstResultBody";
            this.lstResultBody.Size = new System.Drawing.Size(776, 316);
            this.lstResultBody.TabIndex = 2;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.свернутьРазвернутьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 48);
            // 
            // свернутьРазвернутьToolStripMenuItem
            // 
            this.свернутьРазвернутьToolStripMenuItem.Name = "свернутьРазвернутьToolStripMenuItem";
            this.свернутьРазвернутьToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.свернутьРазвернутьToolStripMenuItem.Text = "Свернуть/Развернуть";
            this.свернутьРазвернутьToolStripMenuItem.Click += new System.EventHandler(this.свернутьРазвернутьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cReg,
            this.cPath});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(704, 97);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // cReg
            // 
            this.cReg.Text = "Видео регистратор";
            this.cReg.Width = 200;
            // 
            // cPath
            // 
            this.cPath.Text = "Путь";
            this.cPath.Width = 480;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 555);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lstResultBody);
            this.Controls.Add(this.lstResultLog);
            this.Controls.Add(this.btUpdatePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мониторинг папок \"Видео-Тревог\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btUpdatePath;
        private System.Windows.Forms.ListBox lstResultLog;
        private System.Windows.Forms.ListBox lstResultBody;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem свернутьРазвернутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader cReg;
        private System.Windows.Forms.ColumnHeader cPath;
    }
}

