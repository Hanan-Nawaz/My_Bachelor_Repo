namespace OnlineJobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobadschangedagainagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        job_id = c.Int(nullable: false, identity: true),
                        job_title = c.String(nullable: false, maxLength: 200, unicode: false),
                        job_department = c.String(nullable: false, maxLength: 200, unicode: false),
                        job_description = c.String(nullable: false, maxLength: 8000, unicode: false),
                        job_type = c.String(nullable: false, maxLength: 30, unicode: false),
                        job_scale = c.String(maxLength: 30, unicode: false),
                        job_advertisment = c.String(nullable: false, maxLength: 8000, unicode: false),
                        job_location = c.String(nullable: false, maxLength: 200, unicode: false),
                        job_employment_type = c.String(nullable: false, maxLength: 8000, unicode: false),
                        job_application_deadline = c.DateTime(nullable: false),
                        job_date_posted = c.DateTime(nullable: false),
                        job_application_instructions = c.String(nullable: false, maxLength: 8000, unicode: false),
                        is_job_processing_fee = c.Byte(nullable: false),
                        job_processing_fee = c.Int(nullable: false),
                        job_status = c.Byte(nullable: false),
                        job_current_stage = c.String(nullable: false, maxLength: 200, unicode: false),
                        JobAds_job_id = c.Int(),
                    })
                .PrimaryKey(t => t.job_id)
                .ForeignKey("dbo.JobAds", t => t.JobAds_job_id)
                .Index(t => t.JobAds_job_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "JobAds_job_id", "dbo.JobAds");
            DropIndex("dbo.Jobs", new[] { "JobAds_job_id" });
            DropTable("dbo.Jobs");
        }
    }
}
