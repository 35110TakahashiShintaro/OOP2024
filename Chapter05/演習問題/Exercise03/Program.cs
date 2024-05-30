using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            var text2 = "Jackdaws,love my,big sphinx-of_quartz";


            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);

            Exercise3_6(text2);

        }               

        private static void Exercise3_1(string text) {
            int kara = text.Count(c => c == ' ');
            Console.WriteLine("空白数:{0} " + kara);
        }

        private static void Exercise3_2(string text) {

            string replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            var tango = text.Split(' ').Length;
            Console.WriteLine("単語数:{0}" + tango);
        }

        private static void Exercise3_4(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);
            foreach (var word in words) {
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
            var str = text.Split(' ').ToArray();
            StringBuilder ss = new StringBuilder();
            foreach (string word in str) {
                ss.Append(word);
                ss.Append(' ');
            }
            Console.WriteLine(ss);
        }

        private static void Exercise3_6(string text2) {
            var kigo = text2.Split(',','-','_',' ').Where(s => s.Length <= 4);            

            foreach (var word in kigo) {
                Console.WriteLine(word);
            }            
        }
    }
}
