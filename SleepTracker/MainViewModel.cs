﻿using SleepTracker.Data;
using SleepTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepTracker
{

    internal class MainViewModel
    {
        public ObservableCollection<SleepSession> Sessions { get; set; }
        public SleepSession? SelectedSession { get; set; }

        public MainViewModel()
        {
            using var db = new AppDbContext();
            var sessions = db.SleepSessions
                .OrderByDescending(s => s.Date)
                .ToList();

            Sessions = new ObservableCollection<SleepSession>(sessions);
        }

        public void AddSample()
        {
            var newSession = new SleepSession
            {
                Date = DateTime.Today,
                SleepTime = new TimeSpan(22, 30, 0),
                WakeUpTime = new TimeSpan(6, 45, 0),
                SleepQuality = 4,
                Notes = "Testowa sesja"
            };

            using var db = new AppDbContext();
            db.SleepSessions.Add(newSession);
            db.SaveChanges();

            Sessions.Insert(0, newSession);
            RefreshSessions();
        }
        public void AddSession(SleepSession session)
        {
            using var db = new AppDbContext();
            db.SleepSessions.Add(session);
            
            db.SaveChanges();

            Sessions.Insert(0, session);
            RefreshSessions();

        }
        public void EditSession(SleepSession session)
        {
            Debug.WriteLine(session.Id);
            using var db = new AppDbContext();
            db.SleepSessions.Update(session);

            db.SaveChanges();

            RefreshSessions();

        }

        public void DeleteSelected()
        {
            if (SelectedSession == null) return;

            using var db = new AppDbContext();
            var toDelete = db.SleepSessions.Find(SelectedSession.Id);

            if (toDelete != null)
            {
                db.SleepSessions.Remove(toDelete);
                db.SaveChanges();
                Sessions.Remove(SelectedSession);
            }
        }
        public void RefreshSessions()
        {
            using var db = new AppDbContext();
            var refreshed = db.SleepSessions
                .OrderByDescending(s => s.Date)
                .ToList();

            Sessions.Clear();
            foreach (var s in refreshed)
                Sessions.Add(s);
        }
    }
}
