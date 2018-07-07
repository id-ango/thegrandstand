namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class akunset : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArCustomers", "Akunset", c => c.String(maxLength: 20));
            DropColumn("dbo.ArCustomers", "GlAkun1");
            DropColumn("dbo.ArCustomers", "GlAkun2");
            DropColumn("dbo.ArCustomers", "GlAkun3");
            DropColumn("dbo.ArCustomers", "GlAkun4");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArCustomers", "GlAkun4", c => c.String(maxLength: 10));
            AddColumn("dbo.ArCustomers", "GlAkun3", c => c.String(maxLength: 10));
            AddColumn("dbo.ArCustomers", "GlAkun2", c => c.String(maxLength: 10));
            AddColumn("dbo.ArCustomers", "GlAkun1", c => c.String(maxLength: 10));
            DropColumn("dbo.ArCustomers", "Akunset");
        }
    }
}
