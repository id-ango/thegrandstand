namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class piutang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArPiutangs",
                c => new
                    {
                        PiutangID = c.Int(nullable: false, identity: true),
                        Dokumen = c.String(maxLength: 20),
                        Tanggal = c.DateTime(nullable: false),
                        Duedate = c.DateTime(nullable: false),
                        KodeTrans = c.Int(nullable: false),
                        LPB = c.String(),
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
            
            AddColumn("dbo.AptTrans", "CaraBayar", c => c.Int(nullable: false));
            AddColumn("dbo.AptTrans", "Harga", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AptTrans", "Angsuran", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AptTrans", "Piutang", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArPiutangs", "CustomerID", "dbo.ArCustomers");
            DropIndex("dbo.ArPiutangs", new[] { "CustomerID" });
            DropColumn("dbo.AptTrans", "Piutang");
            DropColumn("dbo.AptTrans", "Angsuran");
            DropColumn("dbo.AptTrans", "Harga");
            DropColumn("dbo.AptTrans", "CaraBayar");
            DropTable("dbo.ArPiutangs");
        }
    }
}
