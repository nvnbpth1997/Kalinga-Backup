using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMain
{
    class ClsStudent
    {
        string name;

        public static void Main(string[] args)
        {
            ClsStudent[] obj = new ClsStudent[4];

            obj[0] = new ClsStudent();
            obj[0].name = "Mill";
            obj[1] = new ClsStudent();
            obj[1].name = "Bill";
            obj[2] = new ClsStudent();
            obj[2].name = "Meeta";
            obj[3] = new ClsStudent();
            obj[3].name = "Bill";

            Dictionary<string, ClsStudent> coll = new Dictionary<string, ClsStudent>();

            try
            {
                for (int i = 0; i < 4; ++i)
                {
                    if (!coll.ContainsKey(obj[i].name))
                    {
                        coll.Add(obj[i].name, obj[i]);
                        Console.WriteLine(coll[obj[i].name].name);
                    }

                }
                Console.WriteLine(coll.Count);
            }
            catch (ArgumentException)  //System.ArgumentException: 'An item with the same key has already been added.'
            {
                Console.WriteLine("Name is already present in dictionary. Try with different name!");
            }

            Console.WriteLine(coll["Meeta"]);
            Console.ReadKey();
        }
    }
}
