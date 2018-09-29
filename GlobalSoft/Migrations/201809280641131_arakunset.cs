namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arakunset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArAkunSets",
                c => new
                    {
                        AkunsetID = c.Int(nullable: false, identity: true),
                        AkunSet = c.String(maxLength: 20),
                        GlAkunID1 = c.Int(nullable: false),
                        GlAkunID2 = c.Int(nullable: false),
                        GlAkunID3 = c.Int(nullable: false),
                        GlAkunID4 = c.Int(nullable: false),
                        GlAkun1 = c.String(),
                        GlAkun2 = c.String(),
                        GlAkun3 = c.String(),
                        GlAkun4 = c.String(),
                        GlAkunI1_GlAkunID = c.Int(),
                        GlAkunI2_GlAkunID = c.Int(),
                        GlAkunI3_GlAkunID = c.Int(),
                        GlAkunI4_GlAkunID = c.Int(),
                    })
                .PrimaryKey(t => t.AkunsetID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI1_GlAkunID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI2_GlAkunID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI3_GlAkunID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI4_GlAkunID)
                .Index(t => t.GlAkunI1_GlAkunID)
                .Index(t => t.GlAkunI2_GlAkunID)
                .Index(t => t.GlAkunI3_GlAkunID)
                .Index(t => t.GlAkunI4_GlAkunID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArAkunSets", "GlAkunI4_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ArAkunSets", "GlAkunI3_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ArAkunSets", "GlAkunI2_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ArAkunSets", "GlAkunI1_GlAkunID", "dbo.GlAccounts");
            DropIndex("dbo.ArAkunSets", new[] { "GlAkunI4_GlAkunID" });
            DropIndex("dbo.ArAkunSets", new[] { "GlAkunI3_GlAkunID" });
            DropIndex("dbo.ArAkunSets", new[] { "GlAkunI2_GlAkunID" });
            DropIndex("dbo.ArAkunSets", new[] { "GlAkunI1_GlAkunID" });
            DropTable("dbo.ArAkunSets");
        }
    }
}
