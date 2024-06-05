using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "novelist=谷崎潤一郎;bestMake=春琴抄;birthYear=1886";


            foreach (var part in line.Split(';')) {
                var array = part.Split('=');
                Console.WriteLine("{0}:{1}", ToJapanese(array[0]), array[1]);

                //var zero = array[0];
                //var iti = array[1];
                //var japanese = ToJapanese(zero);

                //Console.WriteLine("{0}:{1}",japanese, iti);
            }

            //string novelist = parts[0].Split('=')[1];
            //string bestMake = parts[1].Split('=')[1];
            //string birthYear = parts[2].Split('=')[1];

            //Console.WriteLine("作家：" + novelist);
            //Console.WriteLine("代表作：" + bestMake);
            //Console.WriteLine("誕生年：" + birthYear);

        }

        //できたら以下のメソッドを完成させて利用する
        static string ToJapanese(string key) {

            switch(key) {
                case "novelist":
                    return "作家";

                case "bestMake":
                    return "代表作";

                case "birthYear":
                    return "誕生年";
            }
            throw new ArgumentException("引数に誤りがあります");
        }
    }
}
