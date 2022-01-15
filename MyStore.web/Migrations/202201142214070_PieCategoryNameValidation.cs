namespace MyStore.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PieCategoryNameValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PieCategories", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PieCategories", "Name", c => c.String());
        }
    }
}
