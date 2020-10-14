using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using ProcessNote.ViewModels;

namespace ProcessNote.Views {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ThreadWindow : Window {
        ThreadWindowViewModel _vm;

        public ThreadWindow(ProcessThreadCollection ThreadCollection) {
            InitializeComponent();
            _vm = new ThreadWindowViewModel(ThreadCollection);
            this.DataContext = _vm;
            lvThreads.ItemsSource = _vm.Threads;
        }

    }
}
