namespace Orchestrate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmoneytostrings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "Cost", c => c.String(nullable: false));
            AlterColumn("dbo.Project", "Sales", c => c.String(nullable: false));
            AlterColumn("dbo.Show", "Cost", c => c.String(nullable: false));
            AlterColumn("dbo.Show", "Sales", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Show", "Sales", c => c.Double(nullable: false));
            AlterColumn("dbo.Show", "Cost", c => c.Double(nullable: false));
            AlterColumn("dbo.Project", "Sales", c => c.Double(nullable: false));
            AlterColumn("dbo.Project", "Cost", c => c.Double(nullable: false));
        }
    }
}
