namespace OnlineJobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobadschangedagain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobAds", "JobAds_job_id", "dbo.JobAds");
            DropIndex("dbo.JobAds", new[] { "JobAds_job_id" });
            DropColumn("dbo.JobAds", "JobAds_job_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobAds", "JobAds_job_id", c => c.Int());
            CreateIndex("dbo.JobAds", "JobAds_job_id");
            AddForeignKey("dbo.JobAds", "JobAds_job_id", "dbo.JobAds", "job_id");
        }
    }
}
