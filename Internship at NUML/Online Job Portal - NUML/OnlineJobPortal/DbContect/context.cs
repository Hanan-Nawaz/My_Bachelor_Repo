﻿using OnlineJobPortal.Models;
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
        public DbSet<JobPublications> JobPublications { get; set; }
        public DbSet<GuestUserToken> userToken { get; set; }
        public DbSet<JobGuestUsers> userinfo { get; set; }
        public DbSet<JobPostPhdExp> postPhdExps { get; set; }
        public DbSet<JobPrePhdExp> prePhdExps { get; set; }
        public DbSet<JobPaperhecJournals> jobPaperhecJournals { get; set; }

    }
}