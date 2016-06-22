namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Author", c => c.String());
            AlterColumn("dbo.News", "Tag", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Tag", c => c.String());
            AlterColumn("dbo.News", "Author", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
