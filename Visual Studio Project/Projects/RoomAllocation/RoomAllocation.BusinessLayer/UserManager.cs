using RoomAllocation.DataAccessLayer;
using RoomAllocation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAllocation.BusinessLayer
{
   public class UserManager
    {
        readonly UserDataAccess userDataAccess = new UserDataAccess();
        public IEnumerable<User> UserDetails()
        {
            return userDataAccess.UserDetails().ToList();
        }

        public User FindUser(int? id)
        {
            return userDataAccess.FindUser(id);
        }

        public int AddUser(User user)
        {
            return userDataAccess.AddUser(user);
        }

        public int RemoveUser(User user)
        {
            return userDataAccess.RemoveUser(user);
        }

        public void EditUser(EntityState entity, User user)
        {
            userDataAccess.EditUser(entity, user);
        }
    }
}
