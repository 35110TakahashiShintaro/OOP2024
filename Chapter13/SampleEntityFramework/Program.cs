using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework {
    internal class Program {
        static void Main(string[] args) {
            //InsertBooks();
            //AddAuthors();
            //AddBooks();
            //UpdateBook();
            Console.WriteLine("1-2");
            DisplayBooks2();

            Console.WriteLine();
            Console.WriteLine("1-3");
            DisplayBooks3();

            Console.WriteLine();
            Console.WriteLine("1-4");
            Exercise1_4();

            Console.WriteLine();
            Console.WriteLine("1-5");
            Exercise1_5();

            Console.ReadLine();
        }
        static void DisplayBooks2() {
            using (var db = new BooksDbContext()) {
                foreach (var book in db.Books.ToList()) {
                    Console.WriteLine("{0}{1}{2}({3:yyyy/MM/dd})",
                    book.Title, book.PublishedYear,
                    book.Author.Name, book.Author.Birthday);
                }
            }
        }
        static void DisplayBooks3() {
            using (var db = new BooksDbContext()) {
                int maxTitle = db.Books.Max(b => b.Title.Length);

                var longTitle = db.Books
                    .Where(b => b.Title.Length == maxTitle)
                    .ToList();

                foreach (var book in longTitle) {
                    Console.WriteLine(book.Title + " " + book.Author.Name);
                }
            }
        }
        private static void Exercise1_4() {
            using (var db = new BooksDbContext()) {
                var oldBooks = db.Books
                    .OrderBy(b => b.PublishedYear)
                    .Include(nameof(Author))
                    .Take(3);

                foreach (var book in oldBooks) {
                    Console.WriteLine(book.Title + " " + book.Author.Name);
                }
            }
        }

        private static void Exercise1_5() {
            using (var db = new BooksDbContext()) {
                var authors = db.Authors
                                .OrderByDescending(a => a.Birthday)
                                .ToList();

                foreach (var author in authors) {
                    Console.WriteLine($"著者: {author.Name}");

                    foreach (var book in author.Books) {
                        Console.WriteLine($"タイトル: {book.Title}, 発行年: {book.PublishedYear}");
                    }
                }
            }
        }

        private static void DeleteBooks() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.SingleOrDefault(x => x.Id == 10);
                if (book != null) {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }

        private static void UpdateBook() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.Single(x => x.Title == "銀河鉄道の夜");
                book.PublishedYear = 2016;
                db.SaveChanges();
            }

        }
        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);

                var book2 = new Book {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges();   //データベースを更新

            }
        }

        

        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books.ToList();
            }
        }

        

        private static void AddAuthors() {
            using (var db = new BooksDbContext()) {
                var author1 = new Author {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "M",
                    Name = "菊池寛"
                };
                db.Authors.Add(author1);
                var author2 = new Author {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "川端康成",
                };
                db.Authors.Add(author2);
                db.SaveChanges();
            }

        }
        

        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
                var author1 = db.Authors.Single(a => a.Name == "夏目漱石");
                var book1 = new Book {
                    Title = "こころ",
                    PublishedYear = 1991,
                    Author = author1,
                };
                db.Books.Add(book1);
                var author2 = db.Authors.Single(a => a.Name == "川端康成");
                var book2 = new Book {
                    Title = "伊豆の踊子",
                    PublishedYear = 2003,
                    Author = author2,
                };
                db.Books.Add(book2);
                var author3 = db.Authors.Single(a => a.Name == "菊池寛");
                var book3 = new Book {
                    Title = "真珠夫人",
                    PublishedYear = 2002,
                    Author = author3,
                };
                db.Books.Add(book3);
                var author4 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book4 = new Book {
                    Title = "注文の多い料理店",
                    PublishedYear = 2000,
                    Author = author4,
                };
                db.Books.Add(book4);
                db.SaveChanges();
            }
        }
    }
}