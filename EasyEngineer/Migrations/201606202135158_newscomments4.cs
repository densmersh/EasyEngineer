namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newscomments4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewsComments", "News_Id", "dbo.News");
            DropIndex("dbo.NewsComments", new[] { "News_Id" });
            AlterColumn("dbo.NewsComments", "News_Id", c => c.Int());
            CreateIndex("dbo.NewsComments", "News_Id");
            AddForeignKey("dbo.NewsComments", "News_Id", "dbo.News", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsComments", "News_Id", "dbo.News");
            DropIndex("dbo.NewsComments", new[] { "News_Id" });
            AlterColumn("dbo.NewsComments", "News_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.NewsComments", "News_Id");
            AddForeignKey("dbo.NewsComments", "News_Id", "dbo.News", "Id", cascadeDelete: true);
        }
    }
}
