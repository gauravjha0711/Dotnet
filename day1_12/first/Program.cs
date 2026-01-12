using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using System.IO;
namespace first
{
    internal class Program
    {
        public delegate void Print(int value);
        static void Main(string[] args)
        {
            //Employee emp = new Employee
            //{
            //    Id = 1,
            //    Name = "Gaurav Jha",
            //};

            ////simple file name (NO path)
            //string fileName = @"D:\\Dotnet\\first\\employee.json";  //window
            ////serialize and write to file
            //string json =JsonSerializer.Serialize(emp, new JsonSerializerOptions
            //{
            //    WriteIndented = true
            //});
            //File.WriteAllText(fileName, json);
            //Console.WriteLine("File Created Successfully");

            //read from file and deserialize
            string fileName = @"D:\\Dotnet\\first\\employee.json";  //window
            string jsonFromFile = File.ReadAllText(fileName);
            Employee empobj = JsonSerializer.Deserialize<Employee>(jsonFromFile);
            Console.WriteLine("Employee Details:");
            Console.WriteLine(empobj);
            Console.ReadLine();
        }
    }
}