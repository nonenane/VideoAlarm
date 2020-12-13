namespace VideoAlarm.ChannelVsReg
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
            this.tbCamName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPathScan = new System.Windows.Forms.TextBox();
            this.tbCamIP = new IPAddressControlLib.IPAddressControl();
            this.cmbVideoReg = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRegChannel = new System.Windows.Forms.TextBox();
            this.btFolderSelect = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbCamName
            // 
            this.tbCamName.Location = new System.Drawing.Point(141, 65);
            this.tbCamName.MaxLength = 1024;
            this.tbCamName.Name = "tbCamName";
            this.tbCamName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCamName.Size = new System.Drawing.Size(352, 20);
            this.tbCamName.TabIndex = 0;
            this.tbCamName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(9, 69);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(126, 13);
            this.lName.TabIndex = 6;
            this.lName.Text = "Наименование камеры";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP камеры";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Комментарий";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(141, 120);
            this.tbComment.MaxLength = 1024;
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(352, 80);
            this.tbComment.TabIndex = 8;
            this.tbComment.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Скриншот";
            // 
            // tbPathScan
            // 
            this.tbPathScan.Location = new System.Drawing.Point(141, 213);
            this.tbPathScan.MaxLength = 1024;
            this.tbPathScan.Name = "tbPathScan";
            this.tbPathScan.ReadOnly = true;
            this.tbPathScan.Size = new System.Drawing.Size(274, 20);
            this.tbPathScan.TabIndex = 8;
            this.tbPathScan.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbCamIP
            // 
            this.tbCamIP.AllowInternalTab = false;
            this.tbCamIP.AutoHeight = true;
            this.tbCamIP.BackColor = System.Drawing.SystemColors.Window;
            this.tbCamIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbCamIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCamIP.Location = new System.Drawing.Point(141, 94);
            this.tbCamIP.MinimumSize = new System.Drawing.Size(87, 20);
            this.tbCamIP.Name = "tbCamIP";
            this.tbCamIP.ReadOnly = false;
            this.tbCamIP.Size = new System.Drawing.Size(87, 20);
            this.tbCamIP.TabIndex = 10;
            this.tbCamIP.Text = "...";
            // 
            // cmbVideoReg
            // 
            this.cmbVideoReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVideoReg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbVideoReg.FormattingEnabled = true;
            this.cmbVideoReg.Location = new System.Drawing.Point(141, 12);
            this.cmbVideoReg.Name = "cmbVideoReg";
            this.cmbVideoReg.Size = new System.Drawing.Size(205, 21);
            this.cmbVideoReg.TabIndex = 12;
            this.cmbVideoReg.SelectionChangeCommitted += new System.EventHandler(this.cmbVideoReg_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Видеорегистратор";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Канал";
            // 
            // tbRegChannel
            // 
            this.tbRegChannel.Location = new System.Drawing.Point(141, 39);
            this.tbRegChannel.MaxLength = 1024;
            this.tbRegChannel.Name = "tbRegChannel";
            this.tbRegChannel.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRegChannel.Size = new System.Drawing.Size(352, 20);
            this.tbRegChannel.TabIndex = 13;
            // 
            // btFolderSelect
            // 
            this.btFolderSelect.Image = global::VideoAlarm.Properties.Resources.add_image;
            this.btFolderSelect.Location = new System.Drawing.Point(421, 207);
            this.btFolderSelect.Name = "btFolderSelect";
            this.btFolderSelect.Size = new System.Drawing.Size(32, 32);
            this.btFolderSelect.TabIndex = 9;
            this.btFolderSelect.Text = "...";
            this.btFolderSelect.UseVisualStyleBackColor = true;
            this.btFolderSelect.Click += new System.EventHandler(this.btFolderSelect_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::VideoAlarm.Properties.Resources.Save;
            this.btSave.Location = new System.Drawing.Point(423, 252);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 2;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::VideoAlarm.Properties.Resources.Exit;
            this.btClose.Location = new System.Drawing.Point(461, 252);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 3;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 296);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbRegChannel);
            this.Controls.Add(this.cmbVideoReg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbCamIP);
            this.Controls.Add(this.btFolderSelect);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPathScan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.tbCamName);
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
        private System.Windows.Forms.TextBox tbCamName;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPathScan;
        private System.Windows.Forms.Button btFolderSelect;
        private IPAddressControlLib.IPAddressControl tbCamIP;
        private System.Windows.Forms.ComboBox cmbVideoReg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRegChannel;
    }
}