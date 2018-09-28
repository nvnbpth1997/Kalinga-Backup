using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AMSWebApi.Models
{
    public class AmsDbContext : DbContext
    {
        public AmsDbContext() : base("AmsDb")
        {
        }
        public DbSet<AMSModel> Employees { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}