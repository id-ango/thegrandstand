namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kasbank : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CbTransDs",
                c => new
                    {
                        TransdID = c.Int(nullable: false, identity: true),
                        TranshID = c.Int(nullable: false),
                        BankID = c.Int(nullable: false),
                        Docno = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        TransNoID = c.Int(nullable: false),
                        Keterangan = c.String(maxLength: 250),
                        Jumlah = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Terima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bayar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TransdID);
            
            CreateTable(
                "dbo.CbTransHes",
                c => new
                    {
                        TranshID = c.Int(nullable: false, identity: true),
                        Docno = c.String(maxLength: 20),
                        BankID = c.Int(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        Keterangan = c.String(maxLength: 250),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TranshID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CbTransHes");
            DropTable("dbo.CbTransDs");
        }
    }
}
