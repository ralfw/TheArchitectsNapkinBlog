namespace alarmclock.head
{
    partial class DlgAlarmclock
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
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWakeupTime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSwitchAlarmOn = new System.Windows.Forms.RadioButton();
            this.rbSwitchAlarmOff = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTime.Location = new System.Drawing.Point(57, 9);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(103, 29);
            this.lblCurrentTime.TabIndex = 0;
            this.lblCurrentTime.Text = "14:32:53";
            // 
            // lblRemainingTime
            // 
            this.lblRemainingTime.AutoSize = true;
            this.lblRemainingTime.ForeColor = System.Drawing.Color.Red;
            this.lblRemainingTime.Location = new System.Drawing.Point(81, 50);
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Size = new System.Drawing.Size(49, 13);
            this.lblRemainingTime.TabIndex = 1;
            this.lblRemainingTime.Text = "00:27:07";
            this.lblRemainingTime.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Alarm time";
            // 
            // txtWakeupTime
            // 
            this.txtWakeupTime.Location = new System.Drawing.Point(73, 94);
            this.txtWakeupTime.Name = "txtWakeupTime";
            this.txtWakeupTime.Size = new System.Drawing.Size(64, 20);
            this.txtWakeupTime.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSwitchAlarmOff);
            this.groupBox1.Controls.Add(this.rbSwitchAlarmOn);
            this.groupBox1.Location = new System.Drawing.Point(143, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 69);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Switch alarm...";
            // 
            // rbSwitchAlarmOn
            // 
            this.rbSwitchAlarmOn.AutoSize = true;
            this.rbSwitchAlarmOn.Location = new System.Drawing.Point(21, 19);
            this.rbSwitchAlarmOn.Name = "rbSwitchAlarmOn";
            this.rbSwitchAlarmOn.Size = new System.Drawing.Size(41, 17);
            this.rbSwitchAlarmOn.TabIndex = 5;
            this.rbSwitchAlarmOn.Text = "ON";
            this.rbSwitchAlarmOn.UseVisualStyleBackColor = true;
            this.rbSwitchAlarmOn.Click += new System.EventHandler(this.rbSwitchAlarm_clicked);
            // 
            // rbSwitchAlarmOff
            // 
            this.rbSwitchAlarmOff.AutoSize = true;
            this.rbSwitchAlarmOff.Checked = true;
            this.rbSwitchAlarmOff.Location = new System.Drawing.Point(21, 42);
            this.rbSwitchAlarmOff.Name = "rbSwitchAlarmOff";
            this.rbSwitchAlarmOff.Size = new System.Drawing.Size(45, 17);
            this.rbSwitchAlarmOff.TabIndex = 6;
            this.rbSwitchAlarmOff.TabStop = true;
            this.rbSwitchAlarmOff.Text = "OFF";
            this.rbSwitchAlarmOff.UseVisualStyleBackColor = true;
            this.rbSwitchAlarmOff.Click += new System.EventHandler(this.rbSwitchAlarm_clicked);
            // 
            // DlgAlarmclock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 159);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtWakeupTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRemainingTime);
            this.Controls.Add(this.lblCurrentTime);
            this.MaximizeBox = false;
            this.Name = "DlgAlarmclock";
            this.Text = "Alarm Clock";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DlgAlarmclock_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblRemainingTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWakeupTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSwitchAlarmOff;
        private System.Windows.Forms.RadioButton rbSwitchAlarmOn;
    }
}

