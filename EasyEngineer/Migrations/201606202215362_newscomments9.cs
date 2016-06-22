namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newscomments9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewsComments", "NewsId", "dbo.News");
            DropIndex("dbo.NewsComments", new[] { "NewsId" });
            RenameColumn(table: "dbo.NewsComments", name: "NewsId", newName: "News_Id");
            AlterColumn("dbo.NewsComments", "News_Id", c => c.Int());
            CreateIndex("dbo.NewsComments", "News_Id");
            AddForeignKey("dbo.NewsComments", "News_Id", "dbo.News", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsComments", "News_Id", "dbo.News");
            DropIndex("dbo.NewsComments", new[] { "News_Id" });
            AlterColumn("dbo.NewsComments", "News_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.NewsComments", name: "News_Id", newName: "NewsId");
            CreateIndex("dbo.NewsComments", "NewsId");
            AddForeignKey("dbo.NewsComments", "NewsId", "dbo.News", "Id", cascadeDelete: true);
        }
    }
}
