using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TimeTracker
{
    public enum EventType
    {
        WorkTimeUpdate,
        WorkTimeReset,
        Information,
        Warning,
        Error,
        Debug,
        TimerStart,
        TimerStop,
        ApplicationStart,
        ApplicationShutdown,
        EnterSleep,
        ResumeFromSleep,
        BeginActivity,
        EndActivity,
    }

    [XmlType("Event")]
    public class EventItem
    {
        [XmlAttribute]
        public DateTime Time;

        [XmlAttribute]
        public EventType Type;

        [XmlAttribute]
        public string Description;

        [XmlIgnore]
        public bool IsDebug => Type >= EventType.Debug;

        public override string ToString()
        {
            return $"[{Time:s}] {Description ?? FriendlyEventType(Type)}";
        }

        static string FriendlyEventType(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.WorkTimeUpdate:
                    return "Work time updated";
                case EventType.WorkTimeReset:
                    return "Work time resetted";
                case EventType.Information:
                    return "Information";
                case EventType.Warning:
                    return "Warning";
                case EventType.Error:
                    return "Error";
                case EventType.TimerStart:
                    return "Timer started";
                case EventType.TimerStop:
                    return "Timer stopped";
                case EventType.ApplicationStart:
                    return "Application started";
                case EventType.ApplicationShutdown:
                    return "Application closed";
                case EventType.EnterSleep:
                    return "Computer is entering sleep mode";
                case EventType.ResumeFromSleep:
                    return "Computer resumed from sleep mode";
                case EventType.BeginActivity:
                    return "Timer started due to user activity";
                case EventType.EndActivity:
                    return "Timer paused due to user inactivity";
                default:
                    return "Unknown event";
            }
        }
    }

    public class EventLogArgs : EventArgs
    {
        public EventItem Event { get; set; }
    }

    public delegate void EventLogHandler(object sender, EventLogArgs e);

    public class EventLog
    {
        public List<EventItem> Events = new List<EventItem>();

        public string ToString(bool showDebugEvents)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in Events)
            {
                if (showDebugEvents || !item.IsDebug)
                {
                    stringBuilder.Append(item.ToString() + Environment.NewLine);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
