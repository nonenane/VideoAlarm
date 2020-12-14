
namespace VideoAlarmDemon
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lstResultLog = new System.Windows.Forms.ListBox();
            this.lstResultBody = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 563);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;            
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(683, 563);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 55);
            this.button2.TabIndex = 0;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;            
            // 
            // lstResultLog
            // 
            this.lstResultLog.FormattingEnabled = true;
            this.lstResultLog.Location = new System.Drawing.Point(12, 12);
            this.lstResultLog.Name = "lstResultLog";
            this.lstResultLog.Size = new System.Drawing.Size(776, 108);
            this.lstResultLog.TabIndex = 1;
            // 
            // lstResultBody
            // 
            this.lstResultBody.FormattingEnabled = true;
            this.lstResultBody.Location = new System.Drawing.Point(12, 126);
            this.lstResultBody.Name = "lstResultBody";
            this.lstResultBody.Size = new System.Drawing.Size(776, 420);
            this.lstResultBody.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 630);
            this.Controls.Add(this.lstResultBody);
            this.Controls.Add(this.lstResultLog);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lstResultLog;
        private System.Windows.Forms.ListBox lstResultBody;
    }
}

