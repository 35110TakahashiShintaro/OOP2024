using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            string st = Console.ReadLine();
            int num;

            string Comma;

            if (int.TryParse(st, out num)) {
                Comma = num.ToString("#,0");
                Console.WriteLine(Comma);
            }
        }
    }
}
