using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public static class FeetConverter {

       // private const double ratio = 0.3048; //定数
        public static readonly double ratio = 0.3048;

        //メートルからフィートを求める
        public static double MeterToFeet(double meter) {
            return meter / ratio;
        }
        //フィートからメートルを求める
        public static double FeetToMeter(double feet) {
            return feet * ratio;
        }
    }
}
