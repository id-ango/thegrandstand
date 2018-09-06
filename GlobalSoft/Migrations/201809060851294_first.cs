namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PiutangMains", "UnitID", "dbo.AptUnits");
            DropIndex("dbo.PiutangMains", new[] { "UnitID" });
            AlterColumn("dbo.PiutangMains", "UnitID", c => c.Int());
            CreateIndex("dbo.PiutangMains", "UnitID");
            AddForeignKey("dbo.PiutangMains", "UnitID", "dbo.AptUnits", "UnitID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PiutangMains", "UnitID", "dbo.AptUnits");
            DropIndex("dbo.PiutangMains", new[] { "UnitID" });
            AlterColumn("dbo.PiutangMains", "UnitID", c => c.Int(nullable: false));
            CreateIndex("dbo.PiutangMains", "UnitID");
            AddForeignKey("dbo.PiutangMains", "UnitID", "dbo.AptUnits", "UnitID", cascadeDelete: true);
        }
    }
}
