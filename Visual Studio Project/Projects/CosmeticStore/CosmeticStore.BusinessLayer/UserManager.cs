using CosmeticStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmeticStore.DataAccessLayer;
using System.Data.Entity;

namespace CosmeticStore.BusinessLayer
{
    public class UserManager
    {
        private readonly UserDataAccess userDataAccess = new UserDataAccess();

        public int AddUser(User user)
        {
            return userDataAccess.AddUser(user);
        }

        public User FindUser(User user)
        {
            foreach(var item in userDataAccess.FindUser(user).ToList())
            {
                if (item.username.Equals(user.username))
                    user = item;
            }
            return user;
            
        }

        public void RemoveUser(User user)
        {
            userDataAccess.RemoveUser(user);
        }

        public void EditUser(EntityState entityState, User user)
        {
            userDataAccess.EditUser(entityState, user);
        }
    }
}
