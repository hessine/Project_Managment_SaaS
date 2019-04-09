namespace IdentityV2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetingMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Company_CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "Company_CompanyId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Company_CompanyId", newName: "CompanyId");
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.AspNetUsers", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CompanyId");
            AddForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            AlterColumn("dbo.AspNetUsers", "CompanyId", c => c.Int());
            DropTable("dbo.Meetings");
            RenameColumn(table: "dbo.AspNetUsers", name: "CompanyId", newName: "Company_CompanyId");
            CreateIndex("dbo.AspNetUsers", "Company_CompanyId");
            AddForeignKey("dbo.AspNetUsers", "Company_CompanyId", "dbo.Companies", "CompanyId");
        }
    }
}
