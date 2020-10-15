using ProcessNote.Models;
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
            lvSelectedProc.ItemsSource = _vm.SelectedProcessObservable;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvProc.ItemsSource);
            view.Filter = UserFilter;
        }

        private void ThreadBtn_Click(object sender, RoutedEventArgs e) 
        {
            Button showThreadBtn = (Button)sender;
            ProcessThreadCollection threads = (ProcessThreadCollection)showThreadBtn.CommandParameter;
            ThreadWindow threadWindow = new ThreadWindow(threads);
            threadWindow.Show();
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
                item.setRunTime();
                item.setPreviousCommentsAsString();
                _vm.SelectedProcessObservable.Add(item);
                this.TextStackPanel.Children.Clear();
                Show_AddButton();
            }
        }

        private void Show_AddButton()
        {

            //< Button Content = "Show Threads" Click = "ThreadBtn_Click" CommandParameter = "{Binding Threads}" />
            Button addCommentButton = new Button();
            addCommentButton.Name = "addComment";
            addCommentButton.Content = "Add Comment";
            addCommentButton.Height = 20;
            Thickness margin = addCommentButton.Margin;
            margin.Left = 10;
            addCommentButton.Margin = margin;
            addCommentButton.Click += Show_TextBox;
            //addCommentButton.CommandParameter = "{Binding Threads}";
            this.TextStackPanel.Children.Add(addCommentButton);
        }

        private void Show_TextBox(object sender, RoutedEventArgs e)
        {
            TextBox dynamicTextBox = new TextBox();
            dynamicTextBox.Name = "DynamicTextBox";
            dynamicTextBox.Text = "Put your comments here ...";
            dynamicTextBox.Width = 230;
            //dynamicTextBox.TextChanged = "TextBox_TextChanged";
            Thickness margin = dynamicTextBox.Margin;
            margin.Left = 10;
            dynamicTextBox.Margin = margin;
            this.TextStackPanel.Children.Clear();
            this.TextStackPanel.Children.Add(dynamicTextBox);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
