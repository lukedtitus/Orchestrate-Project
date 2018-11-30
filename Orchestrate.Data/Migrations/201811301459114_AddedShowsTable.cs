namespace Orchestrate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedShowsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Show",
                c => new
                    {
                        ShowId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Artist = c.String(nullable: false),
                        CityOfVenue = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Cost = c.Double(nullable: false),
                        Sales = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ShowId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Show");
        }
    }
}
