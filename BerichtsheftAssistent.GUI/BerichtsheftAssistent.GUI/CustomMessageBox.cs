using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerichtsheftAssistent.GUI
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string titel, string nachricht, string typ = "info")
        {
            InitializeComponent();
            this.Text = titel;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(400, 140);

            this.BackColor = Color.MediumPurple;


            //Abgerundetet Ecken
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));



            //Farbe je nach Typ
            Color backgroundColor;
            switch (typ.ToLower())
            {

                case "success":
                    backgroundColor = Color.MediumPurple;
                    break;
                case "error":
                    backgroundColor = Color.MediumPurple;
                    break;
                case "warning":
                    backgroundColor = Color.MediumPurple;
                    break;
                default:
                    backgroundColor = Color.MediumPurple;
                    break;
            }
            this.BackColor = backgroundColor;



            //Label erstellen
            Label lbl = new Label();
            lbl.Text = nachricht;
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Segoe UI", 11);
            lbl.AutoSize = false;
            lbl.Size = new Size(360, 50);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Location = new Point(20, 20);
            lbl.BackColor = Color.Transparent;
            this.Controls.Add(lbl);


            //Button erstellen
            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            okButton.Size = new Size(100, 35);
            okButton.Location = new Point((this.Width - okButton.Width) / 2, 80);
            okButton.FlatStyle = FlatStyle.Flat;
            okButton.BackColor = Color.White;
            okButton.ForeColor = Color.MediumPurple;
            okButton.FlatAppearance.BorderSize = 0;
            okButton.Click += (s, e) => this.Close();
            this.Controls.Add(okButton);

        }
            //Gradient - Background 

        protected override void OnPaintBackground(PaintEventArgs e)
        {

            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(221, 160, 221), // heller Lila-Ton
                Color.FromArgb(138, 43, 226),  // dunkler Lila-Ton
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }



        }


        // DLL-Import für abgerundete Ecken
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect,
                                                        int nBottomRect, int nWidthEllipse, int nHeightEllipse);



    }
       
    
}
