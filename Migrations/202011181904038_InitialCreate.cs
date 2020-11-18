namespace BlogDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PostId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.PostId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Users", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Comments", new[] { "User_UserId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Users", new[] { "BlogId" });
            DropIndex("dbo.Posts", new[] { "BlogId" });
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Blogs");
        }
    }
}
