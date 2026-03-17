using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODotnetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectEnvDemo demo = new ConnectEnvDemo();
            demo.GetAllStudent();
            Console.ReadLine();
        }
    }
}