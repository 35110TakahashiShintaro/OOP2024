using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            IEnumerable<string> query = names.Where(s => s.Contains(" "))
                                             .Select(s => s.ToUpper());
            foreach(string s in query) {
                Console.WriteLine(s);
            }





            //var lowerList = list.ConvertAll(s  => s.ToLower());
            //lowerList.ForEach(s => Console.WriteLine(s));

            //var upperList = list.ConvertAll(h => h.ToUpper());
            //lowerList.ForEach(h => Console.WriteLine(h));

            //var removeCount = list.RemoveAll(s => s.Contains("on"));
            //Console.WriteLine(removeCount);

            //list.ForEach(s => Console.WriteLine(s));

            //foreach( var item in list) {
            //    Console.WriteLine(item);
            //}
            //var names = list.Where(s => s.Length <= 9);
            //foreach ( var s in names)
            //    Console.WriteLine(s);
        }

    }
}
