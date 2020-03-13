namespace Demo2Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adds_Language_Class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Languages");
        }
    }
}
