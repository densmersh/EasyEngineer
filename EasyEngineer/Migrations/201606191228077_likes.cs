namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class likes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Likes", c => c.Int(nullable: false));
            AddColumn("dbo.News", "Dislikes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Dislikes");
            DropColumn("dbo.News", "Likes");
        }
    }
}
