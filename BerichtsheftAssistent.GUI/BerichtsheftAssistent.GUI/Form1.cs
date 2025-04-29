// File: Form1.cs (Bereinigt – Reminder-Timer entfernt)
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BerichtsheftAssistent.GUI
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect,
                                                        int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public Form1()
        {
            InitializeComponent();
            StyleButton(btnSpeichern);
            StyleButton(btnExportTxt);
            CleanOldFiles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            base.OnPaintBackground(e);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(221, 160, 221),
                Color.FromArgb(138, 43, 226),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void StyleButton(Button bnt)
        {
            bnt.FlatStyle = FlatStyle.Flat;
            bnt.FlatAppearance.BorderSize = 0;
            bnt.BackColor = Color.White;
            bnt.ForeColor = Color.FromArgb(138, 43, 226);
            bnt.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            bnt.Cursor = Cursors.Hand;
            bnt.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, bnt.Width, bnt.Height, 20, 20));
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            try
            {
                string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TagesBerichte");
                Directory.CreateDirectory(dataPath);

                DateTime heute = DateTime.Today;
                int tageSeitMontag = (int)heute.DayOfWeek - 1;
                if (tageSeitMontag < 0) tageSeitMontag = 6;

                DateTime wochenStart = heute.AddDays(-tageSeitMontag);
                DateTime wochenEnde = wochenStart.AddDays(4);

                string dateiname = $"woche_{wochenStart:dd-MM-yyyy}_bis_{wochenEnde:dd-MM-yyyy}.txt";
                string filePath = Path.Combine(dataPath, dateiname);

                StringBuilder eintragBuilder = new StringBuilder();
                eintragBuilder.AppendLine($"================ {heute:dddd, dd.MM.yyyy} ================");
                eintragBuilder.AppendLine();

                if (!string.IsNullOrWhiteSpace(txtAktivitaeten.Text))
                {
                    eintragBuilder.AppendLine("Aktivität:");
                    eintragBuilder.AppendLine(txtAktivitaeten.Text.Trim());
                    eintragBuilder.AppendLine();
                }

                if (!string.IsNullOrWhiteSpace(txtSchwerpunkt.Text))
                {
                    eintragBuilder.AppendLine("Schwerpunkt:");
                    eintragBuilder.AppendLine(txtSchwerpunkt.Text.Trim());
                    eintragBuilder.AppendLine();
                }

                if (!string.IsNullOrWhiteSpace(txtGelernt.Text))
                {
                    eintragBuilder.AppendLine("Gelernt:");
                    eintragBuilder.AppendLine(txtGelernt.Text.Trim());
                    eintragBuilder.AppendLine();
                }

                eintragBuilder.AppendLine("------------------------------------------------------");
                eintragBuilder.AppendLine();

                File.AppendAllText(filePath, eintragBuilder.ToString() + Environment.NewLine, Encoding.UTF8);

                new CustomMessageBox("✅ Gespeichert", "Tages-Eintrag wurde gespeichert!").ShowDialog();

                txtAktivitaeten.Clear();
                txtSchwerpunkt.Clear();
                txtGelernt.Clear();
            }
            catch (Exception ex)
            {
                new CustomMessageBox("❌ Fehler", "Fehler beim Speichern:\n" + ex.Message).ShowDialog();
            }
        }

        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            try
            {
                string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TagesBerichte");
                string exportePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WochenBerichte");
                Directory.CreateDirectory(exportePath);

                DateTime heute = DateTime.Today;
                int tageSeitMontag = (int)heute.DayOfWeek - 1;
                if (tageSeitMontag < 0) tageSeitMontag = 6;

                DateTime wochenStart = heute.AddDays(-tageSeitMontag);
                DateTime wochenEnde = wochenStart.AddDays(4);

                string dateiname = $"woche_{wochenStart:dd-MM-yyyy}_bis_{wochenEnde:dd-MM-yyyy}.txt";
                string filePath = Path.Combine(dataPath, dateiname);
                string exportFilePath = Path.Combine(exportePath, dateiname);

                if (File.Exists(filePath))
                {
                    File.Copy(filePath, exportFilePath, true);
                    new CustomMessageBox("✅ Export erfolgreich", $"Die Datei wurde exportiert nach:\n{exportFilePath}", "success").ShowDialog();
                }
                else
                {
                    new CustomMessageBox("⚠️ Keine Datei", "Keine Wochen-Datei gefunden zum Exportieren.", "warning").ShowDialog();
                }
            }
            catch (Exception ex)
            {
                new CustomMessageBox("❌ Fehler beim Exportieren", ex.Message, "error").ShowDialog();
            }
        }

        private void CleanOldFiles()
        {
            try
            {
                string[] ordner = {
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TagesBerichte"),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WochenBerichte")
                };

                foreach (var ordnerPfad in ordner)
                {
                    if (Directory.Exists(ordnerPfad))
                    {
                        var dateien = Directory.GetFiles(ordnerPfad, "*.txt");
                        foreach (var datei in dateien)
                        {
                            DateTime erstelltAm = File.GetCreationTime(datei);
                            if ((DateTime.Now - erstelltAm).TotalDays > 90)
                            {
                                File.Delete(datei);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new CustomMessageBox("⚠️ Aufräumen fehlgeschlagen", ex.Message, "warning").ShowDialog();
            }
        }
    }
}
