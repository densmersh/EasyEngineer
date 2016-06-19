namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Comments", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Comments");
        }
    }
}
