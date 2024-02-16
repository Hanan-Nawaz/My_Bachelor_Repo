namespace OnlineJobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobGuestUsers",
                c => new
                    {
                        GuestID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CNIC = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        CellPhone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GuestID);
            
            CreateTable(
                "dbo.GuestUserTokens",
                c => new
                    {
                        TokenID = c.Int(nullable: false, identity: true),
                        AuthToken = c.String(nullable: false),
                        UserID = c.String(nullable: false),
                        IssuedOn = c.DateTime(nullable: false),
                        ExpiresOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TokenID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuestUserTokens");
            DropTable("dbo.JobGuestUsers");
        }
    }
}
