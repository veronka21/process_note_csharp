using ProcessNote.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
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
            //var cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            //Thread.Sleep(1000);
            //var firstCall = cpuUsage.NextValue();

            //for (int i = 0; i < 5; i++)
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine(cpuUsage.NextValue() + "%");
            //}

            Seed();
        }

        private void Seed()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                Proc currentProcess = new Proc() { ProcessName = p.ProcessName, ProcessID = p.Id, Threads = p.Threads };
                try
                {
                    currentProcess.StartTime = p.StartTime;
                }
                catch (Exception)
                {
                }
                currentProcess.CPU_Counter = CPU(currentProcess.ProcessName, currentProcess.ProcessID);
                Processes.Add(currentProcess);
            }
        }

        private PerformanceCounter CPU(string processName, int processId)
        {
            string name = string.Empty;
            //var process = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            //var firstCall = process.NextValue();
            foreach (var instance in new PerformanceCounterCategory("Process").GetInstanceNames())
            {
                if (instance.Contains(processName))
                {
                    var process = new PerformanceCounter("Process", "ID Process", instance, true);
                    if (processId == (int)process.RawValue)
                    {
                        name = instance;
                        break;
                    }
                }
            }
            var cpu = new PerformanceCounter("Process", "% Processor Time", name, true);

            //Console.WriteLine("instance name: " + process.InstanceName);
            try
            {
                cpu.NextValue();
                //    Thread.Sleep(50);
                //    Console.WriteLine(cpu.InstanceName + ": " +cpu.NextValue());
            }
            catch (Exception e) { }
            return cpu;
        }
    }
}
