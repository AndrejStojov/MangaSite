namespace MangaSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavotiresLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Comics", "FavotiresList_Id", c => c.Int());
            CreateIndex("dbo.Comics", "FavotiresList_Id");
            AddForeignKey("dbo.Comics", "FavotiresList_Id", "dbo.FavotiresLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comics", "FavotiresList_Id", "dbo.FavotiresLists");
            DropIndex("dbo.Comics", new[] { "FavotiresList_Id" });
            DropColumn("dbo.Comics", "FavotiresList_Id");
            DropTable("dbo.FavotiresLists");
        }
    }
}
