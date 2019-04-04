namespace IdentityV2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "LogoUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "LogoUrl");
        }
    }
}
