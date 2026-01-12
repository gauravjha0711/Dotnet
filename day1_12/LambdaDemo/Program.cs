using System;
//using System.ComponentModel;
//using System.Threading.Channels;
//using Arthematic;

namespace LambdaDemo
{
    public delegate int AddDel(int num1, int num2);
    public delegate bool IsTeenAgerDel(Student s);
    public delegate void CallbackDelegate(int val);

    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class Program
    {
        public static void PrintHelperMehod(CallbackDelegate callbackDelegate, int val)
        {
            val += 10;
            callbackDelegate(val);
        }

        static void Main()
        {

            //    var ManagerInfo = new
            //    {
            //        Id = 101,
            //        Name = "Gaurav Kumar"
            //};
            //Console.WriteLine(ManagerInfo.Id);
            //Console.WriteLine(ManagerInfo.Name);

            //    Print print = delegate (int val, string str)
            //    {
            //        Console.WriteLine("Hello You have now annonymous methods");
            //        Console.WriteLine(val + " " + str);
            //    };
            //    print(100, "Kundan Kumar");

            //    PrintHelperMehod(delegate (int val)
            //    {
            //        Console.WriteLine("The anonymous: " + val);
            //    }, 100);

            //AddDel add = delegate (int num1, int num2)
            //{
            //    return num1 + num2;
            //};
            //int sum = add(30, 20);
            //Console.WriteLine(sum);

            //// lambda Expression
            //AddDel lamSum = (int n, int m) => n + m;
            //Console.WriteLine(lamSum(23, 23));

            IsTeenAgerDel isTeenAger = delegate (Student stu)
            {
                return stu.Age > 12 && stu.Age < 20;
            };

            Student s = new Student
            {
                Age = 10,
                Name = "Kumar singh",
                Id = 101
            };

            IsTeenAgerDel isTeenAger1 = (stu) =>
            {
                return stu.Age > 12 && stu.Age < 20;
            };
            Console.WriteLine(isTeenAger1(s));

            IsTeenAgerDel isTeenAger2 = stu => stu.Age > 12 && stu.Age < 20;
            Console.WriteLine(isTeenAger2(s));
            Console.ReadLine();
        }
    }
}
