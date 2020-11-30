namespace VideoAlarm.ChannelVsReg
{
    partial class frmList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmList));
            this.tbChannel = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cRegName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRegChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameCam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chbNotActive = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbNameCam = new System.Windows.Forms.TextBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFio = new System.Windows.Forms.TextBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.cmbVideoReg = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btViewScreenShot = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // tbChannel
            // 
            this.tbChannel.Location = new System.Drawing.Point(12, 50);
            this.tbChannel.Name = "tbChannel";
            this.tbChannel.Size = new System.Drawing.Size(121, 20);
            this.tbChannel.TabIndex = 0;
            this.tbChannel.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cRegName,
            this.cIP,
            this.cRegChannel,
            this.cNameCam,
            this.cComment,
            this.cScan});
            this.dgvData.Location = new System.Drawing.Point(12, 76);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(958, 410);
            this.dgvData.TabIndex = 1;
            this.dgvData.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvData_ColumnWidthChanged);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // cRegName
            // 
            this.cRegName.DataPropertyName = "RegName";
            this.cRegName.HeaderText = "Видеорегистратор";
            this.cRegName.Name = "cRegName";
            this.cRegName.ReadOnly = true;
            // 
            // cIP
            // 
            this.cIP.DataPropertyName = "CamIP";
            this.cIP.HeaderText = "IP";
            this.cIP.Name = "cIP";
            this.cIP.ReadOnly = true;
            // 
            // cRegChannel
            // 
            this.cRegChannel.DataPropertyName = "RegChannel";
            this.cRegChannel.HeaderText = "Канал";
            this.cRegChannel.Name = "cRegChannel";
            this.cRegChannel.ReadOnly = true;
            // 
            // cNameCam
            // 
            this.cNameCam.DataPropertyName = "CamName";
            this.cNameCam.HeaderText = "Наименование камеры";
            this.cNameCam.Name = "cNameCam";
            this.cNameCam.ReadOnly = true;
            // 
            // cComment
            // 
            this.cComment.DataPropertyName = "Comment";
            this.cComment.HeaderText = "Комментарий";
            this.cComment.Name = "cComment";
            this.cComment.ReadOnly = true;
            // 
            // cScan
            // 
            this.cScan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cScan.DataPropertyName = "isScan";
            this.cScan.HeaderText = "Скриншот";
            this.cScan.MinimumWidth = 80;
            this.cScan.Name = "cScan";
            this.cScan.ReadOnly = true;
            this.cScan.Width = 80;
            // 
            // chbNotActive
            // 
            this.chbNotActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbNotActive.AutoSize = true;
            this.chbNotActive.Location = new System.Drawing.Point(39, 509);
            this.chbNotActive.Name = "chbNotActive";
            this.chbNotActive.Size = new System.Drawing.Size(113, 17);
            this.chbNotActive.TabIndex = 2;
            this.chbNotActive.Text = "- недействующие";
            this.chbNotActive.UseVisualStyleBackColor = true;
            this.chbNotActive.CheckedChanged += new System.EventHandler(this.chbNotActive_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 507);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(21, 21);
            this.panel1.TabIndex = 3;
            // 
            // tbNameCam
            // 
            this.tbNameCam.Location = new System.Drawing.Point(139, 50);
            this.tbNameCam.Name = "tbNameCam";
            this.tbNameCam.Size = new System.Drawing.Size(121, 20);
            this.tbNameCam.TabIndex = 0;
            this.tbNameCam.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(270, 50);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(121, 20);
            this.tbComment.TabIndex = 0;
            this.tbComment.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Редактировал";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 517);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дата редактир.";
            // 
            // tbFio
            // 
            this.tbFio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbFio.Location = new System.Drawing.Point(270, 492);
            this.tbFio.Name = "tbFio";
            this.tbFio.ReadOnly = true;
            this.tbFio.Size = new System.Drawing.Size(178, 20);
            this.tbFio.TabIndex = 6;
            // 
            // tbDate
            // 
            this.tbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbDate.Location = new System.Drawing.Point(270, 513);
            this.tbDate.Name = "tbDate";
            this.tbDate.ReadOnly = true;
            this.tbDate.Size = new System.Drawing.Size(178, 20);
            this.tbDate.TabIndex = 6;
            // 
            // cmbVideoReg
            // 
            this.cmbVideoReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVideoReg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbVideoReg.FormattingEnabled = true;
            this.cmbVideoReg.Location = new System.Drawing.Point(122, 12);
            this.cmbVideoReg.Name = "cmbVideoReg";
            this.cmbVideoReg.Size = new System.Drawing.Size(229, 21);
            this.cmbVideoReg.TabIndex = 10;
            this.cmbVideoReg.SelectionChangeCommitted += new System.EventHandler(this.cmbVideoReg_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Видеорегистратор";
            // 
            // btViewScreenShot
            // 
            this.btViewScreenShot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btViewScreenShot.Image = global::VideoAlarm.Properties.Resources.view;
            this.btViewScreenShot.Location = new System.Drawing.Point(786, 501);
            this.btViewScreenShot.Name = "btViewScreenShot";
            this.btViewScreenShot.Size = new System.Drawing.Size(32, 32);
            this.btViewScreenShot.TabIndex = 11;
            this.btViewScreenShot.UseVisualStyleBackColor = true;
            this.btViewScreenShot.Click += new System.EventHandler(this.btViewScreenShot_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::VideoAlarm.Properties.Resources.Add;
            this.btAdd.Location = new System.Drawing.Point(824, 501);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 4;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Image = global::VideoAlarm.Properties.Resources.Edit;
            this.btEdit.Location = new System.Drawing.Point(862, 501);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(32, 32);
            this.btEdit.TabIndex = 4;
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Image = global::VideoAlarm.Properties.Resources.Trash;
            this.btDelete.Location = new System.Drawing.Point(900, 501);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(32, 32);
            this.btDelete.TabIndex = 4;
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::VideoAlarm.Properties.Resources.Exit;
            this.btClose.Location = new System.Drawing.Point(938, 501);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 4;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 545);
            this.Controls.Add(this.btViewScreenShot);
            this.Controls.Add(this.cmbVideoReg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.tbFio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chbNotActive);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.tbNameCam);
            this.Controls.Add(this.tbChannel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник каналов видеорегистраторов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmList_FormClosing);
            this.Load += new System.EventHandler(this.frmList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbChannel;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.CheckBox chbNotActive;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbNameCam;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFio;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.ComboBox cmbVideoReg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btViewScreenShot;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRegName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRegChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameCam;
        private System.Windows.Forms.DataGridViewTextBoxColumn cComment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cScan;
    }
}