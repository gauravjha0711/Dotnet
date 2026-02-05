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
            connectedEnv.GetAllStudent();
            Console.ReadLine();
        }
    }
}
