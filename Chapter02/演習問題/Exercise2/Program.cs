using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    internal class Program {
        static void Main(string[] args) {

            if (args.Length >= 1 && args[0] == "-tom") {
                //インチからメートルへの対応表を出力
                PrintInchToMeterList(int.Parse(args[1]), int.Parse(args[2]));
            } else {
                //メートルからインチへの対応表を出力
                PrintMeterToMeterList(int.Parse(args[1]), int.Parse(args[2]));
            }


        }
        private static void PrintInchToMeterList(int start, int stop) {
            for (double inch = start; inch <= stop; inch++) {
                double meter = InchConverter.InchToMeter(inch);
                Console.WriteLine("{0} ic = {1:0.0000} m", inch, meter);
            }
        }
        private static void PrintMeterToMeterList(int start, int stop) {
            for (double meter = start; meter <= stop; meter++) {
                double inch = InchConverter.MeterToInch(meter);
                Console.WriteLine("{0} m = {1:0.0000} ic", meter, inch);
            }
        }
    }
}
