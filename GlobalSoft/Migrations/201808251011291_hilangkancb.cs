namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hilangkancb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CbTransDs", "TransNoID", "dbo.AptTrsNoes");
            DropForeignKey("dbo.CbTransHes", "Bank1_BankID", "dbo.CbBanks");
            DropForeignKey("dbo.CbTransHes", "Bank2_BankID", "dbo.CbBanks");
            DropForeignKey("dbo.CbTransDs", "TranshID", "dbo.CbTransHes");
            DropIndex("dbo.CbTransDs", new[] { "TranshID" });
            DropIndex("dbo.CbTransDs", new[] { "TransNoID" });
            DropIndex("dbo.CbTransHes", new[] { "Bank1_BankID" });
            DropIndex("dbo.CbTransHes", new[] { "Bank2_BankID" });
            DropTable("dbo.CbTransDs");
            DropTable("dbo.CbTransHes");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.TranshID);
            
            CreateTable(
                "dbo.CbTransDs",
                c => new
                    {
                        TransdID = c.Int(nullable: false, identity: true),
                        TranshID = c.Int(nullable: false),
                        BankID = c.Int(nullable: false),
                        GuidDb = c.Guid(nullable: false),
                        GuidCb = c.Guid(nullable: false),
                        Docno = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        TransNoID = c.Int(nullable: false),
                        Keterangan = c.String(maxLength: 250),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Terima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bayar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TransdID);
            
            CreateIndex("dbo.CbTransHes", "Bank2_BankID");
            CreateIndex("dbo.CbTransHes", "Bank1_BankID");
            CreateIndex("dbo.CbTransDs", "TransNoID");
            CreateIndex("dbo.CbTransDs", "TranshID");
            AddForeignKey("dbo.CbTransDs", "TranshID", "dbo.CbTransHes", "TranshID", cascadeDelete: true);
            AddForeignKey("dbo.CbTransHes", "Bank2_BankID", "dbo.CbBanks", "BankID");
            AddForeignKey("dbo.CbTransHes", "Bank1_BankID", "dbo.CbBanks", "BankID");
            AddForeignKey("dbo.CbTransDs", "TransNoID", "dbo.AptTrsNoes", "TransNoID", cascadeDelete: true);
        }
    }
}
