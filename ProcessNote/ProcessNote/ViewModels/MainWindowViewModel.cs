using ProcessNote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                Proc currentProcess = new Proc() { ProcessName = p.ProcessName, ProcessID = p.Id, Threads = p.Threads };
                try {
                    currentProcess.StartTime = p.StartTime;
                } catch (Exception) {
                }
                //currentProcess.CPU_Counter = CPU(currentProcess.ProcessName, currentProcess.ProcessID);
                Processes.Add(currentProcess);
                //MessageBox.Show(currentProcess.showCurrentCpuUsage());
            }
        }

        private PerformanceCounter CPU(string processName, int processId) {
            string name = string.Empty;
            foreach (var instance in new PerformanceCounterCategory("Process").GetInstanceNames()) {
                if (instance.StartsWith(processName)) {
                    using (var procId = new PerformanceCounter("Process", "ID Process", instance, true)) {
                        if (processId == (int)procId.RawValue) {
                            name = instance;
                            break;
                        }
                    }
                }
            }
            var cpu = new PerformanceCounter("Process", "% Processor Time", name, true);
            return cpu;
        }
    }
}
