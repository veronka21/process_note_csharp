using ProcessNote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessNote.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        internal ObservableCollection<Proc> Processes { get; set; } = new ObservableCollection<Proc>();
        Proc SelectedProcess { get; set; }

        public MainWindowViewModel() 
        {
            Seed();
        }

        private void Seed()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                Processes.Add(new Proc() {ProcessName = p.ProcessName, ProcessID = p.Id });
            }
        }
    }
}
