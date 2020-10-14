using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessNote.Models
{
    class Proc {
        private string _processName;
        private int _processID;
        public ProcessThreadCollection Threads { get; set; }
        public DateTime? StartTime { get; set; }
        public PerformanceCounter CPU_Counter { get; set; }

        public string showCurrentCpuUsage() 
        {
            try {
                return $"CPU {CPU_Counter?.NextValue()}%";
            } catch (Exception e) { 
                return $"Not available: {e}";
            }
        }

        public float CPU_Performance
        {
            get => (float)CPU_Counter?.NextValue();
        }

        public int? ThreadCount
            {
                get =>Threads.Count;
            }
        

        public string ProcessName
        {
            get { return _processName; }
            set { _processName = value; }
        }


        public int ProcessID
        {
            get { return _processID; }
            set { _processID = value; }
        }



    }
}
