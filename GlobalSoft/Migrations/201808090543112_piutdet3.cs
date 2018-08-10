namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class piutdet3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PiutangDetails", "UnitNo", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PiutangDetails", "UnitNo", c => c.String(maxLength: 10));
        }
    }
}
