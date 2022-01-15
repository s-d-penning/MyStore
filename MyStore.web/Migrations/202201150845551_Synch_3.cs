namespace MyStore.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Synch_3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pies", "Description", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pies", "Description", c => c.String());
        }
    }
}
