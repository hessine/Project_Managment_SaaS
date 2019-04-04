namespace IdentityV2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            AddColumn("dbo.AspNetUsers", "Company_CompanyId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Company_CompanyId");
            AddForeignKey("dbo.AspNetUsers", "Company_CompanyId", "dbo.Companies", "CompanyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Company_CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "Company_CompanyId" });
            DropColumn("dbo.AspNetUsers", "Company_CompanyId");
            DropTable("dbo.Companies");
        }
    }
}
