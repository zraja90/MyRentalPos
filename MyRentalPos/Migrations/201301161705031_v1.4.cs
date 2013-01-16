namespace MyRentalPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Store", "EmailAddress", c => c.String());
            DropColumn("dbo.Store", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Store", "Email", c => c.String());
            DropColumn("dbo.Store", "EmailAddress");
        }
    }
}
