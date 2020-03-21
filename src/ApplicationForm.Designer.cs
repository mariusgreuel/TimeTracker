namespace TimeTracker
{
    partial class ApplicationForm
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBoxTimer = new System.Windows.Forms.GroupBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxTrackSleepActivity = new System.Windows.Forms.CheckBox();
            this.checkBoxStartWithLogin = new System.Windows.Forms.CheckBox();
            this.checkBoxTrackInputActivity = new System.Windows.Forms.CheckBox();
            this.labelIdleTimeout = new System.Windows.Forms.Label();
            this.textBoxIdleTimeout = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.linkLabelAbout = new System.Windows.Forms.LinkLabel();
            this.linkLabelClearLog = new System.Windows.Forms.LinkLabel();
            this.checkBoxShowDebugEvents = new System.Windows.Forms.CheckBox();
            this.labelEventLog = new System.Windows.Forms.Label();
            this.textBoxEventLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBoxTimer.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxTimer);
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxOptions);
            this.splitContainerMain.Panel1.Controls.Add(this.labelStatus);
            this.splitContainerMain.Panel1.Controls.Add(this.linkLabelAbout);
            this.splitContainerMain.Panel1MinSize = 350;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.linkLabelClearLog);
            this.splitContainerMain.Panel2.Controls.Add(this.checkBoxShowDebugEvents);
            this.splitContainerMain.Panel2.Controls.Add(this.labelEventLog);
            this.splitContainerMain.Panel2.Controls.Add(this.textBoxEventLog);
            this.splitContainerMain.Size = new System.Drawing.Size(684, 244);
            this.splitContainerMain.SplitterDistance = 350;
            this.splitContainerMain.TabIndex = 0;
            // 
            // groupBoxTimer
            // 
            this.groupBoxTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTimer.Controls.Add(this.buttonStart);
            this.groupBoxTimer.Controls.Add(this.buttonReset);
            this.groupBoxTimer.Controls.Add(this.buttonStop);
            this.groupBoxTimer.Location = new System.Drawing.Point(12, 40);
            this.groupBoxTimer.Name = "groupBoxTimer";
            this.groupBoxTimer.Size = new System.Drawing.Size(330, 54);
            this.groupBoxTimer.TabIndex = 1;
            this.groupBoxTimer.TabStop = false;
            this.groupBoxTimer.Text = "Timer";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(10, 19);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(80, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "&Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(182, 19);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(80, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "&Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(96, 19);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(80, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "&Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOptions.Controls.Add(this.checkBoxTrackSleepActivity);
            this.groupBoxOptions.Controls.Add(this.checkBoxStartWithLogin);
            this.groupBoxOptions.Controls.Add(this.checkBoxTrackInputActivity);
            this.groupBoxOptions.Controls.Add(this.labelIdleTimeout);
            this.groupBoxOptions.Controls.Add(this.textBoxIdleTimeout);
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 100);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(330, 119);
            this.groupBoxOptions.TabIndex = 1;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // checkBoxTrackSleepActivity
            // 
            this.checkBoxTrackSleepActivity.AutoSize = true;
            this.checkBoxTrackSleepActivity.Location = new System.Drawing.Point(10, 42);
            this.checkBoxTrackSleepActivity.Name = "checkBoxTrackSleepActivity";
            this.checkBoxTrackSleepActivity.Size = new System.Drawing.Size(261, 17);
            this.checkBoxTrackSleepActivity.TabIndex = 2;
            this.checkBoxTrackSleepActivity.Text = "Start/Stop timer when my computer sleeps/wakes";
            this.checkBoxTrackSleepActivity.UseVisualStyleBackColor = true;
            this.checkBoxTrackSleepActivity.CheckedChanged += new System.EventHandler(this.checkBoxTrackSleepActivity_CheckedChanged);
            // 
            // checkBoxStartWithLogin
            // 
            this.checkBoxStartWithLogin.AutoSize = true;
            this.checkBoxStartWithLogin.Location = new System.Drawing.Point(10, 19);
            this.checkBoxStartWithLogin.Name = "checkBoxStartWithLogin";
            this.checkBoxStartWithLogin.Size = new System.Drawing.Size(294, 17);
            this.checkBoxStartWithLogin.TabIndex = 0;
            this.checkBoxStartWithLogin.Text = "Start TimeTracker automatically when I login to Windows";
            this.checkBoxStartWithLogin.UseVisualStyleBackColor = true;
            this.checkBoxStartWithLogin.CheckedChanged += new System.EventHandler(this.checkBoxStartWithLogin_CheckedChanged);
            // 
            // checkBoxTrackInputActivity
            // 
            this.checkBoxTrackInputActivity.AutoSize = true;
            this.checkBoxTrackInputActivity.Location = new System.Drawing.Point(10, 65);
            this.checkBoxTrackInputActivity.Name = "checkBoxTrackInputActivity";
            this.checkBoxTrackInputActivity.Size = new System.Drawing.Size(292, 17);
            this.checkBoxTrackInputActivity.TabIndex = 3;
            this.checkBoxTrackInputActivity.Text = "Start/Stop timer based on my keyboard or mouse activity";
            this.checkBoxTrackInputActivity.UseVisualStyleBackColor = true;
            this.checkBoxTrackInputActivity.CheckedChanged += new System.EventHandler(this.checkBoxTrackInputActivity_CheckedChanged);
            // 
            // labelIdleTimeout
            // 
            this.labelIdleTimeout.AutoSize = true;
            this.labelIdleTimeout.Location = new System.Drawing.Point(30, 91);
            this.labelIdleTimeout.Name = "labelIdleTimeout";
            this.labelIdleTimeout.Size = new System.Drawing.Size(68, 13);
            this.labelIdleTimeout.TabIndex = 4;
            this.labelIdleTimeout.Text = "Idle Timeout:";
            // 
            // textBoxIdleTimeout
            // 
            this.textBoxIdleTimeout.Location = new System.Drawing.Point(104, 88);
            this.textBoxIdleTimeout.Name = "textBoxIdleTimeout";
            this.textBoxIdleTimeout.Size = new System.Drawing.Size(80, 20);
            this.textBoxIdleTimeout.TabIndex = 5;
            this.textBoxIdleTimeout.TextChanged += new System.EventHandler(this.textBoxIdleTimeout_TextChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.AutoEllipsis = true;
            this.labelStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(12, 9);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(330, 28);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Status";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelAbout
            // 
            this.linkLabelAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabelAbout.AutoSize = true;
            this.linkLabelAbout.Location = new System.Drawing.Point(9, 222);
            this.linkLabelAbout.Name = "linkLabelAbout";
            this.linkLabelAbout.Size = new System.Drawing.Size(98, 13);
            this.linkLabelAbout.TabIndex = 2;
            this.linkLabelAbout.TabStop = true;
            this.linkLabelAbout.Text = "&About TimeTracker";
            this.linkLabelAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAbout_LinkClicked);
            // 
            // linkLabelClearLog
            // 
            this.linkLabelClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelClearLog.AutoSize = true;
            this.linkLabelClearLog.Location = new System.Drawing.Point(266, 9);
            this.linkLabelClearLog.Name = "linkLabelClearLog";
            this.linkLabelClearLog.Size = new System.Drawing.Size(52, 13);
            this.linkLabelClearLog.TabIndex = 3;
            this.linkLabelClearLog.TabStop = true;
            this.linkLabelClearLog.Text = "&Clear Log";
            this.linkLabelClearLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClearLog_LinkClicked);
            // 
            // checkBoxShowDebugEvents
            // 
            this.checkBoxShowDebugEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowDebugEvents.AutoSize = true;
            this.checkBoxShowDebugEvents.Location = new System.Drawing.Point(7, 224);
            this.checkBoxShowDebugEvents.Name = "checkBoxShowDebugEvents";
            this.checkBoxShowDebugEvents.Size = new System.Drawing.Size(121, 17);
            this.checkBoxShowDebugEvents.TabIndex = 2;
            this.checkBoxShowDebugEvents.Text = "Show &debug events";
            this.checkBoxShowDebugEvents.UseVisualStyleBackColor = true;
            this.checkBoxShowDebugEvents.CheckedChanged += new System.EventHandler(this.checkBoxShowDebugEvents_CheckedChanged);
            // 
            // labelEventLog
            // 
            this.labelEventLog.AutoSize = true;
            this.labelEventLog.Location = new System.Drawing.Point(4, 9);
            this.labelEventLog.Name = "labelEventLog";
            this.labelEventLog.Size = new System.Drawing.Size(59, 13);
            this.labelEventLog.TabIndex = 0;
            this.labelEventLog.Text = "Event &Log:";
            // 
            // textBoxEventLog
            // 
            this.textBoxEventLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEventLog.Location = new System.Drawing.Point(7, 25);
            this.textBoxEventLog.Multiline = true;
            this.textBoxEventLog.Name = "textBoxEventLog";
            this.textBoxEventLog.ReadOnly = true;
            this.textBoxEventLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEventLog.Size = new System.Drawing.Size(311, 193);
            this.textBoxEventLog.TabIndex = 1;
            this.textBoxEventLog.WordWrap = false;
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 244);
            this.Controls.Add(this.splitContainerMain);
            this.MinimumSize = new System.Drawing.Size(370, 283);
            this.Name = "ApplicationForm";
            this.Text = "TimeTracker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ApplicationForm_FormClosed);
            this.Load += new System.EventHandler(this.ApplicationForm_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.groupBoxTimer.ResumeLayout(false);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.LinkLabel linkLabelAbout;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelEventLog;
        private System.Windows.Forms.TextBox textBoxEventLog;
        private System.Windows.Forms.CheckBox checkBoxShowDebugEvents;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.CheckBox checkBoxStartWithLogin;
        private System.Windows.Forms.CheckBox checkBoxTrackInputActivity;
        private System.Windows.Forms.Label labelIdleTimeout;
        private System.Windows.Forms.TextBox textBoxIdleTimeout;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.GroupBox groupBoxTimer;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox checkBoxTrackSleepActivity;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.LinkLabel linkLabelClearLog;
    }
}

