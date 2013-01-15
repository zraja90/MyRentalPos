namespace MyRentalPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Store", "CreateDated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Store", "CreateDated");
            DropColumn("dbo.Customer", "CreatedDate");
        }
    }
}
