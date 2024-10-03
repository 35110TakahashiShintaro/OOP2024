using Section01;
using System;
using System.Collections;
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
            var query = Library.Books.Join(Library.Categories,
                                            book => book.CategoryId,
                                            category => category.Id,
                                            (book, category) => new {
                                                book.Title,
                                                book.PublishedYear,
                                                book.Price,
                                                CategoryName = category.Name,
                                            });

            foreach (var book in query) {
                Console.WriteLine("{0}年{1}円{2}({3})",
                                book.PublishedYear,
                                book.Price,
                                book.Title,
                                book.CategoryName
                                );
            }
        }

        private static void Exercise1_5() {
            var category2016 = Library.Books.Where(b => b.PublishedYear == 2016)
                                          .Select(b => b.CategoryId)
                                          .Distinct()
                                          .Select(id => Library.Categories.First(c => c.Id == id).Name);

            foreach (var category in category2016) {
                Console.WriteLine(category);
            }
        }

        private static void Exercise1_6() {
            var query = Library.Books
                            .Join(Library.Categories,   //結合する２番目のシーケンス
                                    book => book.CategoryId,//対象シーケンスの結合キー
                                    category => category.Id,//２番目のシーケンスの結合キー
                                    (book, category) => new {
                                        book.Title,
                                        CategoryName = category.Name
                                    })
                            .GroupBy(x => x.CategoryName)
                            .OrderBy(x => x.Key);
            foreach (var group in query) {
                Console.WriteLine("#{0}", group.Key);
                foreach (var item in group) {
                    Console.WriteLine("  {0}", item.Title);
                }
            }
        }

        private static void Exercise1_7() {
            var categoriesId = Library.Categories.Single(c => c.Name == "Development").Id;
            var query = Library.Books.Where(b => b.CategoryId == categoriesId)
                                        .GroupBy(b => b.PublishedYear)
                                        .OrderBy(b => b.Key);
            foreach (var group in query) {
                Console.WriteLine("#{0}年", group.Key);
                foreach (var item in group) {
                    Console.WriteLine("  {0}", item.Title);
                }
            }
        }

        private static void Exercise1_8() {
            var categoryBook = Library.Categories
                                      .GroupJoin(
                                         Library.Books,
                                         category => category.Id,
                                         book => book.CategoryId,
                                         (category, books) => new {
                                             CategoryName = category.Name,
                                             BookCount = books.Count()
                                         })
                                      .Where(category => category.BookCount >= 4);



            foreach (var category in categoryBook) {
                Console.WriteLine(category.CategoryName + "(" + category.BookCount + "冊" + ")");
            }
        }
    }
}
