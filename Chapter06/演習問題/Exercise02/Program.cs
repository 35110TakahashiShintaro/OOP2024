using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        
        static void Main(string[] args) {
            var books = new List<Book> {
           new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
           new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
           new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
           new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
           new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
           new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
           new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
        };

            Exercise2_1(books);
            Console.WriteLine("-----");

            Exercise2_2(books);

            Console.WriteLine("-----");

            Exercise2_3(books);
            Console.WriteLine("-----");

            Exercise2_4(books);
            Console.WriteLine("-----");

            Exercise2_5(books);
            Console.WriteLine("-----");

            Exercise2_6(books);

            Console.WriteLine("-----");

            Exercise2_7(books);
        }

        private static void Exercise2_1(List<Book> books) {
            var targetBook = books.Where(book => book.Title == "ワンダフル・C#ライフ").FirstOrDefault();
            Console.WriteLine("価格:{0}, ページ数:{1}",targetBook.Price,targetBook.Pages);
        }

        private static void Exercise2_2(List<Book> books) {
            int count = books.Count(book => book.Title.Contains("C#"));
            Console.WriteLine("C#含む:{0}",count);
        }

        private static void Exercise2_3(List<Book> books) {
            int count = books.Count(book => book.Title.Contains("C#"));
            double avg = books.Average(book => book.Pages);
            Console.WriteLine("C#の平均ページ数:{0}",avg);
        }

        private static void Exercise2_4(List<Book> books) {
            var izyou = books.FirstOrDefault(book => book.Price >= 4000);
            Console.WriteLine("価格が4000以上の最初の本:{0}", izyou.Title);
        }

        private static void Exercise2_5(List<Book> books) {
            var miman = books.Where(book => book.Price < 4000);
            int maxPages = miman.Max(book => book.Pages);
            Console.WriteLine("価格が4000未満の最大のページ数:{0}", maxPages);
        }

        private static void Exercise2_6(List<Book> books) {
            var page400 = books.Where(book => book.Pages >= 400);
            var kou = page400.OrderByDescending(book => book.Price);
            foreach (var book in kou) {
                Console.WriteLine("ページ400以上のタイトル:{0},価格:{1}",book.Title, book.Price);
            }
        }

        private static void Exercise2_7(List<Book> books) {
            var Books500 = books.Where(book => book.Title.Contains("C#") && book.Pages <= 500);
            foreach (var book in Books500) {
                Console.WriteLine(book.Title);
            }
        }
    }
}
