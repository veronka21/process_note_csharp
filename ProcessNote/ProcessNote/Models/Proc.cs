﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessNote.Models
{
    public class Proc {
        private string _processName;
        private int _processID;
        public List<String> ProcessComments { get; } = new List<string>();
        public ProcessThreadCollection Threads { get; set; }
        public DateTime? StartTime { get; set; }
        public TimeSpan RunTime { get; set; }
        public string RunTimeString { get; set; }
        
        public void setRunTime() 
        {
            if (StartTime != null) {
                RunTime = DateTime.Now.Subtract((DateTime)StartTime);
                RunTimeString = RunTime.ToString(@"hh\:mm\:ss");
            } else if (StartTime == null) {
                RunTimeString = "N/A";
            }
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
