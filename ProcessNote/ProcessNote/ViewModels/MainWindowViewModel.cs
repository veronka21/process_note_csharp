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

        private ObservableCollection<Proc> _selectedProcessObservable;
        public ObservableCollection<Proc> SelectedProcessObservable
        {
            get { return _selectedProcessObservable; }
            set { _selectedProcessObservable = value;
                OnPropertyChanged("SelectedProcessObservable");
            }
        }


        public Proc SelectedProcess { get; set; }


        public MainWindowViewModel() 
        {
            Seed();
            SelectedProcessObservable = new ObservableCollection<Proc>();
        }

        public void Seed()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                Proc currentProcess = new Proc() { ProcessName = p.ProcessName, ProcessID = p.Id, Threads = p.Threads };
                try {
                    currentProcess.StartTime = p.StartTime;
                } catch (Exception) {
                    
                }
                Processes.Add(currentProcess);
            }
        }
    }
}
