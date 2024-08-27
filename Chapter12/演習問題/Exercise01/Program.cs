using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_1("novel.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("novel.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");
            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employees.json"));
        }

        private static void Exercise1_1(string outfile) {
            Employee novel = new Employee {
                Id = 1,
                Name = "アーサー・C・クラーク",
                HireDate = new DateTime(1917, 12, 16)
            };

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (StreamWriter writer = new StreamWriter(outfile)) {
                serializer.Serialize(writer, novel);
            }
        }

        private static void Exercise1_2(string v) {

        }

        private static void Exercise1_3(string v) {
        }

        private static void Exercise1_4(string v) {
        }
    }
}
