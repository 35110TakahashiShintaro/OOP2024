using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> kensyo = new Dictionary<string, string>();

        static void Main(string[] args) {
            String inputken, inputsyo;
            //入力処理
            Console.WriteLine("県庁所在地の登録");
            while (true) {
                //都道府県の入力
                Console.Write("都道府県:");
                inputken = Console.ReadLine();

                if (inputken == null) {
                    break;
                }
                //県庁所在地の入力
                Console.Write("県庁所在地:");
                inputsyo = Console.ReadLine();

                //既に都道府県が登録されているか？
                if (kensyo.ContainsKey(inputken)) {
                    //登録済み
                    Console.WriteLine("上書きしますか？(Y/N)");
                    if (Console.ReadLine() == "N") {
                        continue;
                    }
                }
                kensyo[inputken] = inputsyo;  //登録


                //for (int i = 1; i <= 5; i++) {
                //Console.WriteLine("都道府県名を入力してください:");
                //inputken = Console.ReadLine();
                //if (inputken != null) {
                //    Console.WriteLine("県庁所在地を入力してください:");
                //    inputsyo = Console.ReadLine();

                //    if (kensyo.ContainsKey(inputken)) {
                //        Console.WriteLine("この都道府県名は既に登録されています。上書きしますか？ (y/n)");
                //        if (Console.ReadLine() == "n") {
                //            continue;
                //        }
                //    } 
                //    kensyo[inputken] = inputsyo;
                //} else {
                //    break;
                //}

            }
            Boolean endFlag = false;    //終了フラグ（無限ループを抜け出す用）
            while (!endFlag) {
                switch (menu()) {
                    case "1":
                        Allout(); 
                        break;
                    case "2":
                        kensaku(); 
                        break;
                    case "9":
                        endFlag = true; //終了フラグＯＮ
                        break;
                }
                if (endFlag) {
                    break;
                }
            }

        }

        //メニュー表示
        private static string menu() {
            Console.WriteLine("**** メニュー ****");
            Console.WriteLine("1：一覧表示");
            Console.WriteLine("2：検索");
            Console.WriteLine("9：終了");
            Console.Write(">");
            String menuSelect = Console.ReadLine();
            return menuSelect;
        }

        //一覧出力処理
        private static string Allout() {
            foreach (var item in kensyo) {
                Console.WriteLine("{0}の県庁所在地は{1}です。", item.Key, item.Value);
            }
            return Console.ReadLine();
        }

        //検索処理
        private static string kensaku() {
            Console.Write("都道府県:");
            String searchPref = Console.ReadLine();
            Console.WriteLine(searchPref + "の県庁所在地は" + kensyo[searchPref] + "です");
            return Console.ReadLine();
        }
    }
}
