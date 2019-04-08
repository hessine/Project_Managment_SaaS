namespace IdentityV2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Category_CatId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "Category_CatId" });
            DropColumn("dbo.Projects", "CatIdFK");
            RenameColumn(table: "dbo.Projects", name: "Category_CatId", newName: "CatIdFK");
            AlterColumn("dbo.Projects", "CatIdFK", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "CatIdFK");
            AddForeignKey("dbo.Projects", "CatIdFK", "dbo.Categories", "CatId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "CatIdFK", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "CatIdFK" });
            AlterColumn("dbo.Projects", "CatIdFK", c => c.Int());
            RenameColumn(table: "dbo.Projects", name: "CatIdFK", newName: "Category_CatId");
            AddColumn("dbo.Projects", "CatIdFK", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "Category_CatId");
            AddForeignKey("dbo.Projects", "Category_CatId", "dbo.Categories", "CatId");
        }
    }
}
