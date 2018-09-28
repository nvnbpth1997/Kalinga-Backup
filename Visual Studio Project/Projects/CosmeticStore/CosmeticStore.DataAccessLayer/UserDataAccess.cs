using CosmeticStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticStore.DataAccessLayer
{
    public class UserDataAccess
    {
        readonly CosmeticDbContext db = new CosmeticDbContext();
        public int AddUser(User user)
        {
            if (!CheckName(user))
            {
                db.Users.Add(user);
            }
            return db.SaveChanges();
        }

        public DbSet<User> FindUser(User user)
        {
           return db.Users;
        }

        public bool CheckName(User user)
        {
            return (db.Users.Any(u => u.username == user.username));
        }

        public void RemoveUser(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void EditUser(EntityState entity, User user)
        {
            db.Entry(user).State = entity;
            db.SaveChanges();
        }
    }
}
