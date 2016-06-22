namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newscomments14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Tag", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Tag", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
