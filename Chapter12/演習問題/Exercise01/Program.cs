﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Dynamic;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

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
            var emp = new Employee {
                Id = 1,
                Name = "アーサー・C・クラーク",
                HireDate = new DateTime(1917, 12, 16)
            };

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (StreamWriter writer = new StreamWriter(outfile)) {
                serializer.Serialize(writer, emp);
            }
        }

        private static void Exercise1_2(string filePath) {
            Employee[] employees = new Employee[]
            {
            new Employee { Id = 1, Name = "赤井秀一", HireDate = new DateTime(2020, 1, 15) },
            new Employee { Id = 2, Name = "古谷零", HireDate = new DateTime(2021, 6, 1) }
            };

            DataContractSerializer serializer = new DataContractSerializer(typeof(Employee[]));
            using (FileStream stream = new FileStream(filePath, FileMode.Create)) {
                using (XmlWriter xmlWriter = XmlWriter.Create(stream)) {
                    serializer.WriteObject(xmlWriter, employees);
                }
            }
        }

        private static void Exercise1_3(string filePath) {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Employee[]));
            using (FileStream stream = new FileStream(filePath, FileMode.Open)) {
                Employee[] employees;
                using (XmlReader xmlReader = XmlReader.Create(stream)) {
                    employees = (Employee[])serializer.ReadObject(xmlReader);
                }

                Console.WriteLine("Deserialized Employees:");
                foreach (var employee in employees) {
                    Console.WriteLine("{0}{1}{2}",employee.Id, employee.Name, employee.HireDate.ToShortDateString());
                }
            }
        }

        private static void Exercise1_4(string file) {
            var emps = new Employee[] {
                new Employee {
                    Id = 1202,
                    Name = "赤井秀一",
                    HireDate = new DateTime(2001, 5, 10),
                },
                new Employee {
                    Id = 139,
                    Name = "古谷零",
                    HireDate = new DateTime(2004, 12, 1),
                },
            };

            using (var stream = new FileStream(file, FileMode.Create, FileAccess.Write)) {

                var options = new JsonSerializerOptions {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  //キー名のカスタマイズ
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    WriteIndented = true,
                };

                JsonSerializer.Serialize(stream, emps, options);
            }

        }
    }
}
