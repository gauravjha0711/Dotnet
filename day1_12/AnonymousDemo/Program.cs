using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousDemo
{
    public delegate void Print(int val, string str);
    public delegate void Print1(int val);
    public 
    internal class Program
    {
        public static void PrintHelperMethod(Print1 printDel, int val)
        {
            val += 10;
            printDel(val);
        }
        public static void Main(string[] args)
        {
            PrintHelperMethod(delegate (int val)
            {
                Console.WriteLine($"Anonymous Method called with value: {val}");
            }, 100);

            Print print = delegate (int val, string str)
            {
                Console.WriteLine($"Hello World {val} {str}");
            };
            print(100, "Welcome");
            var ManagerInfo = new
            {
                id = 1001,
            Name = "Gaurav Jha"
            };
            
            Console.WriteLine($"Manager id is {ManagerInfo.id}");
            Console.WriteLine($"Manager name is {ManagerInfo.Name} ");
            Console.ReadLine();
        }
    }
}
