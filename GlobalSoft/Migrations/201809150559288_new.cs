namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TabularViewModels",
                c => new
                    {
                        TabID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TabID);
            
            AddColumn("dbo.AptUnits", "TabularViewModel_TabID", c => c.Int());
            AddColumn("dbo.AptCategories", "TabularViewModel_TabID", c => c.Int());
            AddColumn("dbo.AptGedungs", "TabularViewModel_TabID", c => c.Int());
            CreateIndex("dbo.AptUnits", "TabularViewModel_TabID");
            CreateIndex("dbo.AptCategories", "TabularViewModel_TabID");
            CreateIndex("dbo.AptGedungs", "TabularViewModel_TabID");
            AddForeignKey("dbo.AptGedungs", "TabularViewModel_TabID", "dbo.TabularViewModels", "TabID");
            AddForeignKey("dbo.AptCategories", "TabularViewModel_TabID", "dbo.TabularViewModels", "TabID");
            AddForeignKey("dbo.AptUnits", "TabularViewModel_TabID", "dbo.TabularViewModels", "TabID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AptUnits", "TabularViewModel_TabID", "dbo.TabularViewModels");
            DropForeignKey("dbo.AptCategories", "TabularViewModel_TabID", "dbo.TabularViewModels");
            DropForeignKey("dbo.AptGedungs", "TabularViewModel_TabID", "dbo.TabularViewModels");
            DropIndex("dbo.AptGedungs", new[] { "TabularViewModel_TabID" });
            DropIndex("dbo.AptCategories", new[] { "TabularViewModel_TabID" });
            DropIndex("dbo.AptUnits", new[] { "TabularViewModel_TabID" });
            DropColumn("dbo.AptGedungs", "TabularViewModel_TabID");
            DropColumn("dbo.AptCategories", "TabularViewModel_TabID");
            DropColumn("dbo.AptUnits", "TabularViewModel_TabID");
            DropTable("dbo.TabularViewModels");
        }
    }
}
