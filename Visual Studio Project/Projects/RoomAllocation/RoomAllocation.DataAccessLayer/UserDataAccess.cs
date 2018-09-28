using RoomAllocation.Context;
using RoomAllocation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAllocation.DataAccessLayer
{
    public class UserDataAccess
    {
        RoomAllocateContext db = new RoomAllocateContext();
        public DbSet<User> UserDetails()
        {
            return db.Users;
        }

        public User FindUser(int? id)
        {
            return db.Users.Find(id);
        }

        public int AddUser(User user)
        {
            db.Users.Add(user);
            return db.SaveChanges();   
        }

        public int RemoveUser(User user)
        {
            db.Users.Remove(user);
            return db.SaveChanges();
        }

        public void EditUser(EntityState entity, User user)
        {
            db.Entry(user).State = entity;
            db.SaveChanges();
        }

        
    }
}
