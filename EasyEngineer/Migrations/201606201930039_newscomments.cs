namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newscomments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsComments",
                c => new
                    {
                        NewsCommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 100),
                        Author = c.String(),
                        DatePub = c.DateTime(),
                        Likes = c.Int(nullable: false),
                        News_Id = c.Int(),
                    })
                .PrimaryKey(t => t.NewsCommentId)
                .ForeignKey("dbo.News", t => t.News_Id)
                .Index(t => t.News_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsComments", "News_Id", "dbo.News");
            DropIndex("dbo.NewsComments", new[] { "News_Id" });
            DropTable("dbo.NewsComments");
        }
    }
}
