using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new[] { 5, 3, 2, 6, 8, 4, 3, 2, 4, 2, 2, 2, };

            //int count = numbers.Count(n => n % 2 == 0);
            double num = numbers.Where(n => 5 < n).Average();
            int total = numbers.Where(n => 5 < n).Sum();
            Console.WriteLine(num);
            Console.WriteLine(total);
        }





        ////nが偶数かどうかを調べる
        //public static bool IsEven(int n) {
        //    return n % 2 == 0; //偶数だとtrueが返される
        //}

        ////nが奇数かどうか調べる
        //public static bool IsNotEven(int n) {
        //    return n % 2 == 1;
        //}

        ////7より大きい数値があるかどうか調べる
        //public static bool IsNumOver(int n) {
        //    return 5 < n;
        //}

        ////public delegate bool Judgement(int value); //デリゲートの宣言
        //public static int Count(int[]numbers, Predicate<int> judge) {
        //    int count = 0;
        //    foreach (var n in numbers) {
        //        if(judge(n) == true) 
        //            count++;
        //    }
        //    return count;
        //}
    }
}
