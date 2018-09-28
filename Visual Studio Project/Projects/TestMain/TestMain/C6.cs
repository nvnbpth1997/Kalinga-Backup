using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMain
{
    class clsstudent
    {
        int age;
        string name;

        public static void main(string[] args)
        {
            list<clsstudent> list = new list<clsstudent>();
            clsstudent[] obj = new clsstudent[5];

            for (int i = 0; i < 3; ++i)
            {
                obj[i] = new clsstudent();
                obj[i].age = convert.toint32(console.readline());
                obj[i].name = console.readline();
                list.add(obj[i]);
            }

            list.add("ramu"); since list is generic it throws error that it can't be of string type
             foreach (clsstudent c in list)
                console.writeline("{0}  {1}", c.name, c.age);

            console.readkey();
        }
    }
}
