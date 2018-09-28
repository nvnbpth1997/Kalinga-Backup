using BusinessLayer;
using StudentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            Student student;
            StudentDetails sd = new StudentDetails();
            int key;
            
            do
            {
                Console.WriteLine("Welocme to Student portal......");
                Console.WriteLine("1. Enter Student Details");
                Console.WriteLine("2. Display Student Details");
                Console.WriteLine("3. Insert Student details into Database");
                Console.WriteLine("Enter your Choice:");
                key = Convert.ToInt32(Console.ReadLine());

                switch(key)
                {
                    case 1:
                        student = new Student();
                        Console.WriteLine("Enter Student ID:");
                        student.sID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Student Name:");
                        student.sName = (Console.ReadLine());
                        Console.WriteLine("Enter Student Age:");
                        student.age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Teacher ID:");
                        student.tID = Convert.ToInt32(Console.ReadLine());
                        sd.storeDetails(student);
                        break;

                    case 2:
                        Console.WriteLine("\n\nStudent Details....\n");
                        sd.getDetails();
                        break;

                    case 3:
                        int status = sd.storeInDB();
                        if (status > 0)
                            Console.WriteLine("{0} records inserted successfully!", status);
                        //else
                           // Console.WriteLine("Something went wrong..!");
                        break;

                    default:
                        Console.WriteLine("Wrong Choice!!");
                        break;
                }
                Console.WriteLine("\n\n");
            } while (key >= 1 && key <= 3);

            Console.ReadKey();
        }
    }
}
