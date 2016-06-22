namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newscomments5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewsComments", "News_Id", "dbo.News");
            DropIndex("dbo.NewsComments", new[] { "News_Id" });
            RenameColumn(table: "dbo.NewsComments", name: "News_Id", newName: "NewsId");
            AlterColumn("dbo.NewsComments", "NewsId", c => c.Int(nullable: false));
            CreateIndex("dbo.NewsComments", "NewsId");
            AddForeignKey("dbo.NewsComments", "NewsId", "dbo.News", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsComments", "NewsId", "dbo.News");
            DropIndex("dbo.NewsComments", new[] { "NewsId" });
            AlterColumn("dbo.NewsComments", "NewsId", c => c.Int());
            RenameColumn(table: "dbo.NewsComments", name: "NewsId", newName: "News_Id");
            CreateIndex("dbo.NewsComments", "News_Id");
            AddForeignKey("dbo.NewsComments", "News_Id", "dbo.News", "Id");
        }
    }
}
