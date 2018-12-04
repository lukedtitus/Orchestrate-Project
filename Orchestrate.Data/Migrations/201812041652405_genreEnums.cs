namespace Orchestrate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreEnums : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artist", "Genre", c => c.Int(nullable: false));
            AlterColumn("dbo.Project", "Genre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Artist", "Genre", c => c.String(nullable: false));
        }
    }
}
