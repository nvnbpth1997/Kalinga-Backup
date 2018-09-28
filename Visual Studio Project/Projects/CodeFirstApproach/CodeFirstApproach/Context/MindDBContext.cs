using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Context
{
    public class MIndDBContext : DbContext
    {
        public MIndDBContext() : base("MindDB")
        {

        }

        public DbSet<Mind> Minds { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }

}