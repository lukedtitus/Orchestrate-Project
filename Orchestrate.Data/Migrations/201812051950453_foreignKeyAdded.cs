namespace Orchestrate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeyAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "ArtistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Project", "ArtistId");
            AddForeignKey("dbo.Project", "ArtistId", "dbo.Artist", "ArtistId", cascadeDelete: true);
            DropColumn("dbo.Project", "Artist");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Project", "Artist", c => c.String(nullable: false));
            DropForeignKey("dbo.Project", "ArtistId", "dbo.Artist");
            DropIndex("dbo.Project", new[] { "ArtistId" });
            DropColumn("dbo.Project", "ArtistId");
        }
    }
}
