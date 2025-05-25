
using System;
using System.Data.SQLite;

namespace ZvarovaDeformaciaApp
{
    public static class MaterialLoader
    {
        public static MaterialProperties NacitajMaterial(string dbPath, string nazovMaterialu)
        {
            try
            {
                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT * FROM Materialy WHERE Nazov = @nazov", conn);
                    cmd.Parameters.AddWithValue("@nazov", nazovMaterialu);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new MaterialProperties
                        {
                            Nazov = reader["Nazov"].ToString(),
                            Alpha = Convert.ToDouble(reader["Alpha"]),
                            E = Convert.ToDouble(reader["E"]),
                            Cp = Convert.ToDouble(reader["Cp"]),
                            Lambda = Convert.ToDouble(reader["Lambda"]),
                            Hustota = Convert.ToDouble(reader["Hustota"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Chyba pri načítaní materiálu: " + ex.Message);
            }
            return null;
        }
    }
}
