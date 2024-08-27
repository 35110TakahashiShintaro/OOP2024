using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
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

        private static void Exercise1_2(string filePath) {
            Employee[] employees = new Employee[]
            {
            new Employee { Id = 1, Name = "John", HireDate = new DateTime(2020, 1, 15) },
            new Employee { Id = 2, Name = "Smith", HireDate = new DateTime(2021, 6, 1) }
            };

            DataContractSerializer serializer = new DataContractSerializer(typeof(Employee[]));
            using (FileStream stream = new FileStream(filePath, FileMode.Create)) {
                using (XmlWriter xmlWriter = XmlWriter.Create(stream)) {
                    serializer.WriteObject(xmlWriter, employees);
                }
            }
        }

        private static void Exercise1_3(string v) {
        }

        private static void Exercise1_4(string v) {
        }
    }
}
