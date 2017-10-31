namespace Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookExampleId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Author = c.String(nullable: false, maxLength: 50),
                        Opened = c.DateTime(nullable: false),
                        Closed = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ReaderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Readers", t => t.ReaderId)
                .Index(t => t.ReaderId);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LibraryCardId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "ReaderId", "dbo.Readers");
            DropIndex("dbo.Books", new[] { "ReaderId" });
            DropTable("dbo.Readers");
            DropTable("dbo.Books");
        }
    }
}
