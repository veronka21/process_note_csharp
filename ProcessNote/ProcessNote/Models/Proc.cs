using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessNote.Models
{
    public class Proc
    {
        private string _processName;
        private int _processID;
        public List<String> ProcessComments { get; } = new List<string>();
        private PerformanceCounter _CPU_Usage;
        private PerformanceCounter _RAM_Usage;
        public ProcessThreadCollection Threads { get; set; }
        public DateTime? StartTime { get; set; }
        public TimeSpan RunTime { get; set; }
        public string RunTimeString { get; set; }
        public string previousComments { get; set; }

        public PerformanceCounter CPU_Usage
        {
            get { return _CPU_Usage; }
            set
            {
                _CPU_Usage = value;
                RefreshCPU_Usage();
            }
        }

        public PerformanceCounter RAM_Usage
        {
            get { return _RAM_Usage; }
            set
            {
                _RAM_Usage = value;
                RefreshRAM_Usage();
            }
        }

        public float CPU_Performance { get; set; }
        public float RAM_Performance { get; set; }


        public void setRunTime()
        {
            if (StartTime != null)
            {
                RunTime = DateTime.Now.Subtract((DateTime) StartTime);
                RunTimeString = RunTime.ToString(@"hh\:mm\:ss");
            }
            else if (StartTime == null)
            {
                RunTimeString = "N/A";
            }
        }

        public int? ThreadCount
        {
            get => Threads.Count;
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

        public void RefreshCPU_Usage()
        {
            try
            {
                CPU_Performance = (float) CPU_Usage?.NextValue();
            }
            catch (Exception _)
            {
                CPU_Performance = 0;
            }
        }

        public void RefreshRAM_Usage()
        {
            try
            {
                RAM_Performance = (float) RAM_Usage?.NextValue();
            }
            catch (Exception _)
            {
                RAM_Performance = 0;
            }
        }

        public void setPreviousCommentsAsString()
        {
            if (ProcessComments.Count == 0)
            {
                previousComments = "There are no comments yet.";
                return;
            }

            previousComments = string.Empty;
            StringBuilder comments = new StringBuilder();
            foreach (var comment in ProcessComments)
            {
                comments.Append(comment);
                comments.Append("\n");
            }

            previousComments += comments.ToString();

        }
    }
}
