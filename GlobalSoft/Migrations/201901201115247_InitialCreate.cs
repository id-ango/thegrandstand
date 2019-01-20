namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                "dbo.GlAccounts",
                c => new
                    {
                        GlAkunID = c.Int(nullable: false, identity: true),
                        GlAkun = c.String(maxLength: 10),
                        GlAkun2 = c.String(maxLength: 10),
                        GlAkunName = c.String(maxLength: 100),
                        GlTipeID = c.Int(nullable: false),
                        GlGroupID = c.Int(nullable: false),
                        JenisAkun = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GlAkunID)
                .Index(t => t.GlAkun);
            
            CreateTable(
                "dbo.CbBanks",
                c => new
                    {
                        BankID = c.Int(nullable: false, identity: true),
                        BankName = c.String(maxLength: 100),
                        BankAccount = c.String(maxLength: 50),
                        KodeBank = c.String(),
                        BankType = c.Int(nullable: false),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GlAkunID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BankID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunID, cascadeDelete: true)
                .Index(t => t.GlAkunID);
            
            CreateTable(
                "dbo.AptPayments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        PaymentName = c.String(maxLength: 20),
                        KodeBank = c.String(),
                        BankID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.CbBanks", t => t.BankID, cascadeDelete: true)
                .Index(t => t.BankID);
            
            CreateTable(
                "dbo.AptTrans",
                c => new
                    {
                        TransID = c.Int(nullable: false, identity: true),
                        NoRef = c.String(maxLength: 20),
                        SpesananGd = c.Guid(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        UnitID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        ShortName = c.String(),
                        MarketingID = c.Int(nullable: false),
                        KodeMarketing = c.String(),
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
                "dbo.AptMarketings",
                c => new
                    {
                        MarketingID = c.Int(nullable: false, identity: true),
                        KodeMarketing = c.String(),
                        MarketingName = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 100),
                        Alamat = c.String(),
                        KodeAgen = c.String(),
                        AgenID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MarketingID)
                .ForeignKey("dbo.AptAgens", t => t.AgenID, cascadeDelete: true)
                .Index(t => t.AgenID);
            
            CreateTable(
                "dbo.AptAgens",
                c => new
                    {
                        AgenID = c.Int(nullable: false, identity: true),
                        KodeAgen = c.String(),
                        AgenName = c.String(maxLength: 100),
                        Alamat = c.String(),
                        Phone = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AgenID);
            
            CreateTable(
                "dbo.AptSPesanans",
                c => new
                    {
                        SPesananID = c.Int(nullable: false, identity: true),
                        SPesanan = c.String(maxLength: 20),
                        SpesananGd = c.Guid(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        Duedate = c.DateTime(nullable: false),
                        KodeTrans = c.Int(nullable: false),
                        NoBukti = c.String(),
                        LPB = c.String(maxLength: 20),
                        Keterangan = c.String(maxLength: 200),
                        KetBayar = c.String(maxLength: 200),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bayar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sisa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SldSisa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AptTrans_TransID = c.Int(),
                    })
                .PrimaryKey(t => t.SPesananID)
                .ForeignKey("dbo.AptTrans", t => t.AptTrans_TransID)
                .Index(t => t.AptTrans_TransID);
            
            CreateTable(
                "dbo.AptTrsNoes",
                c => new
                    {
                        TransNoID = c.Int(nullable: false, identity: true),
                        TransNo = c.String(nullable: false, maxLength: 50),
                        GlAkunID = c.Int(nullable: false),
                        SourceCode = c.String(),
                    })
                .PrimaryKey(t => t.TransNoID);
            
            CreateTable(
                "dbo.CbTrans",
                c => new
                    {
                        TransID = c.Int(nullable: false, identity: true),
                        NoRef = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        Unit = c.String(),
                        UnitID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        ShortCode = c.String(),
                        KodeMarketing = c.String(),
                        MarketingID = c.Int(nullable: false),
                        Keterangan = c.String(maxLength: 250),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentID = c.Int(nullable: false),
                        kodebayar = c.String(),
                        BankID = c.Int(nullable: false),
                        KodeBank = c.String(),
                        TglSelesai = c.DateTime(nullable: false),
                        Cicilan = c.Int(nullable: false),
                        TransNoID = c.Int(nullable: false),
                        BayarID = c.Int(nullable: false),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bayar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sisa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SldSisa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Harga = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Angsuran = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Piutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SPesananID = c.Int(nullable: false),
                        NoSPesanan = c.String(maxLength: 20),
                        NoJurnal = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.TransID)
                .ForeignKey("dbo.AptBayars", t => t.BayarID, cascadeDelete: true)
                .ForeignKey("dbo.AptMarketings", t => t.MarketingID, cascadeDelete: true)
                .ForeignKey("dbo.AptPayments", t => t.PaymentID, cascadeDelete: true)
                .ForeignKey("dbo.AptTrsNoes", t => t.TransNoID, cascadeDelete: true)
                .ForeignKey("dbo.AptUnits", t => t.UnitID, cascadeDelete: true)
                .Index(t => t.UnitID)
                .Index(t => t.MarketingID)
                .Index(t => t.PaymentID)
                .Index(t => t.TransNoID)
                .Index(t => t.BayarID);
            
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
                        GlAkun1 = c.String(maxLength: 10),
                        GlAkun2 = c.String(maxLength: 10),
                        GlAkun3 = c.String(maxLength: 10),
                        GlAkun4 = c.String(maxLength: 10),
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
                        AkunSet = c.String(maxLength: 20),
                        AkunSetID = c.Int(nullable: false),
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
                        ShortName = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PiutangID)
                .ForeignKey("dbo.ArCustomers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
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
                "dbo.AptGedungs",
                c => new
                    {
                        GedungID = c.Int(nullable: false, identity: true),
                        Gedung = c.String(),
                        Lantai1 = c.Int(nullable: false),
                        Lantai2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GedungID);
            
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
            
            CreateTable(
                "dbo.AptUruts",
                c => new
                    {
                        AptUrutID = c.Int(nullable: false, identity: true),
                        TipeTrans = c.Int(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        NoUrut = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AptUrutID);
            
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
                        GlAkunID5 = c.Int(nullable: false),
                        GlAkun1 = c.String(),
                        GlAkun2 = c.String(),
                        GlAkun3 = c.String(),
                        GlAkun4 = c.String(),
                        GlAkun5 = c.String(),
                        GlAkunI1_GlAkunID = c.Int(),
                        GlAkunI2_GlAkunID = c.Int(),
                        GlAkunI3_GlAkunID = c.Int(),
                        GlAkunI4_GlAkunID = c.Int(),
                        GlAkunI5_GlAkunID = c.Int(),
                    })
                .PrimaryKey(t => t.AkunsetID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI1_GlAkunID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI2_GlAkunID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI3_GlAkunID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI4_GlAkunID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunI5_GlAkunID)
                .Index(t => t.GlAkunI1_GlAkunID)
                .Index(t => t.GlAkunI2_GlAkunID)
                .Index(t => t.GlAkunI3_GlAkunID)
                .Index(t => t.GlAkunI4_GlAkunID)
                .Index(t => t.GlAkunI5_GlAkunID);
            
            CreateTable(
                "dbo.ArTransDs",
                c => new
                    {
                        ArDID = c.Int(nullable: false, identity: true),
                        ArDGd = c.Guid(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        Duedate = c.DateTime(),
                        SPesananID = c.Int(nullable: false),
                        NoSpesanan = c.String(),
                        CustomerID = c.Int(nullable: false),
                        ShortName = c.String(),
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
                        KodeNo = c.Int(nullable: false),
                        Bukti = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        BankID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        ShortName = c.String(),
                        MarketingID = c.Int(nullable: false),
                        KodeMarketing = c.String(),
                        UnitID = c.Int(nullable: false),
                        KodeUnit = c.String(),
                        Keterangan = c.String(),
                        JthTempo = c.DateTime(),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Piutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unapplied = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Posted = c.Boolean(nullable: false),
                        Createdby = c.String(),
                    })
                .PrimaryKey(t => t.ArHID);
            
            CreateTable(
                "dbo.CbTransDs",
                c => new
                    {
                        TransdID = c.Int(nullable: false, identity: true),
                        GuidDb = c.Guid(nullable: false),
                        GuidCb = c.Guid(nullable: false),
                        Docno = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        TransNoID = c.Int(nullable: false),
                        SourceCode = c.String(),
                        Keterangan = c.String(maxLength: 250),
                        BankID = c.Int(nullable: false),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Terima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bayar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TranshID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransdID)
                .ForeignKey("dbo.AptTrsNoes", t => t.TransNoID, cascadeDelete: true)
                .ForeignKey("dbo.CbTransHes", t => t.TranshID, cascadeDelete: true)
                .Index(t => t.TransNoID)
                .Index(t => t.TranshID);
            
            CreateTable(
                "dbo.CbTransHes",
                c => new
                    {
                        TranshID = c.Int(nullable: false, identity: true),
                        GuidCb = c.Guid(nullable: false),
                        Docno = c.String(maxLength: 20),
                        BankID = c.Int(nullable: false),
                        BankID2 = c.Int(nullable: false),
                        kodebank = c.String(),
                        Tanggal = c.DateTime(nullable: false),
                        Keterangan = c.String(maxLength: 250),
                        Posted = c.Boolean(nullable: false),
                        Createdby = c.String(),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TranshID)
                .ForeignKey("dbo.CbBanks", t => t.BankID, cascadeDelete: true)
                .Index(t => t.BankID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustID = c.Int(nullable: false, identity: true),
                        CustomerId = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrdID = c.Int(nullable: false, identity: true),
                        OrderId = c.Guid(nullable: false),
                        ProductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        CustomerId = c.Guid(nullable: false),
                        CustID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrdID)
                .ForeignKey("dbo.Customers", t => t.CustID, cascadeDelete: true)
                .Index(t => t.CustID);
            
            CreateTable(
                "dbo.GlTipes",
                c => new
                    {
                        GlTipeID = c.Int(nullable: false, identity: true),
                        GlTipeName = c.String(maxLength: 100),
                        GlClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GlTipeID);
            
            CreateTable(
                "dbo.GlTransDs",
                c => new
                    {
                        GlDID = c.Int(nullable: false, identity: true),
                        GlDGd = c.Guid(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        GlAkunID = c.Int(nullable: false),
                        Keterangan = c.String(),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Debet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GlHGd = c.Guid(nullable: false),
                        GlHID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GlDID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAkunID, cascadeDelete: true)
                .ForeignKey("dbo.GlTransHes", t => t.GlHID, cascadeDelete: true)
                .Index(t => t.GlAkunID)
                .Index(t => t.GlHID);
            
            CreateTable(
                "dbo.GlTransHes",
                c => new
                    {
                        GlHID = c.Int(nullable: false, identity: true),
                        GlHGd = c.Guid(nullable: false),
                        KodeNo = c.Int(nullable: false),
                        Docno = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        Keterangan = c.String(),
                        Debet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Posted = c.Boolean(nullable: false),
                        Createdby = c.String(),
                    })
                .PrimaryKey(t => t.GlHID);
            
            CreateTable(
                "dbo.PiutangDetails",
                c => new
                    {
                        DetailID = c.Int(nullable: false, identity: true),
                        MainID = c.Int(nullable: false),
                        SPesananID = c.Int(nullable: false),
                        Duedate = c.DateTime(nullable: false),
                        TglString = c.String(maxLength: 20),
                        Keterangan = c.String(maxLength: 250),
                        Piutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bayar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sisa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerID = c.Int(nullable: false),
                        CustomerName = c.String(maxLength: 100),
                        UnitID = c.Int(nullable: false),
                        UnitNo = c.String(maxLength: 20),
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
                        ShortName = c.String(),
                        BankID = c.Int(nullable: false),
                        kodebank = c.String(),
                        UnitID = c.Int(),
                        KodeTrans = c.Int(nullable: false),
                        Keterangan = c.String(maxLength: 250),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Piutang = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unapplied = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diskon = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MainID)
                .ForeignKey("dbo.AptUnits", t => t.UnitID)
                .ForeignKey("dbo.ArCustomers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.UnitID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PiutangDetails", "MainID", "dbo.PiutangMains");
            DropForeignKey("dbo.PiutangMains", "CustomerID", "dbo.ArCustomers");
            DropForeignKey("dbo.PiutangMains", "UnitID", "dbo.AptUnits");
            DropForeignKey("dbo.GlTransDs", "GlHID", "dbo.GlTransHes");
            DropForeignKey("dbo.GlTransDs", "GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.Orders", "CustID", "dbo.Customers");
            DropForeignKey("dbo.CbTransDs", "TranshID", "dbo.CbTransHes");
            DropForeignKey("dbo.CbTransHes", "BankID", "dbo.CbBanks");
            DropForeignKey("dbo.CbTransDs", "TransNoID", "dbo.AptTrsNoes");
            DropForeignKey("dbo.ArTransDs", "ArHID", "dbo.ArTransHes");
            DropForeignKey("dbo.ArAkunSets", "GlAkunI5_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ArAkunSets", "GlAkunI4_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ArAkunSets", "GlAkunI3_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ArAkunSets", "GlAkunI2_GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.ArAkunSets", "GlAkunI1_GlAkunID", "dbo.GlAccounts");
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
            DropForeignKey("dbo.CbBanks", "GlAkunID", "dbo.GlAccounts");
            DropForeignKey("dbo.AptPayments", "BankID", "dbo.CbBanks");
            DropForeignKey("dbo.AptTrans", "CustomerID", "dbo.ArCustomers");
            DropForeignKey("dbo.ArPiutangs", "CustomerID", "dbo.ArCustomers");
            DropForeignKey("dbo.CbTrans", "UnitID", "dbo.AptUnits");
            DropForeignKey("dbo.AptTrans", "UnitID", "dbo.AptUnits");
            DropForeignKey("dbo.AptUnits", "StatusID", "dbo.AptStatus");
            DropForeignKey("dbo.AptUnits", "CategorieID", "dbo.AptCategories");
            DropForeignKey("dbo.AptCategories", "TipeID", "dbo.AptTypes");
            DropForeignKey("dbo.CbTrans", "TransNoID", "dbo.AptTrsNoes");
            DropForeignKey("dbo.CbTrans", "PaymentID", "dbo.AptPayments");
            DropForeignKey("dbo.CbTrans", "MarketingID", "dbo.AptMarketings");
            DropForeignKey("dbo.CbTrans", "BayarID", "dbo.AptBayars");
            DropForeignKey("dbo.AptTrans", "TransNoID", "dbo.AptTrsNoes");
            DropForeignKey("dbo.AptSPesanans", "AptTrans_TransID", "dbo.AptTrans");
            DropForeignKey("dbo.AptTrans", "PaymentID", "dbo.AptPayments");
            DropForeignKey("dbo.AptTrans", "MarketingID", "dbo.AptMarketings");
            DropForeignKey("dbo.AptMarketings", "AgenID", "dbo.AptAgens");
            DropForeignKey("dbo.AptTrans", "BayarID", "dbo.AptBayars");
            DropIndex("dbo.PiutangMains", new[] { "UnitID" });
            DropIndex("dbo.PiutangMains", new[] { "CustomerID" });
            DropIndex("dbo.PiutangDetails", new[] { "MainID" });
            DropIndex("dbo.GlTransDs", new[] { "GlHID" });
            DropIndex("dbo.GlTransDs", new[] { "GlAkunID" });
            DropIndex("dbo.Orders", new[] { "CustID" });
            DropIndex("dbo.CbTransHes", new[] { "BankID" });
            DropIndex("dbo.CbTransDs", new[] { "TranshID" });
            DropIndex("dbo.CbTransDs", new[] { "TransNoID" });
            DropIndex("dbo.ArTransDs", new[] { "ArHID" });
            DropIndex("dbo.ArAkunSets", new[] { "GlAkunI5_GlAkunID" });
            DropIndex("dbo.ArAkunSets", new[] { "GlAkunI4_GlAkunID" });
            DropIndex("dbo.ArAkunSets", new[] { "GlAkunI3_GlAkunID" });
            DropIndex("dbo.ArAkunSets", new[] { "GlAkunI2_GlAkunID" });
            DropIndex("dbo.ArAkunSets", new[] { "GlAkunI1_GlAkunID" });
            DropIndex("dbo.ApTransDs", new[] { "ApHID" });
            DropIndex("dbo.ApSuppliers", new[] { "ShortName" });
            DropIndex("dbo.ApHutangs", new[] { "SupplierID" });
            DropIndex("dbo.ApHutangDs", new[] { "ApHID" });
            DropIndex("dbo.ApDistribSets", new[] { "GlAkunI4_GlAkunID" });
            DropIndex("dbo.ApDistribSets", new[] { "GlAkunI3_GlAkunID" });
            DropIndex("dbo.ApDistribSets", new[] { "GlAkunI2_GlAkunID" });
            DropIndex("dbo.ApDistribSets", new[] { "GlAkunI1_GlAkunID" });
            DropIndex("dbo.ArPiutangs", new[] { "CustomerID" });
            DropIndex("dbo.ArCustomers", new[] { "ShortName" });
            DropIndex("dbo.AptCategories", new[] { "TipeID" });
            DropIndex("dbo.AptCategories", new[] { "Categorie" });
            DropIndex("dbo.AptUnits", new[] { "StatusID" });
            DropIndex("dbo.AptUnits", new[] { "CategorieID" });
            DropIndex("dbo.AptUnits", new[] { "UnitNo" });
            DropIndex("dbo.CbTrans", new[] { "BayarID" });
            DropIndex("dbo.CbTrans", new[] { "TransNoID" });
            DropIndex("dbo.CbTrans", new[] { "PaymentID" });
            DropIndex("dbo.CbTrans", new[] { "MarketingID" });
            DropIndex("dbo.CbTrans", new[] { "UnitID" });
            DropIndex("dbo.AptSPesanans", new[] { "AptTrans_TransID" });
            DropIndex("dbo.AptMarketings", new[] { "AgenID" });
            DropIndex("dbo.AptTrans", new[] { "BayarID" });
            DropIndex("dbo.AptTrans", new[] { "TransNoID" });
            DropIndex("dbo.AptTrans", new[] { "PaymentID" });
            DropIndex("dbo.AptTrans", new[] { "MarketingID" });
            DropIndex("dbo.AptTrans", new[] { "CustomerID" });
            DropIndex("dbo.AptTrans", new[] { "UnitID" });
            DropIndex("dbo.AptPayments", new[] { "BankID" });
            DropIndex("dbo.CbBanks", new[] { "GlAkunID" });
            DropIndex("dbo.GlAccounts", new[] { "GlAkun" });
            DropIndex("dbo.ApAkunSets", new[] { "GlAkunI4_GlAkunID" });
            DropIndex("dbo.ApAkunSets", new[] { "GlAkunI3_GlAkunID" });
            DropIndex("dbo.ApAkunSets", new[] { "GlAkunI2_GlAkunID" });
            DropIndex("dbo.ApAkunSets", new[] { "GlAkunI1_GlAkunID" });
            DropTable("dbo.PiutangMains");
            DropTable("dbo.PiutangDetails");
            DropTable("dbo.GlTransHes");
            DropTable("dbo.GlTransDs");
            DropTable("dbo.GlTipes");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.CbTransHes");
            DropTable("dbo.CbTransDs");
            DropTable("dbo.ArTransHes");
            DropTable("dbo.ArTransDs");
            DropTable("dbo.ArAkunSets");
            DropTable("dbo.AptUruts");
            DropTable("dbo.ApTransHes");
            DropTable("dbo.ApTransDs");
            DropTable("dbo.AptGedungs");
            DropTable("dbo.ApSuppliers");
            DropTable("dbo.ApHutangs");
            DropTable("dbo.ApHutangHs");
            DropTable("dbo.ApHutangDs");
            DropTable("dbo.ApDistribSets");
            DropTable("dbo.ArPiutangs");
            DropTable("dbo.ArCustomers");
            DropTable("dbo.AptStatus");
            DropTable("dbo.AptTypes");
            DropTable("dbo.AptCategories");
            DropTable("dbo.AptUnits");
            DropTable("dbo.CbTrans");
            DropTable("dbo.AptTrsNoes");
            DropTable("dbo.AptSPesanans");
            DropTable("dbo.AptAgens");
            DropTable("dbo.AptMarketings");
            DropTable("dbo.AptBayars");
            DropTable("dbo.AptTrans");
            DropTable("dbo.AptPayments");
            DropTable("dbo.CbBanks");
            DropTable("dbo.GlAccounts");
            DropTable("dbo.ApAkunSets");
        }
    }
}
