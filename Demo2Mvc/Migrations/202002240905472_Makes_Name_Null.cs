namespace Demo2Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Makes_Name_Null : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE Employees SET Name='NA' WHERE Name IS NULL;");
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(maxLength: 50));
        }
    }
}
