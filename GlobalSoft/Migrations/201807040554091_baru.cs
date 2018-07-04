namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baru : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GlAccounts", "GlGroupID", "dbo.GlGroups");
            DropForeignKey("dbo.GlAccounts", "GlTipeID", "dbo.GlTipes");
            DropIndex("dbo.GlAccounts", new[] { "GlTipeID" });
            DropIndex("dbo.GlAccounts", new[] { "GlGroupID" });
            DropTable("dbo.GlGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GlGroups",
                c => new
                    {
                        GlGroupID = c.Int(nullable: false, identity: true),
                        GlGroupName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.GlGroupID);
            
            CreateIndex("dbo.GlAccounts", "GlGroupID");
            CreateIndex("dbo.GlAccounts", "GlTipeID");
            AddForeignKey("dbo.GlAccounts", "GlTipeID", "dbo.GlTipes", "GlTipeID", cascadeDelete: true);
            AddForeignKey("dbo.GlAccounts", "GlGroupID", "dbo.GlGroups", "GlGroupID", cascadeDelete: true);
        }
    }
}
