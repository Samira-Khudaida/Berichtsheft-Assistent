// File: BerichtsheftReminderService.cs
using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace BerichtsheftAssistent
{
    public partial class BerichtsheftReminderService : ServiceBase
    {
        private Timer dailyTimer;
        private readonly string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "service.log");
        private DateTime lastRunDate = DateTime.MinValue;

        public BerichtsheftReminderService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                string logDirectory = Path.GetDirectoryName(logPath);
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }
                Log("Die Ordner logs wurden erstellt.");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("BerichtsheftReminderService",
                   "Fehler beim Erstellen von Ordnern: " + ex.Message,
                   EventLogEntryType.Error);
            }

            dailyTimer = new Timer
            {
                Interval = 60000 // Alle 60 Sekunden prüfen
            };
            dailyTimer.Elapsed += CheckTimeAndRun;
            dailyTimer.Start();

            Log("Dienst gestartet.");
        }

        protected override void OnStop()
        {
            dailyTimer?.Stop();
            Log("Dienst gestoppt.");
        }

        private void CheckTimeAndRun(object sender, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;

            if (!TimeSpan.TryParse(Properties.Settings.Default.ReminderHour.ToString(), out TimeSpan reminderHour))
            {
                Log("Ungültiger Reminder-Hour-Wert in Settings.");
                return;
            }

            if (now.DayOfWeek >= DayOfWeek.Monday && now.DayOfWeek <= DayOfWeek.Friday)
            {
                TimeSpan nowTime = now.TimeOfDay;
                TimeSpan tolerance = TimeSpan.FromMinutes(2);

                if (nowTime >= reminderHour && nowTime <= reminderHour + tolerance && lastRunDate.Date != now.Date)
                {
                    lastRunDate = now.Date;
                    Log($"Reminder ausgelöst am {now:yyyy-MM-dd HH:mm:ss}");

                    try
                    {
                        StartGuiViaTask();
                    }
                    catch (Exception ex)
                    {
                        Log("Fehler beim Starten des GUI-Tasks: " + ex.Message);
                    }
                }
            }
        }

        private void StartGuiViaTask()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "schtasks",
                Arguments = "/Run /TN \"StartGuiReminder\"",
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process.Start(psi);
            Log("GUI über Taskplaner gestartet.");
        }

        private void Log(string msg)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {msg}");
                }
            }
            catch
            {
                // Ignorieren, falls Logging fehlschlägt
            }
        }
    }
}
