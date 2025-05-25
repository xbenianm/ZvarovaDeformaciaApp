
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ZvarovaDeformaciaApp
{
    public partial class MainForm : Form
    {
        private string dbPath = "materials.sqlite";

        public MainForm()
        {
            InitializeComponent();
            NacitajMaterialy();
            comboTechnologia.SelectedIndex = 0;
            comboFixacia.SelectedIndex = 0;
        }

        private void NacitajMaterialy()
        {
            try
            {
                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT Nazov FROM Materialy", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboMaterial.Items.Add(reader["Nazov"].ToString());
                    }
                    if (comboMaterial.Items.Count > 0)
                        comboMaterial.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba pri načítaní databázy: " + ex.Message);
            }
        }

        private void btnVypocitaj_Click(object sender, EventArgs e)
        {
            string material = comboMaterial.Text;
            string technologia = comboTechnologia.Text;
            string fixacia = comboFixacia.Text;

            if (!double.TryParse(txtHrubka.Text, out double hrubka) ||
                !double.TryParse(txtDlzka.Text, out double dlzka))
            {
                MessageBox.Show("Zadajte platné číselné hodnoty pre hrúbku a dĺžku.");
                return;
            }

            // --- Vypočítať alebo načítať Q ---
            double q;
            if (!double.TryParse(txtQ.Text, out q))
            {
                switch (technologia.ToLower())
                {
                    case "mig": q = 12; break;
                    case "tig": q = 10; break;
                    case "laser": q = 5; break;
                    case "plazma": q = 8; break;
                    default: q = 10; break;
                }

                MessageBox.Show($"Teplo Q nebolo zadané. Používam predvolenú hodnotu Q = {q} kJ/cm pre technológiu {technologia}.",
                    "Automatický výpočet Q", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var mat = MaterialLoader.NacitajMaterial(dbPath, material);
            if (mat == null)
            {
                MessageBox.Show("Nepodarilo sa načítať vlastnosti materiálu.");
                return;
            }

            var vysledok = WeldCalculator.VypocitajDeformaciu(mat, hrubka, dlzka, q, fixacia);

            lblDeltaX.Text = $"ΔX: {vysledok.DeltaX:F3} mm";
            lblDeltaY.Text = $"ΔY: {vysledok.DeltaY:F3} mm";
            lblDeltaZ.Text = $"ΔZ: {vysledok.DeltaZ:F3} mm";
            lblGUM.Text = $"GUM ±: {vysledok.Tolerancia:F3} mm";
        }

        private void btnMapa_Click(object sender, EventArgs e)
        {
            if (File.Exists("thermalmap.png"))
            {
                pictureBoxMapa.Image = Image.FromFile("thermalmap.png");
            }
            else
            {
                MessageBox.Show("Obrázok tepelnej mapy (thermalmap.png) sa nenašiel.");
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string material = comboMaterial.Text;
            string technologia = comboTechnologia.Text;
            string fixacia = comboFixacia.Text;

            double.TryParse(txtHrubka.Text, out double hrubka);
            double.TryParse(txtDlzka.Text, out double dlzka);
            double.TryParse(txtQ.Text, out double q);

            ExcelExporter.ExportDoExcel(material, technologia, fixacia, hrubka, dlzka, q,
                lblDeltaX.Text, lblDeltaY.Text, lblDeltaZ.Text, lblGUM.Text);
        }
    }
}
