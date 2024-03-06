namespace MangaSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Comic_Id", "dbo.Comics");
            DropIndex("dbo.Genres", new[] { "Comic_Id" });
            CreateTable(
                "dbo.GenreComics",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Comic_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Comic_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Comics", t => t.Comic_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Comic_Id);
            
            DropColumn("dbo.Genres", "Comic_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Comic_Id", c => c.Int());
            DropForeignKey("dbo.GenreComics", "Comic_Id", "dbo.Comics");
            DropForeignKey("dbo.GenreComics", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.GenreComics", new[] { "Comic_Id" });
            DropIndex("dbo.GenreComics", new[] { "Genre_Id" });
            DropTable("dbo.GenreComics");
            CreateIndex("dbo.Genres", "Comic_Id");
            AddForeignKey("dbo.Genres", "Comic_Id", "dbo.Comics", "Id");
        }
    }
}
