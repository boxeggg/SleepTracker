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
    public partial class AddSessionWindow : Window
    {
        public SleepSession? NewSession { get; private set; }

        public AddSessionWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var date = DatePicker.SelectedDate ?? DateTime.Today;
                var sleepTime = TimeSpan.Parse(SleepTimeBox.Text);
                var wakeTime = TimeSpan.Parse(WakeUpTimeBox.Text);
                var quality = int.Parse(QualityBox.Text);
                var notes = NotesBox.Text;

                NewSession = new SleepSession
                {
                    Date = date,
                    SleepTime = sleepTime,
                    WakeUpTime = wakeTime,
                    SleepQuality = quality,
                    Notes = notes
                };

                DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Upewnij się, że wszystkie pola są poprawnie wypełnione.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
