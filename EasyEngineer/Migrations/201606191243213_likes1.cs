namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class likes1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.News", "Dislikes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "Dislikes", c => c.Int(nullable: false));
        }
    }
}
