using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectedEnv connectedEnv = new ConnectedEnv();
            Console.WriteLine("All Student Details: ");
            connectedEnv.GetAllStudent();
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter the id of the student you want to search for:");
            int id  = Convert.ToInt32(Console.ReadLine());
            connectedEnv.GetStudentById(id);
            Console.ReadLine();
        }
    }
}
