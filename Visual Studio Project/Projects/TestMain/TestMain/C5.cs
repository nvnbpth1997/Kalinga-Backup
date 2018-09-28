using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMain
{
    class Person
    {
        string Name;
        static void Main(string[] args)
        {
            Person obj1 = new Person();
            obj1.Name = "John";
            Person obj2 = new Person();
            obj2.Name = "Bill";
            Person obj3 = new Person();
            obj3.Name = "Dell";
            Person obj4 = new Person();
            obj4.Name = "Misha";
            ArrayList list = new ArrayList();
            list.Add(obj1);
            list.Add(obj2);
            list.Add(obj3);
            list.Add(obj4);
            list.Add("123"); //Comment this line or do exception handling

            try
            {
                foreach (Person p in list)
                {
                    Console.WriteLine(p.Name);
                }
            }
            catch (System.InvalidCastException e)
            {
                Console.WriteLine("Exception handled!");
            }
            Console.ReadKey();
        }

    }
}


