using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var groops = Library.Books.GroupBy(b => b.PublishedYear)
                                      .OrderBy(g => g.Key);
            
            foreach (var book in groops) {
                Console.WriteLine($"{book.Key}年");
                foreach (var books in book) {
                    Console.WriteLine($"{books}");
                }
            }
            


        }
    }
}
