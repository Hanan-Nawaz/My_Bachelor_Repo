namespace OnlineJobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostPrePhdexpandpapersadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobPaperhecJournals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        w_paper = c.Int(nullable: false),
                        x_paper = c.Int(nullable: false),
                        y_paper = c.Int(nullable: false),
                        z_paper = c.Int(nullable: false),
                        total = c.Int(nullable: false),
                        last_5_years = c.Int(nullable: false),
                        total_hec_approved = c.Int(nullable: false),
                        total_hec_not_approved = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.JobPostPhdExps",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        institute = c.String(nullable: false),
                        position_held = c.String(nullable: false),
                        status = c.String(nullable: false),
                        period_from = c.DateTime(nullable: false),
                        period_to = c.DateTime(nullable: false),
                        exp_year = c.Int(nullable: false),
                        exp_month = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.JobPrePhdExps",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        institute = c.String(nullable: false),
                        position_held = c.String(nullable: false),
                        status = c.String(nullable: false),
                        period_from = c.DateTime(nullable: false),
                        period_to = c.DateTime(nullable: false),
                        exp_year = c.Int(nullable: false),
                        exp_month = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobPrePhdExps");
            DropTable("dbo.JobPostPhdExps");
            DropTable("dbo.JobPaperhecJournals");
        }
    }
}
