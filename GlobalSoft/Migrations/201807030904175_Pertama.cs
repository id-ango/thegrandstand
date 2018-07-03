namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pertama : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AptUruts");
        }
    }
}
