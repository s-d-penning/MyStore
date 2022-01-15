namespace MyStore.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PieCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PieCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PieCategories", t => t.PieCategoryID)
                .Index(t => t.PieCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pies", "PieCategoryID", "dbo.PieCategories");
            DropIndex("dbo.Pies", new[] { "PieCategoryID" });
            DropTable("dbo.Pies");
            DropTable("dbo.PieCategories");
        }
    }
}
