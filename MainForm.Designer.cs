
using System.Windows.Forms;
using System;

namespace ZvarovaDeformaciaApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboMaterial, comboTechnologia, comboFixacia;
        private System.Windows.Forms.TextBox txtHrubka, txtDlzka, txtQ;
        private System.Windows.Forms.Label lblDeltaX, lblDeltaY, lblDeltaZ, lblGUM;
        private System.Windows.Forms.Button btnVypocitaj, btnMapa, btnExportExcel;
        private System.Windows.Forms.PictureBox pictureBoxMapa;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboMaterial = new System.Windows.Forms.ComboBox();
            this.comboTechnologia = new System.Windows.Forms.ComboBox();
            this.comboFixacia = new System.Windows.Forms.ComboBox();
            this.txtHrubka = new System.Windows.Forms.TextBox();
            this.txtDlzka = new System.Windows.Forms.TextBox();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.lblDeltaX = new System.Windows.Forms.Label();
            this.lblDeltaY = new System.Windows.Forms.Label();
            this.lblDeltaZ = new System.Windows.Forms.Label();
            this.lblGUM = new System.Windows.Forms.Label();
            this.btnVypocitaj = new System.Windows.Forms.Button();
            this.btnMapa = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.pictureBoxMapa = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMapa)).BeginInit();
            this.SuspendLayout();

            // === ComboBoxes ===
            this.comboMaterial.Location = new System.Drawing.Point(20, 20);
            this.comboMaterial.Size = new System.Drawing.Size(200, 24);
            this.comboMaterial.DropDownStyle = ComboBoxStyle.DropDownList;

            this.comboTechnologia.Location = new System.Drawing.Point(20, 60);
            this.comboTechnologia.Size = new System.Drawing.Size(200, 24);
            this.comboTechnologia.Items.AddRange(new string[] { "TIG", "MIG", "Laser", "Plazma" });

            this.comboFixacia.Location = new System.Drawing.Point(20, 100);
            this.comboFixacia.Size = new System.Drawing.Size(200, 24);
            this.comboFixacia.Items.AddRange(new string[] { "Pevná", "Čiastočná", "Voľná" });

            // === TextBoxes ===
            this.txtHrubka.Location = new System.Drawing.Point(250, 20);
            this.txtHrubka.Size = new System.Drawing.Size(100, 22);
            this.txtHrubka.Text = "Hrúbka (mm)";

            this.txtDlzka.Location = new System.Drawing.Point(250, 60);
            this.txtDlzka.Size = new System.Drawing.Size(100, 22);
            this.txtDlzka.Text = "Dĺžka (mm)";

            this.txtQ.Location = new System.Drawing.Point(250, 100);
            this.txtQ.Size = new System.Drawing.Size(100, 22);
            this.txtQ.Text = "Teplo Q";

            // === Tlačidlá ===
            this.btnVypocitaj.Text = "Vypočítať";
            this.btnVypocitaj.Location = new System.Drawing.Point(20, 150);
            this.btnVypocitaj.Click += new EventHandler(this.btnVypocitaj_Click);

            this.btnMapa.Text = "Zobraziť mapu";
            this.btnMapa.Location = new System.Drawing.Point(120, 150);
            this.btnMapa.Click += new EventHandler(this.btnMapa_Click);

            this.btnExportExcel.Text = "Export do Excelu";
            this.btnExportExcel.Location = new System.Drawing.Point(240, 150);
            this.btnExportExcel.Click += new EventHandler(this.btnExportExcel_Click);

            // === Výstupné Labely ===
            this.lblDeltaX.Location = new System.Drawing.Point(20, 200);
            this.lblDeltaX.Size = new System.Drawing.Size(250, 20);

            this.lblDeltaY.Location = new System.Drawing.Point(20, 230);
            this.lblDeltaY.Size = new System.Drawing.Size(250, 20);

            this.lblDeltaZ.Location = new System.Drawing.Point(20, 260);
            this.lblDeltaZ.Size = new System.Drawing.Size(250, 20);

            this.lblGUM.Location = new System.Drawing.Point(20, 290);
            this.lblGUM.Size = new System.Drawing.Size(250, 20);

            // === Obrázok tepelnej mapy ===
            this.pictureBoxMapa.Location = new System.Drawing.Point(400, 20);
            this.pictureBoxMapa.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxMapa.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBoxMapa.SizeMode = PictureBoxSizeMode.Zoom;

            // === Pridanie do formulára ===
            this.Controls.Add(this.comboMaterial);
            this.Controls.Add(this.comboTechnologia);
            this.Controls.Add(this.comboFixacia);
            this.Controls.Add(this.txtHrubka);
            this.Controls.Add(this.txtDlzka);
            this.Controls.Add(this.txtQ);
            this.Controls.Add(this.btnVypocitaj);
            this.Controls.Add(this.btnMapa);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.lblDeltaX);
            this.Controls.Add(this.lblDeltaY);
            this.Controls.Add(this.lblDeltaZ);
            this.Controls.Add(this.lblGUM);
            this.Controls.Add(this.pictureBoxMapa);

            // === Nastavenie formulára ===
            this.Text = "Predikcia zvarovej deformácie";
            this.ClientSize = new System.Drawing.Size(750, 400);
            this.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMapa)).EndInit();
        }
    }
}
