
using System;

namespace ZvarovaDeformaciaApp
{
    public class MaterialProperties
    {
        public string Nazov { get; set; }
        public double Alpha { get; set; }
        public double E { get; set; }
        public double Cp { get; set; }
        public double Lambda { get; set; }
        public double Hustota { get; set; }
    }

    public class VysledokDeformacie
    {
        public double DeltaX { get; set; }
        public double DeltaY { get; set; }
        public double DeltaZ { get; set; }
        public double Tolerancia { get; set; }
    }

    public static class WeldCalculator
    {
        public static VysledokDeformacie VypocitajDeformaciu(MaterialProperties mat, double hrubka, double dlzka, double Q, string fixacia)
        {
            double Tzvar = 1400;
            double Tokolie = 25;
            double deltaT = Tzvar - Tokolie;

            double fixFactor = fixacia.ToLower().Contains("pevná") ? 0.3 :
                               fixacia.ToLower().Contains("čiastočná") ? 0.6 : 1.0;

            double deltaX = mat.Alpha * deltaT * dlzka * fixFactor;
            double deltaY = mat.Alpha * deltaT * hrubka * 0.5 * fixFactor;
            double deltaZ = mat.Alpha * deltaT * hrubka * 0.25 * fixFactor;

            double tol = Math.Sqrt(Math.Pow(0.1 * deltaX, 2) + Math.Pow(0.1 * deltaY, 2) + Math.Pow(0.1 * deltaZ, 2));

            return new VysledokDeformacie
            {
                DeltaX = deltaX,
                DeltaY = deltaY,
                DeltaZ = deltaZ,
                Tolerancia = tol
            };
        }
    }
}
