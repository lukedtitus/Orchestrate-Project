namespace Orchestrate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedshows : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Show", "ArtistId", c => c.Int(nullable: false));
            AddColumn("dbo.Show", "Title", c => c.String(nullable: false));
            CreateIndex("dbo.Show", "ArtistId");
            AddForeignKey("dbo.Show", "ArtistId", "dbo.Artist", "ArtistId", cascadeDelete: true);
            DropColumn("dbo.Artist", "ProjectsReleased");
            DropColumn("dbo.Show", "Artist");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Show", "Artist", c => c.String(nullable: false));
            AddColumn("dbo.Artist", "ProjectsReleased", c => c.Int(nullable: false));
            DropForeignKey("dbo.Show", "ArtistId", "dbo.Artist");
            DropIndex("dbo.Show", new[] { "ArtistId" });
            DropColumn("dbo.Show", "Title");
            DropColumn("dbo.Show", "ArtistId");
        }
    }
}
