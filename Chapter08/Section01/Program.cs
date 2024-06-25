using System;
using System.Collections.Generic;
using System.Globalization;
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

            Console.WriteLine("生年月日を入力");
            Console.Write("年：");
            int year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            int month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            int day = int.Parse(Console.ReadLine());

            var bd = new DateTime(year, month, day);

            //和暦
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = bd.ToString("ggyy年M月d日", culture);
            Console.WriteLine(str);

            //生まれてから○○日
            var today = DateTime.Today;
            TimeSpan diff = today - bd;
            Console.WriteLine("生まれてから{0}日目です", diff.Days + 1);

            //switch (dow) {
            //    case DayOfWeek.Sunday:
            //        Console.WriteLine("日曜日");
            //        break;
            //    case DayOfWeek.Monday:
            //        Console.WriteLine("月曜日");
            //        break;
            //    case DayOfWeek.Tuesday:
            //        Console.WriteLine("火曜日");
            //        break;
            //    case DayOfWeek.Wednesday:
            //        Console.WriteLine("水曜日");
            //        break;
            //    case DayOfWeek.Thursday:
            //        Console.WriteLine("木曜日");
            //        break;
            //    case DayOfWeek.Friday:
            //        Console.WriteLine("金曜日");
            //        break;
            //    case DayOfWeek.Saturday:
            //        Console.WriteLine("土曜日");
            //        break;
            //}

            //Console.WriteLine("生年月日を入力");
            //Console.Write("年：");
            //var n = int.Parse(Console.ReadLine());
            //Console.Write("月：");
            //var t = int.Parse(Console.ReadLine());
            //Console.Write("日：");
            //var h = int.Parse(Console.ReadLine());
            
            //var theDay = new DateTime(n, t, h);
            //string 曜日 = theDay.ToString("dddd");
            //Console.WriteLine("あなたは" + 曜日 + "に生まれました");
        }
    }
}
