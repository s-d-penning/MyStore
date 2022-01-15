namespace MyStore.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Synch_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pies", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pies", "Name", c => c.String());
        }
    }
}
