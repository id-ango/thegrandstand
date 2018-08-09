namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class piutdetal2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PiutangDetails", "UnitID", c => c.Int(nullable: false));
            AddColumn("dbo.PiutangDetails", "UnitNo", c => c.String(maxLength: 10));
            AddColumn("dbo.PiutangDetails", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.PiutangDetails", "CustomerName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PiutangDetails", "CustomerName");
            DropColumn("dbo.PiutangDetails", "CustomerID");
            DropColumn("dbo.PiutangDetails", "UnitNo");
            DropColumn("dbo.PiutangDetails", "UnitID");
        }
    }
}
