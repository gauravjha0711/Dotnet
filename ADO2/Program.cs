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
            //ConnectedEnv connectedEnv = new ConnectedEnv();
            //Console.WriteLine("All Student Details: ");
            //connectedEnv.GetAllStudent();
            //Console.WriteLine("\n\n");
            //Console.WriteLine("Enter the id of the student you want to search for:");
            //int id  = Convert.ToInt32(Console.ReadLine());
            //connectedEnv.GetStudentById(id);

            //Console.WriteLine("Enter details for add new students: ");
            //Console.Write("Enter Student Id: ");
            //int Studid = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Enter name: ");
            //string name = Console.ReadLine();
            //Console.Write("Enter Course: ");
            //string course = Console.ReadLine();
            //Console.Write("Enter Marks: ");
            //int marks = Convert.ToInt32(Console.ReadLine());
            //connectedEnv.AddNewStudent(id, name, course, marks);

            //Console.Write("Enter id for delete: ");
            //int Delid = Convert.ToInt32(Console.ReadLine());
            //connectedEnv.DeleteStudent(Delid);

            //Console.WriteLine("Enter id for Update: ");
            //int updId = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Enter name: ");
            //string updName = Console.ReadLine();
            //Console.Write("Enter Course: ");
            //string updCourse = Console.ReadLine();
            //Console.Write("Enter Marks: ");
            //int updMarks = Convert.ToInt32(Console.ReadLine());
            //connectedEnv.UpdateStudent(updId, updName, updCourse, updMarks);


            DisconnectEnvDemo disconnectEnvDemo = new DisconnectEnvDemo();
            //Console.WriteLine("All Student Details: ");
            //disconnectEnvDemo.GetAllStudent();

            Console.Write("Enter id for search: ");
            int SearchId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Students details: ");
            disconnectEnvDemo.GetStudentById(SearchId);

            Console.ReadLine();
        }
    }
}
