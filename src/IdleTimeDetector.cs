using System;
using System.Runtime.InteropServices;

namespace TimeTracker
{
    class IdleTimeDetector
    {
        class Native
        {
            [DllImport("user32.dll")]
            internal static extern bool GetLastInputInfo(ref LASTINPUTINFO lastInput);

            [StructLayout(LayoutKind.Sequential)]
            internal struct LASTINPUTINFO
            {
                public int cbSize;
                public int dwTime;
            }
        }

        static public TimeSpan IdleTime
        {
            get
            {
                var lastInputInfo = new Native.LASTINPUTINFO();
                lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);

                int time = 0;
                if (Native.GetLastInputInfo(ref lastInputInfo))
                {
                    time = Environment.TickCount - lastInputInfo.dwTime;
                }

                return TimeSpan.FromMilliseconds(time > 0 ? time : 0);
            }
        }
    }
}
