using Microsoft.Win32;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace TimeTracker
{
    public delegate void StatusChangedEventHandler(object sender, EventArgs e);

    public class TimeRecorder
    {
        public class TimerState
        {
            [XmlAttribute]
            public bool Started = false;

            [XmlAttribute]
            public bool Paused = false;

            [XmlIgnore]
            public TimeSpan WorkTime = TimeSpan.Zero;

            [XmlAttribute("WorkingTime")]
            public string WorkingTimeXml
            {
                get => WorkTime.ToString();
                set => WorkTime = TimeSpan.Parse(value);
            }
        }

        [XmlRoot("TimeTracker")]
        public class TimeRecorderState
        {
            public TimerState Timer = new TimerState();
            public EventLog EventLog = new EventLog();
        }

        public TimeRecorder()
        {
            SystemEvents.TimerElapsed += OnTimerElapsed;
            checkTimerId = SystemEvents.CreateTimer(1000);
        }

        public TimeRecorderState State { get; private set; } = new TimeRecorderState();

        public bool TrackSleepActivity { get; set; } = true;
        public bool TrackInputActivity { get; set; } = true;
        public TimeSpan IdleTimeout { get; set; } = TimeSpan.FromMinutes(5);
        public bool ShowDebugEvents { get; set; } = true;

        public TimeSpan CurrentWorkingTime => State.Timer.Started && !State.Timer.Paused ? DateTime.Now - startTime : TimeSpan.Zero;
        public TimeSpan TotalWorkingTime => State.Timer.WorkTime + CurrentWorkingTime;

        public event EventLogHandler EventAdded;
        public event StatusChangedEventHandler StatusChanged;

        public void Initialize()
        {
            startTime = DateTime.Now;
        }

        public void AddEvent(EventType eventType, string description = null)
        {
            var item = new EventItem() { Time = DateTime.Now, Type = eventType, Description = description };
            State.EventLog.Events.Add(item);

            if ((ShowDebugEvents || !item.IsDebug) && EventAdded != null)
            {
                EventAdded.Invoke(this, new EventLogArgs() { Event = item });
            }
        }

        public void ClearEvents()
        {
            State.EventLog.Events.Clear();
        }

        public void ReadState(string path)
        {
            using (var reader = XmlReader.Create(path))
            {
                var serializer = new XmlSerializer(typeof(TimeRecorderState));
                serializer.UnknownElement += new XmlElementEventHandler(Serializer_UnknownElement);
                serializer.UnknownAttribute += new XmlAttributeEventHandler(Serializer_UnknownAttribute);
                State = (TimeRecorderState)serializer.Deserialize(reader);
            }
        }

        public void WriteState(string path)
        {
            using (var writer = XmlWriter.Create(path, new XmlWriterSettings() { Indent = true }))
            {
                var serializer = new XmlSerializer(typeof(TimeRecorderState));
                serializer.Serialize(writer, State);
            }
        }

        public void Start()
        {
            if (!State.Timer.Started)
            {
                AddEvent(EventType.TimerStart);
                State.Timer.Started = true;
                State.Timer.Paused = false;
                startTime = DateTime.Now;
                hasUserActivity = true;
                UpdateStatus();
            }
        }

        public void Stop()
        {
            if (State.Timer.Started)
            {
                AddEvent(EventType.TimerStop);
                Flush();
                State.Timer.Started = false;
                State.Timer.Paused = false;
                UpdateStatus();
            }
        }

        public void Reset()
        {
            AddEvent(EventType.WorkTimeReset);
            State.Timer.WorkTime = TimeSpan.Zero;
            startTime = DateTime.Now;
            UpdateStatus();
        }

        public void Flush()
        {
            if (State.Timer.Started)
            {
                if (State.Timer.Paused)
                {
                    startTime = DateTime.Now;
                }
                else
                {
                    var now = DateTime.Now;
                    State.Timer.WorkTime += now - startTime;
                    startTime = now;
                    AddEvent(EventType.WorkTimeUpdate, $"Work time updated to {State.Timer.WorkTime:hh\\:mm\\:ss}");
}
            }
        }

        public void OnApplicationStart()
        {
            if (State.Timer.Started)
            {
                AddEvent(EventType.ApplicationStart);
                PauseTimer(false);
            }
        }

        public void OnApplicationShutdown()
        {
            if (State.Timer.Started)
            {
                PauseTimer(true);
                AddEvent(EventType.ApplicationShutdown);
            }
        }

        public void OnEnterSleep()
        {
            if (State.Timer.Started)
            {
                if (TrackSleepActivity)
                {
                    PauseTimer(true);
                }

                AddEvent(EventType.EnterSleep);
            }
        }

        public void OnResumeFromSleep()
        {
            if (State.Timer.Started)
            {
                AddEvent(EventType.ResumeFromSleep);

                if (TrackSleepActivity)
                {
                    PauseTimer(false);
                }
            }
        }

        public void OnBeginActivity()
        {
            if (State.Timer.Started)
            {
                AddEvent(EventType.BeginActivity);

                if (TrackInputActivity)
                {
                    PauseTimer(false);
                }
            }
        }

        public void OnEndActivity()
        {
            if (State.Timer.Started)
            {
                if (TrackInputActivity)
                {
                    PauseTimer(true);
                }

                AddEvent(EventType.EndActivity);
            }
        }

        void OnTimerElapsed(object sender, TimerElapsedEventArgs e)
        {
            if (e.TimerId == checkTimerId && State.Timer.Started)
            {
                DetectUserActivity();
                UpdateStatus();
            }
        }

        void DetectUserActivity()
        {
            if (IdleTimeDetector.IdleTime < IdleTimeout)
            {
                if (!hasUserActivity)
                {
                    hasUserActivity = true;
                    OnBeginActivity();
                }
            }
            else
            {
                if (hasUserActivity)
                {
                    hasUserActivity = false;
                    OnEndActivity();
                }
            }
        }

        void PauseTimer(bool pause)
        {
            if (pause != State.Timer.Paused)
            {
                Flush();
                State.Timer.Paused = pause;
                UpdateStatus();
            }
        }

        void UpdateStatus()
        {
            StatusChanged.Invoke(this, EventArgs.Empty);
        }

        static void Serializer_UnknownElement(object sender, XmlElementEventArgs e)
        {
            throw new Exception(string.Format("Unknown element '{0}'", e.Element.Name));
        }

        static void Serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            throw new Exception(string.Format("Unknown attribute '{0}'", e.Attr.Name));
        }

        readonly IntPtr checkTimerId;
        DateTime startTime;
        bool hasUserActivity = false;
    }
}
