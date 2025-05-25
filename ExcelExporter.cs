
using System;
using System.IO;
using ClosedXML.Excel;

namespace ZvarovaDeformaciaApp
{
    public static class ExcelExporter
    {
        public static void ExportDoExcel(
            string material, string technologia, string fixacia,
            double hrubka, double dlzka, double q,
            string deltaX, string deltaY, string deltaZ, string gum)
        {
            string subor = $"VystupZvar_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            try
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Výsledok");

                ws.Cell("A1").Value = "Dátum a čas:";
                ws.Cell("B1").Value = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

                ws.Cell("A3").Value = "Materiál:";
                ws.Cell("B3").Value = material;

                ws.Cell("A4").Value = "Technológia:";
                ws.Cell("B4").Value = technologia;

                ws.Cell("A5").Value = "Fixácia:";
                ws.Cell("B5").Value = fixacia;

                ws.Cell("A6").Value = "Hrúbka plechu [mm]:";
                ws.Cell("B6").Value = hrubka;

                ws.Cell("A7").Value = "Dĺžka zvaru [mm]:";
                ws.Cell("B7").Value = dlzka;

                ws.Cell("A8").Value = "Vstupné teplo Q [kJ/cm]:";
                ws.Cell("B8").Value = q;

                ws.Cell("A10").Value = "Výsledky deformácie:";
                ws.Cell("A11").Value = deltaX;
                ws.Cell("A12").Value = deltaY;
                ws.Cell("A13").Value = deltaZ;
                ws.Cell("A14").Value = gum;

                ws.Columns().AdjustToContents();
                wb.SaveAs(subor);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Chyba pri exporte: " + ex.Message);
            }
        }
    }
}
