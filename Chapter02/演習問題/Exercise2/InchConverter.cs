using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    internal class InchConverter {
        // private const double ratio = 0.0254; //定数
        public static readonly double ratio = 0.0254;

        //メートルからフィートを求める
        public static double MeterToInch(double meter) {
            return meter / ratio;
        }
        //フィートからメートルを求める
        public static double InchToMeter(double inch) {
            return inch * ratio;
        }
    }
}
