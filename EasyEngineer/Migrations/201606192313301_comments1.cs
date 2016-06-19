namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comments1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Comments", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Comments", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
