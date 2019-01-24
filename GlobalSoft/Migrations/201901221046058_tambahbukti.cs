namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tambahbukti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArTransDs", "Dokumen", c => c.String());
            AddColumn("dbo.ArTransDs", "Bukti", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArTransDs", "Bukti");
            DropColumn("dbo.ArTransDs", "Dokumen");
        }
    }
}
