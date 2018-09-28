using CosmeticStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticStore.DataAccessLayer
{
    public class CosmeticDbContext : DbContext
    {
        public CosmeticDbContext() : base("CosmeticStore")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Cosmetic> Cosmetics { get; set; }
        public DbSet<Favourite> Favourites  { get; set; }
    }
}
