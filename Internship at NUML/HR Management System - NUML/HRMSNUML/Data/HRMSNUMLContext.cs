﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRMSNUML.Data
{
    public class HRMSNUMLContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HRMSNUMLContext() : base("name=HRMSNUMLContext")
        {
        }

        public System.Data.Entity.DbSet<HRMSNUML.Models.ConsultancyServices> ConsultancyServices { get; set; }
        public System.Data.Entity.DbSet<HRMSNUML.Models.Notification> Notification { get; set; }
        public System.Data.Entity.DbSet<HRMSNUML.Models.Categories> Categories { get; set; }
        public System.Data.Entity.DbSet<HRMSNUML.Models.Designations> Designations { get; set; }
        public System.Data.Entity.DbSet<HRMSNUML.Models.IPRights> IPRights { get; set; }
        public System.Data.Entity.DbSet<HRMSNUML.Models.AwardsCategory> AwardsCategory { get; set; }
        public System.Data.Entity.DbSet<HRMSNUML.Models.Award> Award { get; set; }
        public System.Data.Entity.DbSet<HRMSNUML.Models.skillcategory> skillcategory { get; set; }
        public System.Data.Entity.DbSet<HRMSNUML.Models.SkillSubCategory> SkillSubCategory { get; set; }
        public System.Data.Entity.DbSet<HRMSNUML.Models.skill> skill { get; set; }

    }
}
