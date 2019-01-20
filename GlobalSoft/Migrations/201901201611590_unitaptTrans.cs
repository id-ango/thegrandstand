namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unitaptTrans : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AptTrans", "Unit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AptTrans", "Unit");
        }
    }
}
