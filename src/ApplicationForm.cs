using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using TimeTracker.Properties;

namespace TimeTracker
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
            Text = $"{Application.ProductName} V{Application.ProductVersion}";
            timeRecorder.EventAdded += ApplicationState_EventAdded;
            timeRecorder.StatusChanged += TimeRecorder_StatusChanged;
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
        }

        private void ApplicationState_EventAdded(object sender, EventLogArgs e)
        {
            textBoxEventLog.AppendText(e.Event.ToString() + Environment.NewLine);
        }

        private void TimeRecorder_StatusChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Suspend:
                    timeRecorder.OnEnterSleep();
                    break;
                case PowerModes.Resume:
                    timeRecorder.OnResumeFromSleep();
                    break;
            }
        }

        private void ApplicationForm_Load(object sender, EventArgs e)
        {
            InitializeTracking();
            UpdateControls();
        }

        private void ApplicationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShutdownTracking();
        }

        private void ApplicationForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timeRecorder.Start();
            UpdateControls();
            buttonStop.Focus();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timeRecorder.Stop();
            UpdateControls();
            buttonStart.Focus();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            timeRecorder.Reset();
            UpdateControls();
        }

        private void checkBoxStartWithLogin_CheckedChanged(object sender, EventArgs e)
        {
            EnableAutoRun(checkBoxStartWithLogin.Checked);
        }

        private void checkBoxTrackSleepActivity_CheckedChanged(object sender, EventArgs e)
        {
            timeRecorder.TrackSleepActivity = checkBoxTrackSleepActivity.Checked;
            UpdateControls();
        }

        private void checkBoxTrackInputActivity_CheckedChanged(object sender, EventArgs e)
        {
            timeRecorder.TrackInputActivity = checkBoxTrackInputActivity.Checked;
            UpdateControls();
        }

        private void textBoxIdleTimeout_TextChanged(object sender, EventArgs e)
        {
            if (TimeSpan.TryParse(textBoxIdleTimeout.Text, out var idleTimeout))
            {
                timeRecorder.IdleTimeout = idleTimeout;
            }
        }

        private void linkLabelAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(urlAbout));
        }

        private void checkBoxShowDebugEvents_CheckedChanged(object sender, EventArgs e)
        {
            timeRecorder.ShowDebugEvents = checkBoxShowDebugEvents.Checked;
            UpdateEventLog();
        }

        private void linkLabelClearLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timeRecorder.ClearEvents();
            textBoxEventLog.Text = string.Empty;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowOptions();
        }

        private void notifyIconContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            startTimerToolStripMenuItem.Enabled = !timeRecorder.State.Timer.Started;
            stopTimerToolStripMenuItem.Enabled = timeRecorder.State.Timer.Started;
        }

        private void startTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timeRecorder.Start();
            UpdateControls();
            buttonStop.Focus();
        }

        private void stopTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timeRecorder.Stop();
            UpdateControls();
            buttonStart.Focus();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }

        private void exitTimeTrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        void ShowOptions()
        {
            Show();

            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            Activate();
        }

        void InitializeTracking()
        {
            if (!initialized)
            {
                initialized = true;
                LoadSettings();
                LoadApplicationState();
                timeRecorder.OnApplicationStart();
            }
        }

        void ShutdownTracking()
        {
            if (initialized)
            {
                initialized = false;
                timeRecorder.OnApplicationShutdown();
                SaveApplicationState();
                SaveSettings();
            }
        }

        void LoadApplicationState()
        {
            var path = GetApplicationStatePath();

            try
            {
                if (File.Exists(path))
                {
                    timeRecorder.ReadState(path);
                    timeRecorder.Initialize();
                }
            }
            catch (Exception e)
            {
                timeRecorder.AddEvent(EventType.Error, $"Failed to read {path}: {e.Message}");
            }

            UpdateEventLog();
        }

        void SaveApplicationState()
        {
            var path = GetApplicationStatePath(true);

            try
            {
                timeRecorder.WriteState(path);
            }
            catch (Exception e)
            {
                timeRecorder.AddEvent(EventType.Error, $"Failed to write {path}: {e.Message}");
            }
        }

        static string GetApplicationStatePath(bool createIfMissing = false)
        {
            return Path.Combine(GetTimeTrackerPath(createIfMissing), "State.xml");
        }

        static string GetTimeTrackerPath(bool createIfMissing = false)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), appName);
            if (createIfMissing && !Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        void LoadSettings()
        {
            if (Settings.Default.WindowLocation.X >= 0 &&
                Settings.Default.WindowLocation.Y >= 0)
            {
                Location = Settings.Default.WindowLocation;
            }

            if (Settings.Default.WindowSize.Width > 0 &&
                Settings.Default.WindowSize.Height > 0)
            {
                Size = Settings.Default.WindowSize;
            }

            timeRecorder.TrackSleepActivity = Settings.Default.TrackSleepActivity;
            timeRecorder.TrackInputActivity = Settings.Default.TrackInputActivity;
            timeRecorder.IdleTimeout = Settings.Default.IdleTimeout;
            timeRecorder.ShowDebugEvents = Settings.Default.ShowDebugEvents;

            checkBoxStartWithLogin.Checked = IsAutoRunEnabled();
            checkBoxTrackSleepActivity.Checked = timeRecorder.TrackSleepActivity;
            checkBoxTrackInputActivity.Checked = timeRecorder.TrackInputActivity;
            textBoxIdleTimeout.Text = timeRecorder.IdleTimeout.ToString();
            checkBoxShowDebugEvents.Checked = timeRecorder.ShowDebugEvents;
        }

        void SaveSettings()
        {
            Settings.Default.WindowLocation = WindowState != FormWindowState.Minimized ? Location : RestoreBounds.Location;
            Settings.Default.WindowSize = WindowState != FormWindowState.Minimized ? Size : RestoreBounds.Size;
            Settings.Default.TrackSleepActivity = timeRecorder.TrackSleepActivity;
            Settings.Default.TrackInputActivity = timeRecorder.TrackInputActivity;
            Settings.Default.IdleTimeout = timeRecorder.IdleTimeout;
            Settings.Default.ShowDebugEvents = timeRecorder.ShowDebugEvents;
            Settings.Default.Save();
        }

        static bool IsAutoRunEnabled()
        {
            var registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            if (registryKey != null)
            {
                return registryKey.GetValue(appName) is string path && path == Assembly.GetExecutingAssembly().Location;
            }

            return false;
        }

        static void EnableAutoRun(bool enable)
        {
            var registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (registryKey != null)
            {
                if (enable)
                {
                    registryKey.SetValue(appName, Assembly.GetExecutingAssembly().Location);
                }
                else
                {
                    registryKey.DeleteValue(appName, false);
                }
            }
        }

        void UpdateControls()
        {
            buttonStart.Enabled = !timeRecorder.State.Timer.Started;
            buttonStop.Enabled = timeRecorder.State.Timer.Started;
            labelIdleTimeout.Enabled = timeRecorder.TrackInputActivity;
            textBoxIdleTimeout.Enabled = timeRecorder.TrackInputActivity;

            UpdateStatus();
        }

        void UpdateStatus()
        {
            var workTime = timeRecorder.TotalWorkingTime.ToString(@"hh\:mm\:ss");

            string state;
            if (timeRecorder.State.Timer.Started)
            {
                if (timeRecorder.State.Timer.Paused)
                {
                    state = "Paused";
                }
                else
                {
                    state = "Started";
                }
            }
            else
            {
                state = "Stopped";
            }

            labelStatus.Text = $"{workTime} - {state}";
            notifyIcon.Text = $"{Application.ProductName} - {workTime} - {state}";
        }

        void UpdateEventLog()
        {
            textBoxEventLog.Text = timeRecorder.State.EventLog.ToString(timeRecorder.ShowDebugEvents);
        }

        const string urlAbout = "https://github.com/mariusgreuel/timetracker";
        static readonly string appName = Application.ProductName;
        readonly TimeRecorder timeRecorder = new TimeRecorder();
        bool initialized = false;
    }
}
