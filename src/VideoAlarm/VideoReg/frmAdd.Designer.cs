namespace VideoAlarm.VideoReg
{
    partial class frmAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdd));
            this.tbRegName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPlace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPathLog = new System.Windows.Forms.TextBox();
            this.btFolderSelect = new System.Windows.Forms.Button();
            this.tbRegIP = new IPAddressControlLib.IPAddressControl();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbShop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbRegName
            // 
            this.tbRegName.Location = new System.Drawing.Point(120, 6);
            this.tbRegName.MaxLength = 1024;
            this.tbRegName.Name = "tbRegName";
            this.tbRegName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRegName.Size = new System.Drawing.Size(376, 20);
            this.tbRegName.TabIndex = 0;
            this.tbRegName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(12, 10);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(83, 13);
            this.lName.TabIndex = 6;
            this.lName.Text = "Наименование";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP";
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::VideoAlarm.Properties.Resources.Save;
            this.btSave.Location = new System.Drawing.Point(423, 241);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 6;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::VideoAlarm.Properties.Resources.Exit;
            this.btClose.Location = new System.Drawing.Point(461, 241);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 7;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Местоположение";
            // 
            // tbPlace
            // 
            this.tbPlace.Location = new System.Drawing.Point(120, 89);
            this.tbPlace.MaxLength = 1024;
            this.tbPlace.Name = "tbPlace";
            this.tbPlace.Size = new System.Drawing.Size(376, 20);
            this.tbPlace.TabIndex = 3;
            this.tbPlace.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Комментарий";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(120, 115);
            this.tbComment.MaxLength = 1024;
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(376, 80);
            this.tbComment.TabIndex = 4;
            this.tbComment.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Путь к лог файлам";
            // 
            // tbPathLog
            // 
            this.tbPathLog.Location = new System.Drawing.Point(120, 205);
            this.tbPathLog.MaxLength = 1024;
            this.tbPathLog.Name = "tbPathLog";
            this.tbPathLog.ReadOnly = true;
            this.tbPathLog.Size = new System.Drawing.Size(295, 20);
            this.tbPathLog.TabIndex = 8;
            this.tbPathLog.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            this.tbPathLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPathLog_KeyDown);
            // 
            // btFolderSelect
            // 
            this.btFolderSelect.Location = new System.Drawing.Point(421, 204);
            this.btFolderSelect.Name = "btFolderSelect";
            this.btFolderSelect.Size = new System.Drawing.Size(75, 23);
            this.btFolderSelect.TabIndex = 5;
            this.btFolderSelect.Text = "...";
            this.btFolderSelect.UseVisualStyleBackColor = true;
            this.btFolderSelect.Click += new System.EventHandler(this.btFolderSelect_Click);
            // 
            // tbRegIP
            // 
            this.tbRegIP.AllowInternalTab = false;
            this.tbRegIP.AutoHeight = true;
            this.tbRegIP.BackColor = System.Drawing.SystemColors.Window;
            this.tbRegIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbRegIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbRegIP.Location = new System.Drawing.Point(120, 34);
            this.tbRegIP.MinimumSize = new System.Drawing.Size(87, 20);
            this.tbRegIP.Name = "tbRegIP";
            this.tbRegIP.ReadOnly = false;
            this.tbRegIP.Size = new System.Drawing.Size(87, 20);
            this.tbRegIP.TabIndex = 1;
            this.tbRegIP.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Магазин:";
            // 
            // cmbShop
            // 
            this.cmbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShop.FormattingEnabled = true;
            this.cmbShop.Location = new System.Drawing.Point(120, 62);
            this.cmbShop.Name = "cmbShop";
            this.cmbShop.Size = new System.Drawing.Size(87, 21);
            this.cmbShop.TabIndex = 2;
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 285);
            this.Controls.Add(this.cmbShop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbRegIP);
            this.Controls.Add(this.btFolderSelect);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPathLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPlace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.tbRegName);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdd_FormClosing);
            this.Load += new System.EventHandler(this.frmAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox tbRegName;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPlace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPathLog;
        private System.Windows.Forms.Button btFolderSelect;
        private IPAddressControlLib.IPAddressControl tbRegIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbShop;
    }
}