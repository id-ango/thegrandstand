namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambahakunsetid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArCustomers", "AkunSetID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArCustomers", "AkunSetID");
        }
    }
}
