namespace IdentityV2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sometables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        HistoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        TaskId = c.Int(),
                    })
                .PrimaryKey(t => t.HistoryId)
                .ForeignKey("dbo.TaskPMs", t => t.TaskId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.TaskPMs",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DeadLine = c.DateTime(nullable: false),
                        Name = c.String(),
                        Status = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateBegin = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Picture = c.String(),
                        Description = c.String(),
                        Etat = c.Int(nullable: false),
                        ClientFK = c.Int(nullable: false),
                        CatIdFK = c.Int(nullable: false),
                        TotalNbrRessources = c.Int(nullable: false),
                        TotalNbrRessourcesLevio = c.Int(nullable: false),
                        client_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.AspNetUsers", t => t.client_Id)
                .Index(t => t.client_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskPMs", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "client_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Histories", "TaskId", "dbo.TaskPMs");
            DropIndex("dbo.Projects", new[] { "client_Id" });
            DropIndex("dbo.TaskPMs", new[] { "ProjectId" });
            DropIndex("dbo.Histories", new[] { "TaskId" });
            DropTable("dbo.Projects");
            DropTable("dbo.TaskPMs");
            DropTable("dbo.Histories");
        }
    }
}
