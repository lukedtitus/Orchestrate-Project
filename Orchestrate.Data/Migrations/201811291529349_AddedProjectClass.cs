namespace Orchestrate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProjectClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Project");
        }
    }
}
