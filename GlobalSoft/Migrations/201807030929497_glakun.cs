namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class glakun : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GlTipes", "GlClassID", "dbo.GlClasses");
            DropIndex("dbo.GlTipes", new[] { "GlClassID" });
            DropTable("dbo.GlClasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GlClasses",
                c => new
                    {
                        GlClassID = c.Int(nullable: false, identity: true),
                        GlClassName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.GlClassID);
            
            CreateIndex("dbo.GlTipes", "GlClassID");
            AddForeignKey("dbo.GlTipes", "GlClassID", "dbo.GlClasses", "GlClassID", cascadeDelete: true);
        }
    }
}
