using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserException
{   
    class InvalidLoginIdException : Exception
    {
       public InvalidLoginIdException(string message) : base(message)
        {

        }
    }

    class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string message) : base(message)
        {
         
        }
    }

    class User
    {
        long userId;
        string createdDate;
        string dateOfBirth;
        string fullName;
        string gender;
        string loginId;
        string username;
        string password;

        public void set()
        {
            this.userId = Convert.ToInt64(Console.ReadLine());
            this.createdDate = Console.ReadLine();
            this.dateOfBirth = Console.ReadLine();
            this.fullName = Console.ReadLine();
            this.gender = Console.ReadLine();

            try
            {
                this.loginId = Console.ReadLine();
                if (this.loginId.Length < 5)
                    throw new InvalidLoginIdException("User ID can't be less than 5 characters!");
            }
            catch(InvalidLoginIdException e)
            {
                Console.WriteLine(e.Message);
            }
            
            this.username = Console.ReadLine();

            try
            {
                var hasNumber = new Regex(@"[0-9]+");
                this.password = Console.ReadLine();
                if (!(this.password.Length < 5 && hasNumber.IsMatch(this.password)))
                    throw new InvalidPasswordException("The password must contain atleast one number!");
            }
            catch(InvalidPasswordException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public long getID()
        {
            return this.userId;
        }

        public string get()
        {
            return this.createdDate + " " + this.dateOfBirth + " "  + this.fullName + " "  + this.gender + " "  + this.loginId + " " + this.username + " "  + this.password;
        }
    }

    class UserMgr
    {
        User createUser(User u)
        {
            u.set();
            return u;
        }

        void showUserDetails(User u)
        {
           Console.WriteLine( u.getID() + "  " + u.get());  
        }

        static void Main(string[] args)
        {
            UserMgr um = new UserMgr();
            User u = new User();
            um.createUser(u);
            um.showUserDetails(u);

            Console.ReadKey();
        }
    }
}
