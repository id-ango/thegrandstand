namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AptAgens",
                c => new
                    {
                        AgenID = c.Int(nullable: false, identity: true),
                        AgenName = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AgenID);
            
            CreateTable(
                "dbo.AptMarketings",
                c => new
                    {
                        MarketingID = c.Int(nullable: false, identity: true),
                        MarketingName = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        AgenID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MarketingID)
                .ForeignKey("dbo.AptAgens", t => t.AgenID, cascadeDelete: true)
                .Index(t => t.AgenID);
            
            CreateTable(
                "dbo.AptTrans",
                c => new
                    {
                        TransID = c.Int(nullable: false, identity: true),
                        NoRef = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        UnitID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        MarketingID = c.Int(nullable: false),
                        Keterangan = c.String(maxLength: 250),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentID = c.Int(nullable: false),
                        TglSelesai = c.DateTime(nullable: false),
                        Cicilan = c.Int(nullable: false),
                        TransNoID = c.Int(nullable: false),
                        BayarID = c.Int(nullable: false),
                        Harga = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Angsuran = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Piutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TransID)
                .ForeignKey("dbo.AptBayars", t => t.BayarID, cascadeDelete: true)
                .ForeignKey("dbo.AptMarketings", t => t.MarketingID, cascadeDelete: true)
                .ForeignKey("dbo.AptPayments", t => t.PaymentID, cascadeDelete: true)
                .ForeignKey("dbo.AptTrsNoes", t => t.TransNoID, cascadeDelete: true)
                .ForeignKey("dbo.AptUnits", t => t.UnitID, cascadeDelete: true)
                .ForeignKey("dbo.ArCustomers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.UnitID)
                .Index(t => t.CustomerID)
                .Index(t => t.MarketingID)
                .Index(t => t.PaymentID)
                .Index(t => t.TransNoID)
                .Index(t => t.BayarID);
            
            CreateTable(
                "dbo.AptBayars",
                c => new
                    {
                        BayarID = c.Int(nullable: false, identity: true),
                        CaraBayar = c.String(maxLength: 20),
                        Bunga = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BayarID);
            
            CreateTable(
                "dbo.AptPayments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        PaymentName = c.String(maxLength: 20),
                        BankID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.CbBanks", t => t.BankID, cascadeDelete: true)
                .Index(t => t.BankID);
            
            CreateTable(
                "dbo.CbBanks",
                c => new
                    {
                        BankID = c.Int(nullable: false, identity: true),
                        BankName = c.String(maxLength: 100),
                        BankAccount = c.String(maxLength: 50),
                        BankType = c.Int(nullable: false),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GlAkunID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BankID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunID, cascadeDelete: true)
                .Index(t => t.GlAkunID);
            
            CreateTable(
                "dbo.GlAccounts",
                c => new
                    {
                        GlAkunID = c.Int(nullable: false, identity: true),
                        GlAkun = c.String(maxLength: 10),
                        GlAkun2 = c.String(maxLength: 10),
                        GlAkunName = c.String(maxLength: 100),
                        GlTipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GlAkunID)
                .ForeignKey("dbo.GlTipes", t => t.GlTipeID, cascadeDelete: true)
                .Index(t => t.GlAkun)
                .Index(t => t.GlTipeID);
            
            CreateTable(
                "dbo.GlTipes",
                c => new
                    {
                        GlTipeID = c.Int(nullable: false, identity: true),
                        GlTipeName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.GlTipeID);
            
            CreateTable(
                "dbo.AptTrsNoes",
                c => new
                    {
                        TransNoID = c.Int(nullable: false, identity: true),
                        TransNo = c.String(nullable: false, maxLength: 20),
                        NoUrut = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransNoID);
            
            CreateTable(
                "dbo.AptUnits",
                c => new
                    {
                        UnitID = c.Int(nullable: false, identity: true),
                        UnitNo = c.String(nullable: false, maxLength: 10),
                        Lantai = c.Int(nullable: false),
                        CategorieID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        Inhouse = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceKPR = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatOld = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnitID)
                .ForeignKey("dbo.AptCategories", t => t.CategorieID, cascadeDelete: true)
                .ForeignKey("dbo.AptStatus", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.UnitNo, unique: true)
                .Index(t => t.CategorieID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.AptCategories",
                c => new
                    {
                        CategorieID = c.Int(nullable: false, identity: true),
                        Categorie = c.String(nullable: false, maxLength: 20),
                        Luas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategorieID)
                .ForeignKey("dbo.AptTypes", t => t.TipeID, cascadeDelete: true)
                .Index(t => t.Categorie, unique: true)
                .Index(t => t.TipeID);
            
            CreateTable(
                "dbo.AptTypes",
                c => new
                    {
                        TipeID = c.Int(nullable: false, identity: true),
                        Tipe = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TipeID);
            
            CreateTable(
                "dbo.AptStatus",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        Status = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.ArCustomers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        ShortName = c.String(maxLength: 10),
                        Alamat = c.String(maxLength: 200),
                        Ktp = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 100),
                        AlamatSekarang = c.String(maxLength: 200),
                        KodePos = c.String(maxLength: 20),
                        Email = c.String(maxLength: 200),
                        Npwp = c.String(maxLength: 50),
                        AccounSet = c.String(maxLength: 11),
                    })
                .PrimaryKey(t => t.CustomerID)
                .Index(t => t.ShortName);
            
            CreateTable(
                "dbo.ArPiutangs",
                c => new
                    {
                        PiutangID = c.Int(nullable: false, identity: true),
                        Dokumen = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        Duedate = c.DateTime(nullable: false),
                        KodeTrans = c.Int(nullable: false),
                        LPB = c.String(maxLength: 20),
                        Keterangan = c.String(maxLength: 200),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bayar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sisa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SldSisa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PiutangID)
                .ForeignKey("dbo.ArCustomers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AptTrans", "CustomerID", "dbo.ArCustomers");
            DropForeignKey("dbo.ArPiutangs", "CustomerID", "dbo.ArCustomers");
            DropForeignKey("dbo.AptTrans", "UnitID", "dbo.AptUnits");
            DropForeignKey("dbo.AptUnits", "StatusID", "dbo.AptStatus");
            DropForeignKey("dbo.AptUnits", "CategorieID", "dbo.AptCategories");
            DropForeignKey("dbo.AptCategories", "TipeID", "dbo.AptTypes");
            DropForeignKey("dbo.AptTrans", "TransNoID", "dbo.AptTrsNoes");
            DropForeignKey("dbo.GlAccounts", "GlTipeID", "dbo.GlTipes");
            DropForeignKey("dbo.CbBanks", "GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.AptPayments", "BankID", "dbo.CbBanks");
            DropForeignKey("dbo.AptTrans", "PaymentID", "dbo.AptPayments");
            DropForeignKey("dbo.AptTrans", "MarketingID", "dbo.AptMarketings");
            DropForeignKey("dbo.AptTrans", "BayarID", "dbo.AptBayars");
            DropForeignKey("dbo.AptMarketings", "AgenID", "dbo.AptAgens");
            DropIndex("dbo.ArPiutangs", new[] { "CustomerID" });
            DropIndex("dbo.ArCustomers", new[] { "ShortName" });
            DropIndex("dbo.AptCategories", new[] { "TipeID" });
            DropIndex("dbo.AptCategories", new[] { "Categorie" });
            DropIndex("dbo.AptUnits", new[] { "StatusID" });
            DropIndex("dbo.AptUnits", new[] { "CategorieID" });
            DropIndex("dbo.AptUnits", new[] { "UnitNo" });
            DropIndex("dbo.GlAccounts", new[] { "GlTipeID" });
            DropIndex("dbo.GlAccounts", new[] { "GlAkun" });
            DropIndex("dbo.CbBanks", new[] { "GlAkunID" });
            DropIndex("dbo.AptPayments", new[] { "BankID" });
            DropIndex("dbo.AptTrans", new[] { "BayarID" });
            DropIndex("dbo.AptTrans", new[] { "TransNoID" });
            DropIndex("dbo.AptTrans", new[] { "PaymentID" });
            DropIndex("dbo.AptTrans", new[] { "MarketingID" });
            DropIndex("dbo.AptTrans", new[] { "CustomerID" });
            DropIndex("dbo.AptTrans", new[] { "UnitID" });
            DropIndex("dbo.AptMarketings", new[] { "AgenID" });
            DropTable("dbo.ArPiutangs");
            DropTable("dbo.ArCustomers");
            DropTable("dbo.AptStatus");
            DropTable("dbo.AptTypes");
            DropTable("dbo.AptCategories");
            DropTable("dbo.AptUnits");
            DropTable("dbo.AptTrsNoes");
            DropTable("dbo.GlTipes");
            DropTable("dbo.GlAccounts");
            DropTable("dbo.CbBanks");
            DropTable("dbo.AptPayments");
            DropTable("dbo.AptBayars");
            DropTable("dbo.AptTrans");
            DropTable("dbo.AptMarketings");
            DropTable("dbo.AptAgens");
        }
    }
}
