using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "kanzi.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var teams = xdoc.Root.Elements()
                                .Select(x => new {
                                Name = (string)x.Element("name"),
                                Member = (int)x.Element("teammembers")
            });

            foreach (var team in teams) {
                Console.WriteLine($"競技名: {team.Name}, メンバー数: {team.Member}");
            }

        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var kanzi = xdoc.Root.Elements("ballsport")
                                 .Select(x => new {
                                     NameKanji = (string)x.Element("name").Attribute("kanji"),
                                     FirstPlayed = (int)x.Element("firstplayed")
                                 })
                                 .OrderBy(x => x.FirstPlayed);

            foreach (var bs in kanzi) {
                Console.WriteLine($"競技名: {bs.NameKanji}");
            }
        }

        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load(file);
            var member = xdoc.Root.Elements("ballsport")
                                 .Select(x => new {
                                     Name = (string)x.Element("name"),
                                     TeamMembers = (int)x.Element("teammembers")
                                 })
                                 .OrderByDescending(x => x.TeamMembers)
                                 .First();
            Console.WriteLine($"競技名: {member.Name}");

        }

        private static void Exercise1_4(string file, string newfile) {
            List<XElement> xElements = new List<XElement>();

            var xdoc = XDocument.Load(file);
            string name, kanji, teammembers, firstplayed;
            int nextFlag;
            while (true) {
                //入力処理
                Console.Write("名称："); name = Console.ReadLine();
                Console.Write("漢字："); kanji = Console.ReadLine();
                Console.Write("人数："); teammembers = Console.ReadLine();
                Console.Write("起源："); firstplayed = Console.ReadLine();
                //1件分の要素作成
                var element = new XElement("ballsport",
                     new XElement("name", name, new XAttribute("kanji", kanji)),
                     new XElement("teammembers", teammembers),
                     new XElement("firstplayed", firstplayed)
                );
                xElements.Add(element); //リストへ要素を追加

                Console.WriteLine();    //改行
                Console.Write("追加【1】保存【２】");
                Console.Write(">");
                nextFlag = int.Parse(Console.ReadLine());
                if (nextFlag == 2) break;  //無限ループを抜ける
                Console.WriteLine();    //改行
            }
            xdoc.Root.Add(xElements);
            xdoc.Save(newfile); //保存
                                //var xdoc = XDocument.Load(file);

            //bool continueEditing = true;
            //while (continueEditing) {
            //    int option;
            //    while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2 && option != 3)) {
            //        Console.WriteLine("1：追加　2：保存");
            //        Console.Write("1か2を入力してください：");
            //    }
            //    switch (option) {
            //        case 1:
            //            Console.Write("名称:");
            //            string name = Console.ReadLine();

            //            Console.Write("競技名 (漢字): ");
            //            string kanjiName = Console.ReadLine();

            //            Console.Write("プレイ人数: ");
            //            int members = int.Parse(Console.ReadLine());

            //            Console.Write("初めてプレーされた年: ");
            //            int firstPlayed = int.Parse(Console.ReadLine());

            //            Console.WriteLine();

            //            var bs = new XElement("ballsport",
            //            new XElement("name", name),
            //            new XAttribute("kanji", kanjiName),
            //            new XElement("teammembers", members),
            //            new XElement("firstplayed", firstPlayed)
            //            );

            //            //var sd = new XElement("ballsport",
            //            //    new XElement("name", "サッカー"),
            //            //    new XElement("teammembers", 11),
            //            //    new XElement("firstplayed", 1863)
            //            //);

            //            xdoc.Root.Add(bs);
            //            break;
            //        case 2:
            //            xdoc.Save(newfile);
            //            continueEditing = false;
            //            break;
            //    }
            //}

        }
    }
}
