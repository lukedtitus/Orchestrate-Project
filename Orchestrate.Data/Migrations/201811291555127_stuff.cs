namespace Orchestrate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "ArtistName", c => c.String(nullable: false));
            DropColumn("dbo.Project", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Project", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.Project", "ArtistName");
        }
    }
}
