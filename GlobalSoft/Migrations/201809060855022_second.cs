namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AptGedungs", "TabularViewModel_TabID", "dbo.TabularViewModels");
            DropForeignKey("dbo.AptCategories", "TabularViewModel_TabID", "dbo.TabularViewModels");
            DropForeignKey("dbo.AptUnits", "TabularViewModel_TabID", "dbo.TabularViewModels");
            DropIndex("dbo.AptUnits", new[] { "TabularViewModel_TabID" });
            DropIndex("dbo.AptCategories", new[] { "TabularViewModel_TabID" });
            DropIndex("dbo.AptGedungs", new[] { "TabularViewModel_TabID" });
            DropColumn("dbo.AptUnits", "TabularViewModel_TabID");
            DropColumn("dbo.AptCategories", "TabularViewModel_TabID");
            DropTable("dbo.AptGedungs");
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
            
            CreateTable(
                "dbo.AptGedungs",
                c => new
                    {
                        GedungID = c.Int(nullable: false, identity: true),
                        Gedung = c.String(),
                        Lantai1 = c.Int(nullable: false),
                        Lantai2 = c.Int(nullable: false),
                        TabularViewModel_TabID = c.Int(),
                    })
                .PrimaryKey(t => t.GedungID);
            
            AddColumn("dbo.AptCategories", "TabularViewModel_TabID", c => c.Int());
            AddColumn("dbo.AptUnits", "TabularViewModel_TabID", c => c.Int());
            CreateIndex("dbo.AptGedungs", "TabularViewModel_TabID");
            CreateIndex("dbo.AptCategories", "TabularViewModel_TabID");
            CreateIndex("dbo.AptUnits", "TabularViewModel_TabID");
            AddForeignKey("dbo.AptUnits", "TabularViewModel_TabID", "dbo.TabularViewModels", "TabID");
            AddForeignKey("dbo.AptCategories", "TabularViewModel_TabID", "dbo.TabularViewModels", "TabID");
            AddForeignKey("dbo.AptGedungs", "TabularViewModel_TabID", "dbo.TabularViewModels", "TabID");
        }
    }
}
