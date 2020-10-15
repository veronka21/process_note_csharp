using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessNote.Models {
    class Thread {
        public int Id { get; set; }
        public string BasePriority { get; set; } = "N/A";
        public string PriorityLevel { get; set; } = "N/A";

        public Thread(int id) {
            Id = id;
        }
    }
}
