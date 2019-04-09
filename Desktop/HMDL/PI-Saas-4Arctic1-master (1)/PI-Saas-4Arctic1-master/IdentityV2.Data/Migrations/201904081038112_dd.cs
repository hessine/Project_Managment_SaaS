namespace IdentityV2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        DateDoc = c.DateTime(nullable: false),
                        Name = c.String(),
                        Size = c.String(),
                        ImageUrl = c.String(),
                        FileType = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Documents", new[] { "ProjectId" });
            DropTable("dbo.Documents");
        }
    }
}
