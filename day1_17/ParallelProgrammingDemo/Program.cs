using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProgrammingDemo
{
    internal class Program
    {
        public static void HelloConsole()
        {
            Console.WriteLine("Hello from Task");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            //action delegate
            Task task1 = new Task(new Action(HelloConsole));
            //annonymous method
            Task task2 = new Task(new Action(HelloConsole));
            //lambda expression
            Task task3 = new Task(new Action(HelloConsole));
            task1.Start();
            task2.Start();
            task3.Start();
            Console.WriteLine("Main method complete.");

            Console.ReadLine();
        }
    }
}
