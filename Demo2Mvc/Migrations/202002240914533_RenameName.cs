namespace Demo2Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FullName", c => c.String(nullable: false, maxLength: 50));
            Sql(@"UPDATE dbo.Employees SET FullName=Name");
            DropColumn("dbo.Employees", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Employees", "FullName");
        }
    }
}
