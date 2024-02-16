namespace OnlineJobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Publicationsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobPublications",
                c => new
                    {
                        publication_id = c.Int(nullable: false, identity: true),
                        author_name = c.String(nullable: false, maxLength: 200, unicode: false),
                        journal_name = c.String(nullable: false, maxLength: 200, unicode: false),
                        journal_address = c.String(nullable: false, maxLength: 8000, unicode: false),
                        issn_number = c.String(nullable: false, maxLength: 30, unicode: false),
                        publication_title = c.String(maxLength: 30, unicode: false),
                        vol_no = c.String(nullable: false, maxLength: 8000, unicode: false),
                        start_page = c.Int(nullable: false),
                        end_page = c.Int(nullable: false),
                        hec_category = c.String(nullable: false, maxLength: 8000, unicode: false),
                        published_year = c.String(nullable: false, maxLength: 200, unicode: false),
                        impact_factor = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.publication_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobPublications");
        }
    }
}
