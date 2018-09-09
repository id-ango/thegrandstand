namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class piutangAr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArTransDs",
                c => new
                    {
                        ArDID = c.Int(nullable: false, identity: true),
                        ArDGd = c.Guid(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        Duedate = c.DateTime(),
                        SPesananID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Keterangan = c.String(),
                        Piutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bayar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sisa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ArHGd = c.Guid(nullable: false),
                        ArHID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArDID)
                .ForeignKey("dbo.ArTransHes", t => t.ArHID, cascadeDelete: true)
                .Index(t => t.ArHID);
            
            CreateTable(
                "dbo.ArTransHes",
                c => new
                    {
                        ArHID = c.Int(nullable: false, identity: true),
                        ArHGd = c.Guid(nullable: false),
                        Bukti = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        BankID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        MarketingID = c.Int(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Keterangan = c.String(),
                        JthTempo = c.DateTime(),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Piutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unapplied = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ArHID);
            
            AlterColumn("dbo.PiutangMains", "UnitID", c => c.Int());
            CreateIndex("dbo.PiutangMains", "UnitID");
            AddForeignKey("dbo.PiutangMains", "UnitID", "dbo.AptUnits", "UnitID");
            DropColumn("dbo.PiutangDetails", "DetailGd");
            DropColumn("dbo.PiutangDetails", "MainGd");
            DropColumn("dbo.PiutangMains", "MainGd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PiutangMains", "MainGd", c => c.Guid(nullable: false));
            AddColumn("dbo.PiutangDetails", "MainGd", c => c.Guid(nullable: false));
            AddColumn("dbo.PiutangDetails", "DetailGd", c => c.Guid(nullable: false));
            DropForeignKey("dbo.PiutangMains", "UnitID", "dbo.AptUnits");
            DropForeignKey("dbo.ArTransDs", "ArHID", "dbo.ArTransHes");
            DropIndex("dbo.PiutangMains", new[] { "UnitID" });
            DropIndex("dbo.ArTransDs", new[] { "ArHID" });
            AlterColumn("dbo.PiutangMains", "UnitID", c => c.Int(nullable: false));
            DropTable("dbo.ArTransHes");
            DropTable("dbo.ArTransDs");
        }
    }
}
