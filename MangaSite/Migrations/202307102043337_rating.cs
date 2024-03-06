namespace MangaSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rating : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comics", "Rating", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comics", "Rating", c => c.Int(nullable: false));
        }
    }
}
