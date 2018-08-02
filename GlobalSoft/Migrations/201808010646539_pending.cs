namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pending : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PiutangDetails",
                c => new
                    {
                        DetailID = c.Int(nullable: false, identity: true),
                        MainID = c.Int(nullable: false),
                        Keterangan = c.String(maxLength: 250),
                        Piutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bayar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sisa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SPesanan = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.DetailID)
                .ForeignKey("dbo.PiutangMains", t => t.MainID, cascadeDelete: true)
                .Index(t => t.MainID);
            
            CreateTable(
                "dbo.PiutangMains",
                c => new
                    {
                        MainID = c.Int(nullable: false, identity: true),
                        NoBukti = c.String(),
                        Tanggal = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        UnitID = c.Int(nullable: false),
                        KodeTrans = c.Int(nullable: false),
                        Keterangan = c.String(maxLength: 250),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Piutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unapplied = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MainID)
                .ForeignKey("dbo.AptUnits", t => t.UnitID, cascadeDelete: true)
                .ForeignKey("dbo.ArCustomers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.UnitID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PiutangDetails", "MainID", "dbo.PiutangMains");
            DropForeignKey("dbo.PiutangMains", "CustomerID", "dbo.ArCustomers");
            DropForeignKey("dbo.PiutangMains", "UnitID", "dbo.AptUnits");
            DropIndex("dbo.PiutangMains", new[] { "UnitID" });
            DropIndex("dbo.PiutangMains", new[] { "CustomerID" });
            DropIndex("dbo.PiutangDetails", new[] { "MainID" });
            DropTable("dbo.PiutangMains");
            DropTable("dbo.PiutangDetails");
        }
    }
}
