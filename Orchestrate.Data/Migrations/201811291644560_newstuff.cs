namespace Orchestrate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newstuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Project", "Artist", c => c.String(nullable: false));
            AddColumn("dbo.Project", "Genre", c => c.String(nullable: false));
            AddColumn("dbo.Project", "ReleaseYear", c => c.Int(nullable: false));
            AddColumn("dbo.Project", "Cost", c => c.Double(nullable: false));
            AddColumn("dbo.Project", "Sales", c => c.Double(nullable: false));
            DropColumn("dbo.Project", "ArtistName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Project", "ArtistName", c => c.String(nullable: false));
            DropColumn("dbo.Project", "Sales");
            DropColumn("dbo.Project", "Cost");
            DropColumn("dbo.Project", "ReleaseYear");
            DropColumn("dbo.Project", "Genre");
            DropColumn("dbo.Project", "Artist");
            DropColumn("dbo.Project", "Name");
        }
    }
}
