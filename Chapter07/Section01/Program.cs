using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var kensyo = new Dictionary<string, string>();
                for (int i = 1; i <= 5; i++) {
                Console.WriteLine("都道府県名を入力してください:");
                string inputken = Console.ReadLine();
                if (inputken != null) {
                    Console.WriteLine("県庁所在地を入力してください:");
                    string inputsyo = Console.ReadLine();

                    if (kensyo.ContainsKey(inputken)) {
                        Console.WriteLine("この都道府県名は既に登録されています。上書きしますか？ (y/n)");
                        if (Console.ReadLine() == "n") {
                            continue;
                        }
                    } 
                    kensyo[inputken] = inputsyo;
                } else {
                    break;
                }
                
            }
            Boolean endFlag = false;    //終了フラグ（無限ループを抜け出す用）
            while (true) {
                Console.WriteLine("**** メニュー ****");
                Console.WriteLine("1：一覧表示");
                Console.WriteLine("2：検索");
                Console.WriteLine("9：終了");
                Console.Write(">");
                String menuSelect = Console.ReadLine();
                switch (menuSelect) {
                    case "1":
                        //一覧出力処理
                        foreach (var item in kensyo) {
                            Console.WriteLine("{0}の県庁所在地は{1}です。", item.Key, item.Value);
                        }
                        break;

                    case "2":
                        //都道府県の入力
                        Console.Write("都道府県:");
                        String searchPref = Console.ReadLine();
                        Console.WriteLine(searchPref + "の県庁所在地は" + kensyo[searchPref] + "です");
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
    }
}
