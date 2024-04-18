using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samplep_38 {
    internal class Program {
        static void Main(string[] args) {
            Employee employee = new Employee {
                Id = 100,
                Name = "山田太郎",
                Birthday = new DateTime(1992, 4, 5),
                DivisionName = "第一営業部",
            };
            Console.WriteLine("{0}({1})は、{2}に所属しています。",
                employee.Name, employee.GetAge(), employee.DivisionName);

            Student student = new Student() {
                Name = "井口理",
                Birthday = new DateTime(2004, 11, 6),
                ClassNumber = 2,
                Grade = 5,
            };

            Console.WriteLine("{0} - {1}年{2}組 {3:yyyy/M/d}生まれ",
                student.Name, student.Grade, student.ClassNumber, student.Birthday);

            Person person = student;
            if (person is Student)
                Console.WriteLine("person is Student");

            object obj = student;
            if (obj is Student)
                Console.WriteLine("obj is Student");
        }
    }
}
