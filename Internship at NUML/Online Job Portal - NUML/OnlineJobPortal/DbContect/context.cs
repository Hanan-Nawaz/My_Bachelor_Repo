using OnlineJobPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineJobPortal.DbContect
{
    public class context : DbContext
    {
        public context() : base("dbcon") { }

        public DbSet<JobAds> JobsAds { get; set; }
       
    }
}