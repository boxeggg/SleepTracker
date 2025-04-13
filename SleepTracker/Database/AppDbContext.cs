using Microsoft.EntityFrameworkCore;
using SleepTracker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepTracker.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<SleepSession> SleepSessions => Set<SleepSession>(); 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source=C://Users//kamil//source//repos//SleepTracker//SleepTracker//sleeptracker.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SleepSession>().HasData(
                new SleepSession
                {
                    Id = 1,
                    Date = new DateTime(2024, 4, 10),
                    SleepTime = new TimeSpan(23, 0, 0),
                    WakeUpTime = new TimeSpan(6, 30, 0),
                    SleepQuality = 4,
                    Notes = "Dobry sen, bez pobudek"
                },
                new SleepSession
                {
                    Id = 2,
                    Date = new DateTime(2024, 4, 11),
                    SleepTime = new TimeSpan(0, 30, 0),
                    WakeUpTime = new TimeSpan(7, 45, 0),
                    SleepQuality = 2,
                    Notes = "Zbyt późno spać, zmęczenie rano"
                },
                new SleepSession
                {
                    Id = 3,
                    Date = new DateTime(2024, 4, 12),
                    SleepTime = new TimeSpan(22, 45, 0),
                    WakeUpTime = new TimeSpan(6, 0, 0),
                    SleepQuality = 5,
                    Notes = "Najlepszy sen w tygodniu!"
                }
            );
        }
    }
}