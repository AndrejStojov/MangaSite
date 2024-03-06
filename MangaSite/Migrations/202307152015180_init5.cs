namespace MangaSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        UserName = c.String(),
                        Time = c.DateTime(nullable: false),
                        ComicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comics", t => t.ComicId, cascadeDelete: true)
                .Index(t => t.ComicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ComicId", "dbo.Comics");
            DropIndex("dbo.Comments", new[] { "ComicId" });
            DropTable("dbo.Comments");
        }
    }
}
