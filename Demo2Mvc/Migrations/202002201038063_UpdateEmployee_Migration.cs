namespace Demo2Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployee_Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employees", "EmailAddress", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmailAddress", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
