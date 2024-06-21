using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var dt1 = new DateTime(2024, 6, 19);
            //var dt2 = new DateTime(2017, 4, 26, 8, 45, 20);
            //Console.WriteLine(dt1);
            //Console.WriteLine(dt2);

            //var today = DateTime.Today;
            //var now = DateTime.Now;
            //Console.WriteLine("Today : {0}", today);
            //Console.WriteLine("Now : {0}", now);

            //var isLeapYear = DateTime.IsLeapYear(1014);
            //if (isLeapYear) {
            //    Console.WriteLine("閏年です");
            //} else {
            //    Console.WriteLine("閏年でない");
            //}
            var bd = new DateTime(2005, 2, 21);
            DayOfWeek dow = bd.DayOfWeek;
            if (dow == DayOfWeek.Monday)
                Console.WriteLine("今日は月曜");

            Console.WriteLine("生年月日を入力");
            Console.Write("年：");
            var n = int.Parse(Console.ReadLine());
            Console.Write("月：");
            var t = int.Parse(Console.ReadLine());
            Console.Write("日：");
            var h = int.Parse(Console.ReadLine());
            
            var theDay = new DateTime(n, t, h);
            string 曜日 = theDay.ToString("dddd");
            Console.WriteLine("あなたは" + 曜日 + "に生まれました");
        }
    }
}
