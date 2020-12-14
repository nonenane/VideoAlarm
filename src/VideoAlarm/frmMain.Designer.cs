namespace VideoAlarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникВидеорегистраторовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникОтветственныхСотрудниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникКаналовВидеорегистраторовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расписаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpAlarm = new System.Windows.Forms.TabPage();
            this.tbAlarmDelta = new System.Windows.Forms.TextBox();
            this.btAlarmDropDelta = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbAlarmTime = new System.Windows.Forms.CheckBox();
            this.dtpAlarmTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpAlarmTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.btAlarmComment = new System.Windows.Forms.Button();
            this.btAlarmUpdatre = new System.Windows.Forms.Button();
            this.cmbAlarmTypeEvent = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbAlarmCameraVsChannel = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbAlarmVideoReg = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pAlarmLegend = new System.Windows.Forms.Panel();
            this.dgvAlarm = new System.Windows.Forms.DataGridView();
            this.tbAlarmChannel = new System.Windows.Forms.TextBox();
            this.tbAlarmNameCam = new System.Windows.Forms.TextBox();
            this.tbAlarmComment = new System.Windows.Forms.TextBox();
            this.tbAlarmResponsible = new System.Windows.Forms.TextBox();
            this.dtpAlarmEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpAlarmStart = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tpReport = new System.Windows.Forms.TabPage();
            this.btReportComment = new System.Windows.Forms.Button();
            this.btReportUpdate = new System.Windows.Forms.Button();
            this.cmbReportVideoReg = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.cReportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReportVideoReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReportTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReportDelta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReportRealTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReportComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReportResponsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReportSing = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbReportComment = new System.Windows.Forms.TextBox();
            this.tbReportResponsible = new System.Windows.Forms.TextBox();
            this.dtpReportEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpReportStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cAlarmVideoReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAlarmChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAlarmNameCam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAlarmTypeEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAlarmDateStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAlarmDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAlarmLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAlarmResponcible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAlarmComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpAlarm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).BeginInit();
            this.tpReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1041, 22);
            this.statusStrip1.TabIndex = 39;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLabel
            // 
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Size = new System.Drawing.Size(109, 17);
            this.tsLabel.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.выходToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1041, 24);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникВидеорегистраторовToolStripMenuItem,
            this.справочникОтветственныхСотрудниковToolStripMenuItem,
            this.справочникКаналовВидеорегистраторовToolStripMenuItem,
            this.расписаниеToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // справочникВидеорегистраторовToolStripMenuItem
            // 
            this.справочникВидеорегистраторовToolStripMenuItem.Name = "справочникВидеорегистраторовToolStripMenuItem";
            this.справочникВидеорегистраторовToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.справочникВидеорегистраторовToolStripMenuItem.Text = "Справочник видеорегистраторов";
            this.справочникВидеорегистраторовToolStripMenuItem.Click += new System.EventHandler(this.справочникВидеорегистраторовToolStripMenuItem_Click);
            // 
            // справочникОтветственныхСотрудниковToolStripMenuItem
            // 
            this.справочникОтветственныхСотрудниковToolStripMenuItem.Name = "справочникОтветственныхСотрудниковToolStripMenuItem";
            this.справочникОтветственныхСотрудниковToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.справочникОтветственныхСотрудниковToolStripMenuItem.Text = "Справочник ответственных сотрудников";
            this.справочникОтветственныхСотрудниковToolStripMenuItem.Click += new System.EventHandler(this.справочникОтветственныхСотрудниковToolStripMenuItem_Click);
            // 
            // справочникКаналовВидеорегистраторовToolStripMenuItem
            // 
            this.справочникКаналовВидеорегистраторовToolStripMenuItem.Name = "справочникКаналовВидеорегистраторовToolStripMenuItem";
            this.справочникКаналовВидеорегистраторовToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.справочникКаналовВидеорегистраторовToolStripMenuItem.Text = "Справочник каналов видеорегистраторов";
            this.справочникКаналовВидеорегистраторовToolStripMenuItem.Click += new System.EventHandler(this.справочникКаналовВидеорегистраторовToolStripMenuItem_Click);
            // 
            // расписаниеToolStripMenuItem
            // 
            this.расписаниеToolStripMenuItem.Name = "расписаниеToolStripMenuItem";
            this.расписаниеToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.расписаниеToolStripMenuItem.Text = "Расписание";
            this.расписаниеToolStripMenuItem.Click += new System.EventHandler(this.расписаниеToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpAlarm);
            this.tabControl1.Controls.Add(this.tpReport);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1041, 510);
            this.tabControl1.TabIndex = 41;
            // 
            // tpAlarm
            // 
            this.tpAlarm.Controls.Add(this.tbAlarmDelta);
            this.tpAlarm.Controls.Add(this.btAlarmDropDelta);
            this.tpAlarm.Controls.Add(this.groupBox1);
            this.tpAlarm.Controls.Add(this.btAlarmComment);
            this.tpAlarm.Controls.Add(this.btAlarmUpdatre);
            this.tpAlarm.Controls.Add(this.cmbAlarmTypeEvent);
            this.tpAlarm.Controls.Add(this.label10);
            this.tpAlarm.Controls.Add(this.cmbAlarmCameraVsChannel);
            this.tpAlarm.Controls.Add(this.label11);
            this.tpAlarm.Controls.Add(this.label9);
            this.tpAlarm.Controls.Add(this.cmbAlarmVideoReg);
            this.tpAlarm.Controls.Add(this.label5);
            this.tpAlarm.Controls.Add(this.pAlarmLegend);
            this.tpAlarm.Controls.Add(this.dgvAlarm);
            this.tpAlarm.Controls.Add(this.tbAlarmChannel);
            this.tpAlarm.Controls.Add(this.tbAlarmNameCam);
            this.tpAlarm.Controls.Add(this.tbAlarmComment);
            this.tpAlarm.Controls.Add(this.tbAlarmResponsible);
            this.tpAlarm.Controls.Add(this.dtpAlarmEnd);
            this.tpAlarm.Controls.Add(this.label6);
            this.tpAlarm.Controls.Add(this.dtpAlarmStart);
            this.tpAlarm.Controls.Add(this.label7);
            this.tpAlarm.Controls.Add(this.label8);
            this.tpAlarm.Location = new System.Drawing.Point(4, 22);
            this.tpAlarm.Name = "tpAlarm";
            this.tpAlarm.Padding = new System.Windows.Forms.Padding(3);
            this.tpAlarm.Size = new System.Drawing.Size(1033, 484);
            this.tpAlarm.TabIndex = 0;
            this.tpAlarm.Text = "Тревога";
            this.tpAlarm.UseVisualStyleBackColor = true;
            // 
            // tbAlarmDelta
            // 
            this.tbAlarmDelta.Location = new System.Drawing.Point(445, 71);
            this.tbAlarmDelta.MaxLength = 5;
            this.tbAlarmDelta.Name = "tbAlarmDelta";
            this.tbAlarmDelta.Size = new System.Drawing.Size(49, 20);
            this.tbAlarmDelta.TabIndex = 36;
            this.tbAlarmDelta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAlarmDelta_KeyPress);
            this.tbAlarmDelta.Leave += new System.EventHandler(this.tbAlarmDelta_Leave);
            // 
            // btAlarmDropDelta
            // 
            this.btAlarmDropDelta.Location = new System.Drawing.Point(537, 71);
            this.btAlarmDropDelta.Name = "btAlarmDropDelta";
            this.btAlarmDropDelta.Size = new System.Drawing.Size(20, 20);
            this.btAlarmDropDelta.TabIndex = 35;
            this.btAlarmDropDelta.UseVisualStyleBackColor = true;
            this.btAlarmDropDelta.Click += new System.EventHandler(this.btAlarmDropDelta_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbAlarmTime);
            this.groupBox1.Controls.Add(this.dtpAlarmTimeEnd);
            this.groupBox1.Controls.Add(this.dtpAlarmTimeStart);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(623, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 57);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтрация по времени";
            // 
            // chbAlarmTime
            // 
            this.chbAlarmTime.AutoSize = true;
            this.chbAlarmTime.Location = new System.Drawing.Point(6, 27);
            this.chbAlarmTime.Name = "chbAlarmTime";
            this.chbAlarmTime.Size = new System.Drawing.Size(68, 17);
            this.chbAlarmTime.TabIndex = 0;
            this.chbAlarmTime.Text = "Время с";
            this.chbAlarmTime.UseVisualStyleBackColor = true;
            this.chbAlarmTime.Click += new System.EventHandler(this.chbAlarmTime_Click);
            // 
            // dtpAlarmTimeEnd
            // 
            this.dtpAlarmTimeEnd.CustomFormat = "HH:mm";
            this.dtpAlarmTimeEnd.Enabled = false;
            this.dtpAlarmTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAlarmTimeEnd.Location = new System.Drawing.Point(176, 25);
            this.dtpAlarmTimeEnd.Name = "dtpAlarmTimeEnd";
            this.dtpAlarmTimeEnd.ShowUpDown = true;
            this.dtpAlarmTimeEnd.Size = new System.Drawing.Size(53, 20);
            this.dtpAlarmTimeEnd.TabIndex = 24;
            this.dtpAlarmTimeEnd.Value = new System.DateTime(2020, 12, 2, 20, 0, 0, 0);
            this.dtpAlarmTimeEnd.ValueChanged += new System.EventHandler(this.dtpAlarmTimeStart_ValueChanged);
            // 
            // dtpAlarmTimeStart
            // 
            this.dtpAlarmTimeStart.CustomFormat = "HH:mm";
            this.dtpAlarmTimeStart.Enabled = false;
            this.dtpAlarmTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAlarmTimeStart.Location = new System.Drawing.Point(84, 25);
            this.dtpAlarmTimeStart.Name = "dtpAlarmTimeStart";
            this.dtpAlarmTimeStart.ShowUpDown = true;
            this.dtpAlarmTimeStart.Size = new System.Drawing.Size(53, 20);
            this.dtpAlarmTimeStart.TabIndex = 24;
            this.dtpAlarmTimeStart.Value = new System.DateTime(2020, 12, 2, 8, 0, 0, 0);
            this.dtpAlarmTimeStart.ValueChanged += new System.EventHandler(this.dtpAlarmTimeStart_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(147, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "по";
            // 
            // btAlarmComment
            // 
            this.btAlarmComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAlarmComment.Enabled = false;
            this.btAlarmComment.Image = ((System.Drawing.Image)(resources.GetObject("btAlarmComment.Image")));
            this.btAlarmComment.Location = new System.Drawing.Point(993, 444);
            this.btAlarmComment.Name = "btAlarmComment";
            this.btAlarmComment.Size = new System.Drawing.Size(32, 32);
            this.btAlarmComment.TabIndex = 33;
            this.btAlarmComment.UseVisualStyleBackColor = true;
            this.btAlarmComment.Click += new System.EventHandler(this.btAlarmComment_Click);
            // 
            // btAlarmUpdatre
            // 
            this.btAlarmUpdatre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAlarmUpdatre.Image = global::VideoAlarm.Properties.Resources.refresh;
            this.btAlarmUpdatre.Location = new System.Drawing.Point(993, 9);
            this.btAlarmUpdatre.Name = "btAlarmUpdatre";
            this.btAlarmUpdatre.Size = new System.Drawing.Size(32, 32);
            this.btAlarmUpdatre.TabIndex = 32;
            this.btAlarmUpdatre.UseVisualStyleBackColor = true;
            this.btAlarmUpdatre.Click += new System.EventHandler(this.btAlarmUpdatre_Click);
            // 
            // cmbAlarmTypeEvent
            // 
            this.cmbAlarmTypeEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlarmTypeEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbAlarmTypeEvent.FormattingEnabled = true;
            this.cmbAlarmTypeEvent.Location = new System.Drawing.Point(445, 44);
            this.cmbAlarmTypeEvent.Name = "cmbAlarmTypeEvent";
            this.cmbAlarmTypeEvent.Size = new System.Drawing.Size(112, 21);
            this.cmbAlarmTypeEvent.TabIndex = 31;
            this.cmbAlarmTypeEvent.SelectionChangeCommitted += new System.EventHandler(this.cmbAlarmVideoReg_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(367, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Тип события";
            // 
            // cmbAlarmCameraVsChannel
            // 
            this.cmbAlarmCameraVsChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlarmCameraVsChannel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbAlarmCameraVsChannel.FormattingEnabled = true;
            this.cmbAlarmCameraVsChannel.Location = new System.Drawing.Point(124, 71);
            this.cmbAlarmCameraVsChannel.Name = "cmbAlarmCameraVsChannel";
            this.cmbAlarmCameraVsChannel.Size = new System.Drawing.Size(229, 21);
            this.cmbAlarmCameraVsChannel.TabIndex = 31;
            this.cmbAlarmCameraVsChannel.SelectionChangeCommitted += new System.EventHandler(this.cmbAlarmVideoReg_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(367, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Дельта";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Канал/Камера";
            // 
            // cmbAlarmVideoReg
            // 
            this.cmbAlarmVideoReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlarmVideoReg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbAlarmVideoReg.FormattingEnabled = true;
            this.cmbAlarmVideoReg.Location = new System.Drawing.Point(124, 44);
            this.cmbAlarmVideoReg.Name = "cmbAlarmVideoReg";
            this.cmbAlarmVideoReg.Size = new System.Drawing.Size(229, 21);
            this.cmbAlarmVideoReg.TabIndex = 31;
            this.cmbAlarmVideoReg.SelectionChangeCommitted += new System.EventHandler(this.cmbAlarmVideoReg_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Видеорегистратор";
            // 
            // pAlarmLegend
            // 
            this.pAlarmLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pAlarmLegend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.pAlarmLegend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAlarmLegend.Location = new System.Drawing.Point(20, 444);
            this.pAlarmLegend.Name = "pAlarmLegend";
            this.pAlarmLegend.Size = new System.Drawing.Size(21, 21);
            this.pAlarmLegend.TabIndex = 29;
            // 
            // dgvAlarm
            // 
            this.dgvAlarm.AllowUserToAddRows = false;
            this.dgvAlarm.AllowUserToDeleteRows = false;
            this.dgvAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlarm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlarm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cAlarmVideoReg,
            this.cAlarmChannel,
            this.cAlarmNameCam,
            this.cAlarmTypeEvent,
            this.cAlarmDateStart,
            this.cAlarmDateEnd,
            this.cAlarmLimit,
            this.cAlarmResponcible,
            this.cAlarmComment});
            this.dgvAlarm.Location = new System.Drawing.Point(8, 133);
            this.dgvAlarm.MultiSelect = false;
            this.dgvAlarm.Name = "dgvAlarm";
            this.dgvAlarm.ReadOnly = true;
            this.dgvAlarm.RowHeadersVisible = false;
            this.dgvAlarm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlarm.Size = new System.Drawing.Size(1017, 305);
            this.dgvAlarm.TabIndex = 28;
            this.dgvAlarm.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvAlarm_ColumnWidthChanged);
            this.dgvAlarm.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvAlarm_RowPostPaint);
            this.dgvAlarm.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvAlarm_RowPrePaint);
            // 
            // tbAlarmChannel
            // 
            this.tbAlarmChannel.Location = new System.Drawing.Point(128, 107);
            this.tbAlarmChannel.Name = "tbAlarmChannel";
            this.tbAlarmChannel.Size = new System.Drawing.Size(121, 20);
            this.tbAlarmChannel.TabIndex = 26;
            this.tbAlarmChannel.TextChanged += new System.EventHandler(this.tbAlarmChannel_TextChanged);
            // 
            // tbAlarmNameCam
            // 
            this.tbAlarmNameCam.Location = new System.Drawing.Point(255, 107);
            this.tbAlarmNameCam.Name = "tbAlarmNameCam";
            this.tbAlarmNameCam.Size = new System.Drawing.Size(121, 20);
            this.tbAlarmNameCam.TabIndex = 27;
            this.tbAlarmNameCam.TextChanged += new System.EventHandler(this.tbAlarmChannel_TextChanged);
            // 
            // tbAlarmComment
            // 
            this.tbAlarmComment.Location = new System.Drawing.Point(639, 107);
            this.tbAlarmComment.Name = "tbAlarmComment";
            this.tbAlarmComment.Size = new System.Drawing.Size(121, 20);
            this.tbAlarmComment.TabIndex = 26;
            this.tbAlarmComment.TextChanged += new System.EventHandler(this.tbAlarmChannel_TextChanged);
            // 
            // tbAlarmResponsible
            // 
            this.tbAlarmResponsible.Location = new System.Drawing.Point(766, 107);
            this.tbAlarmResponsible.Name = "tbAlarmResponsible";
            this.tbAlarmResponsible.Size = new System.Drawing.Size(121, 20);
            this.tbAlarmResponsible.TabIndex = 27;
            this.tbAlarmResponsible.TextChanged += new System.EventHandler(this.tbAlarmChannel_TextChanged);
            // 
            // dtpAlarmEnd
            // 
            this.dtpAlarmEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAlarmEnd.Location = new System.Drawing.Point(208, 16);
            this.dtpAlarmEnd.Name = "dtpAlarmEnd";
            this.dtpAlarmEnd.Size = new System.Drawing.Size(102, 20);
            this.dtpAlarmEnd.TabIndex = 24;
            this.dtpAlarmEnd.CloseUp += new System.EventHandler(this.dtpAlarmStart_CloseUp);
            this.dtpAlarmEnd.ValueChanged += new System.EventHandler(this.dtpAlarmEnd_ValueChanged);
            this.dtpAlarmEnd.Leave += new System.EventHandler(this.dtpAlarmEnd_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "по";
            // 
            // dtpAlarmStart
            // 
            this.dtpAlarmStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAlarmStart.Location = new System.Drawing.Point(75, 16);
            this.dtpAlarmStart.Name = "dtpAlarmStart";
            this.dtpAlarmStart.Size = new System.Drawing.Size(102, 20);
            this.dtpAlarmStart.TabIndex = 25;
            this.dtpAlarmStart.CloseUp += new System.EventHandler(this.dtpAlarmStart_CloseUp);
            this.dtpAlarmStart.ValueChanged += new System.EventHandler(this.dtpAlarmStart_ValueChanged);
            this.dtpAlarmStart.Leave += new System.EventHandler(this.dtpAlarmEnd_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 448);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "проблема не решена";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Период с";
            // 
            // tpReport
            // 
            this.tpReport.Controls.Add(this.btReportComment);
            this.tpReport.Controls.Add(this.btReportUpdate);
            this.tpReport.Controls.Add(this.cmbReportVideoReg);
            this.tpReport.Controls.Add(this.label3);
            this.tpReport.Controls.Add(this.panel1);
            this.tpReport.Controls.Add(this.dgvReport);
            this.tpReport.Controls.Add(this.tbReportComment);
            this.tpReport.Controls.Add(this.tbReportResponsible);
            this.tpReport.Controls.Add(this.dtpReportEnd);
            this.tpReport.Controls.Add(this.label2);
            this.tpReport.Controls.Add(this.dtpReportStart);
            this.tpReport.Controls.Add(this.label4);
            this.tpReport.Controls.Add(this.label1);
            this.tpReport.Location = new System.Drawing.Point(4, 22);
            this.tpReport.Name = "tpReport";
            this.tpReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpReport.Size = new System.Drawing.Size(1033, 484);
            this.tpReport.TabIndex = 1;
            this.tpReport.Text = "Отчёт";
            this.tpReport.UseVisualStyleBackColor = true;
            // 
            // btReportComment
            // 
            this.btReportComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btReportComment.Enabled = false;
            this.btReportComment.Image = ((System.Drawing.Image)(resources.GetObject("btReportComment.Image")));
            this.btReportComment.Location = new System.Drawing.Point(993, 445);
            this.btReportComment.Name = "btReportComment";
            this.btReportComment.Size = new System.Drawing.Size(32, 32);
            this.btReportComment.TabIndex = 20;
            this.btReportComment.UseVisualStyleBackColor = true;
            this.btReportComment.Click += new System.EventHandler(this.btReportComment_Click);
            // 
            // btReportUpdate
            // 
            this.btReportUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btReportUpdate.Image = global::VideoAlarm.Properties.Resources.refresh;
            this.btReportUpdate.Location = new System.Drawing.Point(993, 10);
            this.btReportUpdate.Name = "btReportUpdate";
            this.btReportUpdate.Size = new System.Drawing.Size(32, 32);
            this.btReportUpdate.TabIndex = 19;
            this.btReportUpdate.UseVisualStyleBackColor = true;
            this.btReportUpdate.Click += new System.EventHandler(this.btReportUpdate_Click);
            // 
            // cmbReportVideoReg
            // 
            this.cmbReportVideoReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportVideoReg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbReportVideoReg.FormattingEnabled = true;
            this.cmbReportVideoReg.Location = new System.Drawing.Point(426, 17);
            this.cmbReportVideoReg.Name = "cmbReportVideoReg";
            this.cmbReportVideoReg.Size = new System.Drawing.Size(229, 21);
            this.cmbReportVideoReg.TabIndex = 18;
            this.cmbReportVideoReg.SelectionChangeCommitted += new System.EventHandler(this.cmbReportVideoReg_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Видеорегистратор";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(20, 445);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(21, 21);
            this.panel1.TabIndex = 16;
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AllowUserToResizeRows = false;
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cReportDate,
            this.cReportVideoReg,
            this.cReportTime,
            this.cReportDelta,
            this.cReportRealTime,
            this.cReportComment,
            this.cReportResponsible,
            this.cReportSing});
            this.dgvReport.Location = new System.Drawing.Point(8, 70);
            this.dgvReport.MultiSelect = false;
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(1017, 369);
            this.dgvReport.TabIndex = 14;
            this.dgvReport.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvReport_ColumnWidthChanged);
            this.dgvReport.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvReport_RowPostPaint);
            this.dgvReport.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvReport_RowPrePaint);
            // 
            // cReportDate
            // 
            this.cReportDate.DataPropertyName = "DateCreate";
            this.cReportDate.HeaderText = "Дата";
            this.cReportDate.Name = "cReportDate";
            this.cReportDate.ReadOnly = true;
            // 
            // cReportVideoReg
            // 
            this.cReportVideoReg.DataPropertyName = "RegName";
            this.cReportVideoReg.HeaderText = "Видеорегистратор";
            this.cReportVideoReg.Name = "cReportVideoReg";
            this.cReportVideoReg.ReadOnly = true;
            // 
            // cReportTime
            // 
            this.cReportTime.DataPropertyName = "DateCreate";
            this.cReportTime.HeaderText = "Время";
            this.cReportTime.Name = "cReportTime";
            this.cReportTime.ReadOnly = true;
            // 
            // cReportDelta
            // 
            this.cReportDelta.DataPropertyName = "Delta";
            this.cReportDelta.HeaderText = "+/-";
            this.cReportDelta.Name = "cReportDelta";
            this.cReportDelta.ReadOnly = true;
            // 
            // cReportRealTime
            // 
            this.cReportRealTime.DataPropertyName = "DateCreate";
            this.cReportRealTime.HeaderText = "Фактическое время";
            this.cReportRealTime.Name = "cReportRealTime";
            this.cReportRealTime.ReadOnly = true;
            // 
            // cReportComment
            // 
            this.cReportComment.DataPropertyName = "Comment";
            this.cReportComment.HeaderText = "Комментарий";
            this.cReportComment.Name = "cReportComment";
            this.cReportComment.ReadOnly = true;
            // 
            // cReportResponsible
            // 
            this.cReportResponsible.DataPropertyName = "nameResponsible";
            this.cReportResponsible.HeaderText = "Ответственный";
            this.cReportResponsible.Name = "cReportResponsible";
            this.cReportResponsible.ReadOnly = true;
            // 
            // cReportSing
            // 
            this.cReportSing.DataPropertyName = "isNoAlarm";
            this.cReportSing.HeaderText = "Признак";
            this.cReportSing.Name = "cReportSing";
            this.cReportSing.ReadOnly = true;
            this.cReportSing.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cReportSing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tbReportComment
            // 
            this.tbReportComment.Location = new System.Drawing.Point(20, 43);
            this.tbReportComment.Name = "tbReportComment";
            this.tbReportComment.Size = new System.Drawing.Size(121, 20);
            this.tbReportComment.TabIndex = 11;
            this.tbReportComment.TextChanged += new System.EventHandler(this.tbReportComment_TextChanged);
            // 
            // tbReportResponsible
            // 
            this.tbReportResponsible.Location = new System.Drawing.Point(147, 44);
            this.tbReportResponsible.Name = "tbReportResponsible";
            this.tbReportResponsible.Size = new System.Drawing.Size(121, 20);
            this.tbReportResponsible.TabIndex = 12;
            this.tbReportResponsible.TextChanged += new System.EventHandler(this.tbReportComment_TextChanged);
            // 
            // dtpReportEnd
            // 
            this.dtpReportEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReportEnd.Location = new System.Drawing.Point(208, 17);
            this.dtpReportEnd.Name = "dtpReportEnd";
            this.dtpReportEnd.Size = new System.Drawing.Size(102, 20);
            this.dtpReportEnd.TabIndex = 1;
            this.dtpReportEnd.CloseUp += new System.EventHandler(this.dtpReportStart_CloseUp);
            this.dtpReportEnd.ValueChanged += new System.EventHandler(this.dtpReportEnd_ValueChanged);
            this.dtpReportEnd.Leave += new System.EventHandler(this.dtpReportStart_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "по";
            // 
            // dtpReportStart
            // 
            this.dtpReportStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReportStart.Location = new System.Drawing.Point(75, 17);
            this.dtpReportStart.Name = "dtpReportStart";
            this.dtpReportStart.Size = new System.Drawing.Size(102, 20);
            this.dtpReportStart.TabIndex = 1;
            this.dtpReportStart.CloseUp += new System.EventHandler(this.dtpReportStart_CloseUp);
            this.dtpReportStart.ValueChanged += new System.EventHandler(this.dtpReportStart_ValueChanged);
            this.dtpReportStart.Leave += new System.EventHandler(this.dtpReportStart_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 449);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "отсутствуют файлы для обработки";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Период с";
            // 
            // cAlarmVideoReg
            // 
            this.cAlarmVideoReg.DataPropertyName = "RegName";
            this.cAlarmVideoReg.HeaderText = "Видеорегистратор";
            this.cAlarmVideoReg.Name = "cAlarmVideoReg";
            this.cAlarmVideoReg.ReadOnly = true;
            // 
            // cAlarmChannel
            // 
            this.cAlarmChannel.DataPropertyName = "RegChannel";
            this.cAlarmChannel.HeaderText = "Канал";
            this.cAlarmChannel.Name = "cAlarmChannel";
            this.cAlarmChannel.ReadOnly = true;
            // 
            // cAlarmNameCam
            // 
            this.cAlarmNameCam.DataPropertyName = "CamName";
            this.cAlarmNameCam.HeaderText = "Наименование камеры на канале";
            this.cAlarmNameCam.Name = "cAlarmNameCam";
            this.cAlarmNameCam.ReadOnly = true;
            // 
            // cAlarmTypeEvent
            // 
            this.cAlarmTypeEvent.DataPropertyName = "TypeEvent";
            this.cAlarmTypeEvent.HeaderText = "Тип события";
            this.cAlarmTypeEvent.Name = "cAlarmTypeEvent";
            this.cAlarmTypeEvent.ReadOnly = true;
            // 
            // cAlarmDateStart
            // 
            this.cAlarmDateStart.DataPropertyName = "DateStartAlarm";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.cAlarmDateStart.DefaultCellStyle = dataGridViewCellStyle2;
            this.cAlarmDateStart.HeaderText = "Время начала";
            this.cAlarmDateStart.Name = "cAlarmDateStart";
            this.cAlarmDateStart.ReadOnly = true;
            // 
            // cAlarmDateEnd
            // 
            this.cAlarmDateEnd.DataPropertyName = "DateEndAlarm";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.cAlarmDateEnd.DefaultCellStyle = dataGridViewCellStyle3;
            this.cAlarmDateEnd.HeaderText = "Время окончания";
            this.cAlarmDateEnd.Name = "cAlarmDateEnd";
            this.cAlarmDateEnd.ReadOnly = true;
            // 
            // cAlarmLimit
            // 
            this.cAlarmLimit.DataPropertyName = "DeltaString";
            this.cAlarmLimit.HeaderText = "Продолжительность";
            this.cAlarmLimit.Name = "cAlarmLimit";
            this.cAlarmLimit.ReadOnly = true;
            // 
            // cAlarmResponcible
            // 
            this.cAlarmResponcible.DataPropertyName = "nameResponsible";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cAlarmResponcible.DefaultCellStyle = dataGridViewCellStyle4;
            this.cAlarmResponcible.HeaderText = "Ответственный";
            this.cAlarmResponcible.Name = "cAlarmResponcible";
            this.cAlarmResponcible.ReadOnly = true;
            // 
            // cAlarmComment
            // 
            this.cAlarmComment.DataPropertyName = "Comment";
            this.cAlarmComment.HeaderText = "Комментарий";
            this.cAlarmComment.Name = "cAlarmComment";
            this.cAlarmComment.ReadOnly = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 556);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frnMain_FormClosing);
            this.Load += new System.EventHandler(this.frnMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpAlarm.ResumeLayout(false);
            this.tpAlarm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).EndInit();
            this.tpReport.ResumeLayout(false);
            this.tpReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникВидеорегистраторовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникОтветственныхСотрудниковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникКаналовВидеорегистраторовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расписаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpAlarm;
        private System.Windows.Forms.TabPage tpReport;
        private System.Windows.Forms.DateTimePicker dtpReportStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbReportVideoReg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.TextBox tbReportComment;
        private System.Windows.Forms.TextBox tbReportResponsible;
        private System.Windows.Forms.DateTimePicker dtpReportEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btReportUpdate;
        private System.Windows.Forms.Button btReportComment;
        private System.Windows.Forms.Button btAlarmComment;
        private System.Windows.Forms.Button btAlarmUpdatre;
        private System.Windows.Forms.ComboBox cmbAlarmVideoReg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pAlarmLegend;
        private System.Windows.Forms.DataGridView dgvAlarm;
        private System.Windows.Forms.TextBox tbAlarmComment;
        private System.Windows.Forms.TextBox tbAlarmResponsible;
        private System.Windows.Forms.DateTimePicker dtpAlarmEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpAlarmStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAlarmChannel;
        private System.Windows.Forms.TextBox tbAlarmNameCam;
        private System.Windows.Forms.ComboBox cmbAlarmCameraVsChannel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbAlarmTypeEvent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbAlarmDelta;
        private System.Windows.Forms.Button btAlarmDropDelta;
        private System.Windows.Forms.CheckBox chbAlarmTime;
        private System.Windows.Forms.DateTimePicker dtpAlarmTimeStart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpAlarmTimeEnd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReportVideoReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReportTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReportDelta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReportRealTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReportComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReportResponsible;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cReportSing;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlarmVideoReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlarmChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlarmNameCam;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlarmTypeEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlarmDateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlarmDateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlarmLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlarmResponcible;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlarmComment;
    }
}

