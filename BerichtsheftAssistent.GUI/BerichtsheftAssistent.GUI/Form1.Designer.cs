namespace BerichtsheftAssistent.GUI
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtAktivitaeten = new System.Windows.Forms.TextBox();
            this.txtSchwerpunkt = new System.Windows.Forms.TextBox();
            this.txtGelernt = new System.Windows.Forms.TextBox();
            this.labelAktivitaeten = new System.Windows.Forms.Label();
            this.labelSchwerpunkt = new System.Windows.Forms.Label();
            this.labelGelernt = new System.Windows.Forms.Label();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.btnExportTxt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtAktivitaeten
            // 
            this.txtAktivitaeten.BackColor = System.Drawing.SystemColors.Window;
            this.txtAktivitaeten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAktivitaeten.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAktivitaeten.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAktivitaeten.Location = new System.Drawing.Point(435, 66);
            this.txtAktivitaeten.Name = "txtAktivitaeten";
            this.txtAktivitaeten.Size = new System.Drawing.Size(292, 18);
            this.txtAktivitaeten.TabIndex = 0;
            // 
            // txtSchwerpunkt
            // 
            this.txtSchwerpunkt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSchwerpunkt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchwerpunkt.Location = new System.Drawing.Point(435, 172);
            this.txtSchwerpunkt.Name = "txtSchwerpunkt";
            this.txtSchwerpunkt.Size = new System.Drawing.Size(292, 18);
            this.txtSchwerpunkt.TabIndex = 1;
            // 
            // txtGelernt
            // 
            this.txtGelernt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGelernt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGelernt.Location = new System.Drawing.Point(435, 297);
            this.txtGelernt.Name = "txtGelernt";
            this.txtGelernt.Size = new System.Drawing.Size(292, 18);
            this.txtGelernt.TabIndex = 2;
            // 
            // labelAktivitaeten
            // 
            this.labelAktivitaeten.AutoSize = true;
            this.labelAktivitaeten.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAktivitaeten.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelAktivitaeten.Location = new System.Drawing.Point(437, 32);
            this.labelAktivitaeten.Name = "labelAktivitaeten";
            this.labelAktivitaeten.Size = new System.Drawing.Size(222, 20);
            this.labelAktivitaeten.TabIndex = 3;
            this.labelAktivitaeten.Text = "Was hast du heute gemacht ? 🦾";
            // 
            // labelSchwerpunkt
            // 
            this.labelSchwerpunkt.AutoSize = true;
            this.labelSchwerpunkt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSchwerpunkt.Location = new System.Drawing.Point(437, 143);
            this.labelSchwerpunkt.Name = "labelSchwerpunkt";
            this.labelSchwerpunkt.Size = new System.Drawing.Size(205, 20);
            this.labelSchwerpunkt.TabIndex = 4;
            this.labelSchwerpunkt.Text = "Was war der Schwerpunkt? 🤺";
            // 
            // labelGelernt
            // 
            this.labelGelernt.AutoSize = true;
            this.labelGelernt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGelernt.Location = new System.Drawing.Point(437, 265);
            this.labelGelernt.Name = "labelGelernt";
            this.labelGelernt.Size = new System.Drawing.Size(167, 20);
            this.labelGelernt.TabIndex = 5;
            this.labelGelernt.Text = "Was hast du gelernt? 🧠";
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.BackColor = System.Drawing.SystemColors.Window;
            this.btnSpeichern.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSpeichern.FlatAppearance.BorderSize = 0;
            this.btnSpeichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeichern.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeichern.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSpeichern.Location = new System.Drawing.Point(56, 66);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(152, 58);
            this.btnSpeichern.TabIndex = 6;
            this.btnSpeichern.Text = "Speichern 📥";
            this.btnSpeichern.UseVisualStyleBackColor = false;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // btnExportTxt
            // 
            this.btnExportTxt.Location = new System.Drawing.Point(56, 143);
            this.btnExportTxt.Name = "btnExportTxt";
            this.btnExportTxt.Size = new System.Drawing.Size(152, 58);
            this.btnExportTxt.TabIndex = 7;
            this.btnExportTxt.Text = "TXT-Datei \r\nexportieren 📤";
            this.btnExportTxt.UseVisualStyleBackColor = true;
            this.btnExportTxt.Click += new System.EventHandler(this.btnExportTxt_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel1.Location = new System.Drawing.Point(435, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 1);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel2.Location = new System.Drawing.Point(437, 189);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 1);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel3.Location = new System.Drawing.Point(437, 314);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(286, 1);
            this.panel3.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExportTxt);
            this.Controls.Add(this.btnSpeichern);
            this.Controls.Add(this.labelGelernt);
            this.Controls.Add(this.labelSchwerpunkt);
            this.Controls.Add(this.labelAktivitaeten);
            this.Controls.Add(this.txtGelernt);
            this.Controls.Add(this.txtSchwerpunkt);
            this.Controls.Add(this.txtAktivitaeten);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Berichtsheft  Assistent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAktivitaeten;
        private System.Windows.Forms.TextBox txtSchwerpunkt;
        private System.Windows.Forms.TextBox txtGelernt;
        private System.Windows.Forms.Label labelAktivitaeten;
        private System.Windows.Forms.Label labelSchwerpunkt;
        private System.Windows.Forms.Label labelGelernt;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.Button btnExportTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

