﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            // 3.1.1
            Exercise1_1(numbers);
            Console.WriteLine("-----");

            // 3.1.2
            Exercise1_2(numbers);
            Console.WriteLine("-----");

            // 3.1.3
            Exercise1_3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise1_4(numbers);
        }

        private static void Exercise1_1(List<int> numbers) {
            var en = numbers.Exists(n => n % 9 == 0 || n % 8 == 0);
            Console.WriteLine(en);
        }

        private static void Exercise1_2(List<int> numbers) {
            numbers.ForEach(n => Console.WriteLine(n / 2));            
        }

        private static void Exercise1_3(List<int> numbers) {
            numbers.Where(n => 50 <= n);
        }

        private static void Exercise1_4(List<int> numbers) {
            var bi = numbers.Select(n => n * 2);
            Console.WriteLine(numbers);
        }
    }
}
