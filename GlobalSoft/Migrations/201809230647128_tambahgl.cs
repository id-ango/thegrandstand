namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambahgl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AptGedungs", "TabularViewModel_TabID", "dbo.TabularViewModels");
            DropForeignKey("dbo.AptCategories", "TabularViewModel_TabID", "dbo.TabularViewModels");
            DropForeignKey("dbo.AptUnits", "TabularViewModel_TabID", "dbo.TabularViewModels");
            DropIndex("dbo.AptUnits", new[] { "TabularViewModel_TabID" });
            DropIndex("dbo.AptCategories", new[] { "TabularViewModel_TabID" });
            DropIndex("dbo.AptGedungs", new[] { "TabularViewModel_TabID" });
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
                    })
                .PrimaryKey(t => t.GlHID);
            
            DropColumn("dbo.AptUnits", "TabularViewModel_TabID");
            DropColumn("dbo.AptCategories", "TabularViewModel_TabID");
            DropColumn("dbo.AptGedungs", "TabularViewModel_TabID");
            DropTable("dbo.TabularViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TabularViewModels",
                c => new
                    {
                        TabID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TabID);
            
            AddColumn("dbo.AptGedungs", "TabularViewModel_TabID", c => c.Int());
            AddColumn("dbo.AptCategories", "TabularViewModel_TabID", c => c.Int());
            AddColumn("dbo.AptUnits", "TabularViewModel_TabID", c => c.Int());
            DropForeignKey("dbo.GlTransDs", "GlHID", "dbo.GlTransHes");
            DropForeignKey("dbo.GlTransDs", "GlAkunID", "dbo.GlAccounts");
            DropIndex("dbo.GlTransDs", new[] { "GlHID" });
            DropIndex("dbo.GlTransDs", new[] { "GlAkunID" });
            DropTable("dbo.GlTransHes");
            DropTable("dbo.GlTransDs");
            CreateIndex("dbo.AptGedungs", "TabularViewModel_TabID");
            CreateIndex("dbo.AptCategories", "TabularViewModel_TabID");
            CreateIndex("dbo.AptUnits", "TabularViewModel_TabID");
            AddForeignKey("dbo.AptUnits", "TabularViewModel_TabID", "dbo.TabularViewModels", "TabID");
            AddForeignKey("dbo.AptCategories", "TabularViewModel_TabID", "dbo.TabularViewModels", "TabID");
            AddForeignKey("dbo.AptGedungs", "TabularViewModel_TabID", "dbo.TabularViewModels", "TabID");
        }
    }
}
