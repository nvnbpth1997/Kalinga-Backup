using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracking.Entities;
using System.Data.Entity;

namespace Tracking.DataAccessLayer.DbContext
{
    class TrackingDbContext:System.Data.Entity.DbContext 
    {
        public TrackingDbContext() : base("name = AttendenceTrackingDb")
        {

        }
        public virtual DbSet<GlcSwipe> glcswipes { get; set; }
        public virtual DbSet<CmRecords> cmrecords { get; set; }
        public virtual DbSet<DefaultersCount> defaulterscount { get; set; }
        public virtual DbSet<LeadDetails> leaddetails { get; set; }
        public virtual DbSet<Residence> residence { get; set; }
        public virtual DbSet<Admin> admin { get; set; }
        public virtual DbSet<SwipeTrack> swipetrack { get; set; }
        public virtual DbSet<Holidays> holidays { get; set; }
        public virtual DbSet<ExcuseData> excused { get; set; }
        public virtual DbSet<Settings> settings { get; set; }

    }
}
