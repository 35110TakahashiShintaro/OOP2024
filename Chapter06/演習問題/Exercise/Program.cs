using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
        }

        private static void Exercise1_1(int[] numbers) {            
            Console.WriteLine(numbers.Max());
        }

        private static void Exercise1_2(int[] numbers) {
            Console.WriteLine(numbers.Reverse().Skip(1).First());
        }
                
        private static void Exercise1_3(int[] numbers) {
            foreach(int num in numbers) {
                Console.WriteLine(num.ToString());
            }
        }

        private static void Exercise1_4(int[] numbers) {
            var Numbers = numbers.OrderBy(x => x).Take(3);
            foreach (int num in Numbers) {
                Console.WriteLine(num);
            }
        }

        private static void Exercise1_5(int[] numbers) {
            var zyufuku = numbers.Distinct();
            foreach (int num in zyufuku) {
                if(10 < num) {
                    Console.WriteLine(num);
                } else {

                }
            }
        }
    }
}

