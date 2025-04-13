using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepTracker.Models
{
    public class SleepSession
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan SleepTime { get; set; }

        [Required]
        public TimeSpan WakeUpTime { get; set; }

        [Range(1, 5)]
        public int SleepQuality { get; set; }

        public string? Notes { get; set; }

        // Nieprzechowywana w bazie – pomocnicza właściwość do obliczania długości snu
        public TimeSpan Duration
        {
            get
            {
                DateTime sleepDateTime = Date.Date + SleepTime;
                DateTime wakeUpDateTime = Date.Date + WakeUpTime;

                if (wakeUpDateTime <= sleepDateTime)
                    wakeUpDateTime = wakeUpDateTime.AddDays(1); // przeskok przez północ

                return wakeUpDateTime - sleepDateTime;
            }
        }
    }
}