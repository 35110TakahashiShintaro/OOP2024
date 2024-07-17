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

        }
    }
}
