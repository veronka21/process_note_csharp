using ProcessNote.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using ProcessNote.Views;

namespace ProcessNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly MainWindowViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainWindowViewModel();
            this.DataContext = _vm;
            lvProc.ItemsSource = _vm.Processes;
        }

        private void ThreadBtn_Click(object sender, RoutedEventArgs e) {
            Button showThreadBtn = (Button)sender;
            ProcessThreadCollection threads = (ProcessThreadCollection)showThreadBtn.CommandParameter;
            ThreadWindow threadWindow = new ThreadWindow(threads);
            threadWindow.Show();
        }
    }
}
