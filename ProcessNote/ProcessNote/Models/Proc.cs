using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessNote.Models
{
    class Proc
    {
        private string _processName;
        private int _processID;

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
