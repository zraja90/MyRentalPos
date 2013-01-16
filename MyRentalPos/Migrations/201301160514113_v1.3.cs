namespace MyRentalPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Store", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Store", "CreateDated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Store", "CreateDated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Store", "CreatedDate");
        }
    }
}
