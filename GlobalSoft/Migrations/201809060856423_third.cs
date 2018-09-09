namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AptGedungs");
        }
    }
}
