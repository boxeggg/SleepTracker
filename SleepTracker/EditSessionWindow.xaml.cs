using SleepTracker.Models;
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

namespace SleepTracker
{
    /// <summary>
    /// Logika interakcji dla klasy EditSessionWindow.xaml
    /// </summary>
    public partial class EditSessionWindow : Window
    {
        public SleepSession? OldSession { get; private set; }
        public SleepSession? NewSession { get; private set; }

        public EditSessionWindow(SleepSession sessionToEdit)
        {
            InitializeComponent();

            OldSession = sessionToEdit;

          
            NewSession = new SleepSession
            {
                Id = sessionToEdit.Id,
                Date = sessionToEdit.Date,
                SleepTime = sessionToEdit.SleepTime,
                WakeUpTime = sessionToEdit.WakeUpTime,
                SleepQuality = sessionToEdit.SleepQuality,
                Notes = sessionToEdit.Notes
            };

           
            DataContext = NewSession;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
