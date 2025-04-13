// MainWindow.xaml.cs
using System.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace SleepTracker
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddSessionWindow();
            if (window.ShowDialog() == true && window.NewSession != null)
            {
                _viewModel.AddSession(window.NewSession);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteSelected();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
     
            
            if (_viewModel.SelectedSession == null)
                return;

            var window = new EditSessionWindow(_viewModel.SelectedSession);
            if (window.ShowDialog() == true && window.NewSession != null)
            {
                _viewModel.EditSession(window.NewSession);
            }

        }
    }
}