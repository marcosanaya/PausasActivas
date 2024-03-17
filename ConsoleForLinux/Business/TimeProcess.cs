using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForLinux.Business
{
    public class TimeProcess
    {
        private DateTime startTime;
        private DateTime stopTime;
        private bool stillRunning;

        public TimeProcess()
        {
            startTime = DateTime.Now;
            stillRunning = true;
        }
        public void StartProcess()
        {
            stillRunning = true;
            startTime = DateTime.Now;
        }

        public void StopProcess()
        {
            stillRunning = false;
            stopTime = DateTime.Now;
        }

        public bool IsStillRunning()
        {
            return stillRunning;
        }

        public DateTime GetDuration()
        {
            long ticks = stopTime.Ticks - startTime.Ticks;
            DateTime result = new(ticks);
            return result;
        }
    }
}
