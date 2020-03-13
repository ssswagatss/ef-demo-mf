namespace Demo2Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adds_many_to_many_relations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LanguageEmployees",
                c => new
                    {
                        Language_LanguageId = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Language_LanguageId, t.Employee_EmployeeId })
                .ForeignKey("dbo.Languages", t => t.Language_LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Language_LanguageId)
                .Index(t => t.Employee_EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LanguageEmployees", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.LanguageEmployees", "Language_LanguageId", "dbo.Languages");
            DropIndex("dbo.LanguageEmployees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.LanguageEmployees", new[] { "Language_LanguageId" });
            DropTable("dbo.LanguageEmployees");
        }
    }
}
