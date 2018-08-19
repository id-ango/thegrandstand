namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cbTransh1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CbTransDs", "TransNoID");
            AddForeignKey("dbo.CbTransDs", "TransNoID", "dbo.AptTrsNoes", "TransNoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CbTransDs", "TransNoID", "dbo.AptTrsNoes");
            DropIndex("dbo.CbTransDs", new[] { "TransNoID" });
        }
    }
}
