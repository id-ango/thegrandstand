namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambahbank : DbMigration
    {
        public override void Up()
        {
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
                        Tanggal = c.DateTime(nullable: false),
                        Keterangan = c.String(maxLength: 250),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bank1_BankID = c.Int(),
                        Bank2_BankID = c.Int(),
                    })
                .PrimaryKey(t => t.TranshID)
                .ForeignKey("dbo.CbBanks", t => t.Bank1_BankID)
                .ForeignKey("dbo.CbBanks", t => t.Bank2_BankID)
                .Index(t => t.Bank1_BankID)
                .Index(t => t.Bank2_BankID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CbTransDs", "TranshID", "dbo.CbTransHes");
            DropForeignKey("dbo.CbTransHes", "Bank2_BankID", "dbo.CbBanks");
            DropForeignKey("dbo.CbTransHes", "Bank1_BankID", "dbo.CbBanks");
            DropForeignKey("dbo.CbTransDs", "TransNoID", "dbo.AptTrsNoes");
            DropIndex("dbo.CbTransHes", new[] { "Bank2_BankID" });
            DropIndex("dbo.CbTransHes", new[] { "Bank1_BankID" });
            DropIndex("dbo.CbTransDs", new[] { "TranshID" });
            DropIndex("dbo.CbTransDs", new[] { "TransNoID" });
            DropTable("dbo.CbTransHes");
            DropTable("dbo.CbTransDs");
        }
    }
}
