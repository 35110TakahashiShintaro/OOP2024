using Section01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books
                               .Max(x => x.Price);
            var book = Library.Books
                                  .First(c => c.Price == max);
            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            var booksYear = Library.Books
                                   .GroupBy(b => b.PublishedYear)
                                   .Select(g => new { Year = g.Key, Count = g.Count() });

            foreach (var item in booksYear) {
                Console.WriteLine($"{item.Year}年: {item.Count}冊");
            }
        }

        private static void Exercise1_4() {
        }

        private static void Exercise1_5() {
        }

        private static void Exercise1_6() {
        }

        private static void Exercise1_7() {
        }

        private static void Exercise1_8() {
        }
    }
}
