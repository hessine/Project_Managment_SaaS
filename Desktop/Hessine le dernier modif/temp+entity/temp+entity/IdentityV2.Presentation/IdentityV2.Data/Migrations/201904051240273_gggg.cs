namespace IdentityV2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gggg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskPMs", "leader", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaskPMs", "leader");
        }
    }
}
