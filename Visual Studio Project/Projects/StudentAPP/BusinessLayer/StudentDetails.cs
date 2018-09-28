using DataAccessLayer;
using Exceptions;
using StudentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentDetails
    {
        Dictionary<int, Student> keyValuePairs = new Dictionary<int, Student>();
        public void storeDetails(Student student)
        {
            try
            {
                if (student.sName.Contains("a") || student.sName.Contains("r"))
                    keyValuePairs.Add(student.sID, student);
                else
                throw new InvalidNameException("Name doesn't contain character 'a' or 'r'");
            }
            catch(InvalidNameException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int storeInDB()
        {
            DataAccess da = new DataAccess();
            int status = da.storeData(keyValuePairs);
            keyValuePairs.Clear();
            return status;
        }

        public void getDetails()
        {
            DataAccess da = new DataAccess();
            da.retrieveData();
        }
    }   
}
