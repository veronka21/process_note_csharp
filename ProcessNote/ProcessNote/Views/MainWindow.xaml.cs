﻿using ProcessNote.Models;
using ProcessNote.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            lvSelectedProc.ItemsSource = _vm.SelectedProcessObservable;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvProc.ItemsSource);
            view.Filter = UserFilter;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void ProcessName_Click(object sender, RoutedEventArgs e)
        {
            //_vm.Sort();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvProc.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("ProcessName", ListSortDirection.Ascending));
            
        }

        private void ProcessId_Click(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvProc.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("ProcessID", ListSortDirection.Ascending));
        }


        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Proc).ProcessName.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvProc.ItemsSource).Refresh();
        }

        private void ListBox_SelectedProcessChange(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            _vm.SelectedProcessObservable.Clear();
            foreach (Proc item in lb.SelectedItems)
            {
                _vm.SelectedProcessObservable.Add(item);
                Console.WriteLine("asdasd");
            }
        }
    }
}
