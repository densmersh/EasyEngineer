namespace EasyEngineer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "News_Id", "dbo.News");
            DropIndex("dbo.Comments", new[] { "News_Id" });
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 100),
                        Author = c.String(),
                        DatePub = c.DateTime(),
                        Likes = c.Int(nullable: false),
                        News_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateIndex("dbo.Comments", "News_Id");
            AddForeignKey("dbo.Comments", "News_Id", "dbo.News", "Id");
        }
    }
}
