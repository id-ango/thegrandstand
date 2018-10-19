namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbHutang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApAkunSets",
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
            
            CreateTable(
                "dbo.ApDistribSets",
                c => new
                    {
                        DistribID = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.DistribID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI1_GlAkunID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI2_GlAkunID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI3_GlAkunID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI4_GlAkunID)
                .Index(t => t.GlAkunI1_GlAkunID)
                .Index(t => t.GlAkunI2_GlAkunID)
                .Index(t => t.GlAkunI3_GlAkunID)
                .Index(t => t.GlAkunI4_GlAkunID);
            
            CreateTable(
                "dbo.ApHutangDs",
                c => new
                    {
                        ApDID = c.Int(nullable: false, identity: true),
                        ApDGd = c.Guid(nullable: false),
                        KodeNo = c.Int(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        Duedate = c.DateTime(),
                        Bukti = c.String(maxLength: 20),
                        SupplierID = c.Int(nullable: false),
                        Keterangan = c.String(),
                        ApLPBGd = c.Guid(nullable: false),
                        Lpb = c.String(),
                        DistribSet = c.String(),
                        DistribID = c.Int(nullable: false),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bayar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sisa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApHGd = c.Guid(nullable: false),
                        ApHID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApDID)
                .ForeignKey("dbo.ApHutangHs", t => t.ApHID, cascadeDelete: true)
                .Index(t => t.ApHID);
            
            CreateTable(
                "dbo.ApHutangHs",
                c => new
                    {
                        ApHID = c.Int(nullable: false, identity: true),
                        ApHGd = c.Guid(nullable: false),
                        KodeNo = c.Int(nullable: false),
                        Bukti = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        BankID = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                        Keterangan = c.String(),
                        JthTempo = c.DateTime(),
                        PPn = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PPnpersen = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Brutto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Netto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unapplied = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ApHID);
            
            CreateTable(
                "dbo.ApHutangs",
                c => new
                    {
                        HutangID = c.Int(nullable: false, identity: true),
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
                        SupplierID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HutangID)
                .ForeignKey("dbo.ApSuppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.ApSuppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false, maxLength: 100),
                        ShortName = c.String(maxLength: 10),
                        Alamat = c.String(maxLength: 200),
                        Ktp = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 100),
                        AlamatSekarang = c.String(maxLength: 200),
                        KodePos = c.String(maxLength: 20),
                        Email = c.String(maxLength: 200),
                        Npwp = c.String(maxLength: 50),
                        AkunSet = c.String(maxLength: 20),
                        AkunSetID = c.Int(nullable: false),
                        DistribSet = c.String(),
                        DistribID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID)
                .Index(t => t.ShortName);
            
            CreateTable(
                "dbo.ApTransDs",
                c => new
                    {
                        ApDID = c.Int(nullable: false, identity: true),
                        ApDGd = c.Guid(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        Duedate = c.DateTime(),
                        Bukti = c.String(),
                        SupplierID = c.Int(nullable: false),
                        Keterangan = c.String(),
                        ApLPBGd = c.Guid(nullable: false),
                        Lpb = c.String(),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bayar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sisa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApHGd = c.Guid(nullable: false),
                        ApHID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApDID)
                .ForeignKey("dbo.ApTransHes", t => t.ApHID, cascadeDelete: true)
                .Index(t => t.ApHID);
            
            CreateTable(
                "dbo.ApTransHes",
                c => new
                    {
                        ApHID = c.Int(nullable: false, identity: true),
                        ApHGd = c.Guid(nullable: false),
                        KodeNo = c.Int(nullable: false),
                        Bukti = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        BankID = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                        Keterangan = c.String(),
                        JthTempo = c.DateTime(),
                        PPn = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PPnpersen = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Brutto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Netto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unapplied = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ApHID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApTransDs", "ApHID", "dbo.ApTransHes");
            DropForeignKey("dbo.ApHutangs", "SupplierID", "dbo.ApSuppliers");
            DropForeignKey("dbo.ApHutangDs", "ApHID", "dbo.ApHutangHs");
            DropForeignKey("dbo.ApDistribSets", "GlAkunI4_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ApDistribSets", "GlAkunI3_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ApDistribSets", "GlAkunI2_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ApDistribSets", "GlAkunI1_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ApAkunSets", "GlAkunI4_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ApAkunSets", "GlAkunI3_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ApAkunSets", "GlAkunI2_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ApAkunSets", "GlAkunI1_GlAkunID", "dbo.GlAccounts");
            DropIndex("dbo.ApTransDs", new[] { "ApHID" });
            DropIndex("dbo.ApSuppliers", new[] { "ShortName" });
            DropIndex("dbo.ApHutangs", new[] { "SupplierID" });
            DropIndex("dbo.ApHutangDs", new[] { "ApHID" });
            DropIndex("dbo.ApDistribSets", new[] { "GlAkunI4_GlAkunID" });
            DropIndex("dbo.ApDistribSets", new[] { "GlAkunI3_GlAkunID" });
            DropIndex("dbo.ApDistribSets", new[] { "GlAkunI2_GlAkunID" });
            DropIndex("dbo.ApDistribSets", new[] { "GlAkunI1_GlAkunID" });
            DropIndex("dbo.ApAkunSets", new[] { "GlAkunI4_GlAkunID" });
            DropIndex("dbo.ApAkunSets", new[] { "GlAkunI3_GlAkunID" });
            DropIndex("dbo.ApAkunSets", new[] { "GlAkunI2_GlAkunID" });
            DropIndex("dbo.ApAkunSets", new[] { "GlAkunI1_GlAkunID" });
            DropTable("dbo.ApTransHes");
            DropTable("dbo.ApTransDs");
            DropTable("dbo.ApSuppliers");
            DropTable("dbo.ApHutangs");
            DropTable("dbo.ApHutangHs");
            DropTable("dbo.ApHutangDs");
            DropTable("dbo.ApDistribSets");
            DropTable("dbo.ApAkunSets");
        }
    }
}
