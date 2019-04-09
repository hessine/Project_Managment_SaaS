namespace IdentityV2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMig : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Company_CompanyId", newName: "CompanyId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Company_CompanyId", newName: "IX_CompanyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_CompanyId", newName: "IX_Company_CompanyId");
            RenameColumn(table: "dbo.AspNetUsers", name: "CompanyId", newName: "Company_CompanyId");
        }
    }
}
