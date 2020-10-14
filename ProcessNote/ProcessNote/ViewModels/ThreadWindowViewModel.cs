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
    public class ThreadWindowViewModel : ViewModelBase
    {
        ProcessThreadCollection _receivedThreadCollection;
        internal ObservableCollection<Thread> Threads { get; set; } = new ObservableCollection<Thread>();

        public ThreadWindowViewModel(ProcessThreadCollection ThreadCollection) 
        {
            _receivedThreadCollection = ThreadCollection;
            Seed();
        }

        private void Seed()
        {
            foreach (ProcessThread thread in _receivedThreadCollection) {
                Thread currentThread = new Thread(thread.Id);
                try {
                    currentThread.BasePriority = thread.BasePriority.ToString();
                    currentThread.PriorityLevel = thread.PriorityLevel.ToString();
                } catch (Exception) {
                }
                Threads.Add(currentThread);
            }
        }
    }
}
