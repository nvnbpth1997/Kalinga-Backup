using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Discussion___App.Models
{
    public class dbContext : DbContext
    {
        public dbContext() : base("Event")
        {
        }
        public DbSet<Event> events { get; set; }
    }
}