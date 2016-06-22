namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Tag", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.News", "Like");
            DropColumn("dbo.News", "Dislike");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "Dislike", c => c.String());
            AddColumn("dbo.News", "Like", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.News", "Tag", c => c.String());
        }
    }
}
