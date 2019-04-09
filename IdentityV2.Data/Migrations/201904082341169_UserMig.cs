namespace IdentityV2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "CompanyId", newName: "Company_CompanyId");
            AlterColumn("dbo.AspNetUsers", "Company_CompanyId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Company_CompanyId");
            AddForeignKey("dbo.AspNetUsers", "Company_CompanyId", "dbo.Companies", "CompanyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Company_CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "Company_CompanyId" });
            AlterColumn("dbo.AspNetUsers", "Company_CompanyId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.AspNetUsers", name: "Company_CompanyId", newName: "CompanyId");
            CreateIndex("dbo.AspNetUsers", "CompanyId");
            AddForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
    }
}
