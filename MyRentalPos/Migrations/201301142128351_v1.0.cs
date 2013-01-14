namespace MyRentalPos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerBillingInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        Email = c.String(maxLength: 128),
                        FirstName = c.String(maxLength: 128),
                        LastName = c.String(maxLength: 128),
                        PhoneNumber = c.String(maxLength: 128),
                        CompanyName = c.String(maxLength: 128),
                        Address = c.String(maxLength: 128),
                        City = c.String(maxLength: 128),
                        State = c.String(maxLength: 128),
                        ZipCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreName = c.String(),
                        BaseUrl = c.String(),
                        LogOutUrl = c.String(),
                        Image = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsGlobal = c.Boolean(nullable: false),
                        Owner = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        StoreId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastActivityDateUtc = c.DateTime(nullable: false),
                        LastLoginDateUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.EmployeeRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                        IsSystemRole = c.Boolean(nullable: false),
                        SystemName = c.String(),
                        IsGlobal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PermissionRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SystemName = c.String(nullable: false, maxLength: 255),
                        Category = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                        PhoneNumber = c.String(),
                        FaxNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        Name = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        RentalQuantity = c.Int(nullable: false),
                        SalesQuantity = c.Int(nullable: false),
                        IsRental = c.Boolean(nullable: false),
                        IsSales = c.Boolean(nullable: false),
                        SalesPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.RentalPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        RentalType = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.StoreId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerShippingInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.EmailAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 255),
                        DisplayName = c.String(maxLength: 255),
                        Host = c.String(nullable: false, maxLength: 255),
                        Port = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        EnableSsl = c.Boolean(nullable: false),
                        UseDefaultCredentials = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmailTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        BccEmailAddresses = c.String(maxLength: 200),
                        Subject = c.String(maxLength: 1000),
                        Body = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EmailAccountId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QueuedEmail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Priority = c.Int(nullable: false),
                        From = c.String(nullable: false, maxLength: 500),
                        FromName = c.String(maxLength: 500),
                        To = c.String(nullable: false, maxLength: 500),
                        ToName = c.String(maxLength: 500),
                        CC = c.String(maxLength: 500),
                        Bcc = c.String(maxLength: 500),
                        Subject = c.String(maxLength: 1000),
                        Body = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        SentTries = c.Int(nullable: false),
                        SentOnUtc = c.DateTime(),
                        EmailAccountId = c.Int(nullable: false),
                        EmailName = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailAccount", t => t.EmailAccountId, cascadeDelete: true)
                .Index(t => t.EmailAccountId);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogLevelId = c.Int(nullable: false),
                        ShortMessage = c.String(nullable: false),
                        FullMessage = c.String(),
                        IpAddress = c.String(maxLength: 200),
                        UserId = c.Int(),
                        PageUrl = c.String(),
                        ReferrerUrl = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScheduleTask",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Seconds = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        StopOnError = c.Boolean(nullable: false),
                        LastStartUtc = c.DateTime(),
                        LastEndUtc = c.DateTime(),
                        LastSuccessUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PermissionRecord_Role_Mapping",
                c => new
                    {
                        EmployeeRole_Id = c.Int(nullable: false),
                        PermissionRecord_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeRole_Id, t.PermissionRecord_Id })
                .ForeignKey("dbo.EmployeeRole", t => t.EmployeeRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.PermissionRecord", t => t.PermissionRecord_Id, cascadeDelete: true)
                .Index(t => t.EmployeeRole_Id)
                .Index(t => t.PermissionRecord_Id);
            
            CreateTable(
                "dbo.Employee_EmployeeRole_Mapping",
                c => new
                    {
                        Employee_Id = c.Int(nullable: false),
                        EmployeeRole_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_Id, t.EmployeeRole_Id })
                .ForeignKey("dbo.Employee", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeRole", t => t.EmployeeRole_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.EmployeeRole_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employee_EmployeeRole_Mapping", new[] { "EmployeeRole_Id" });
            DropIndex("dbo.Employee_EmployeeRole_Mapping", new[] { "Employee_Id" });
            DropIndex("dbo.PermissionRecord_Role_Mapping", new[] { "PermissionRecord_Id" });
            DropIndex("dbo.PermissionRecord_Role_Mapping", new[] { "EmployeeRole_Id" });
            DropIndex("dbo.QueuedEmail", new[] { "EmailAccountId" });
            DropIndex("dbo.CustomerShippingInfo", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "StoreId" });
            DropIndex("dbo.RentalPrices", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "StoreId" });
            DropIndex("dbo.StoreAddress", new[] { "StoreId" });
            DropIndex("dbo.Employee", new[] { "StoreId" });
            DropIndex("dbo.Customer", new[] { "StoreId" });
            DropIndex("dbo.CustomerBillingInfo", new[] { "CustomerId" });
            DropForeignKey("dbo.Employee_EmployeeRole_Mapping", "EmployeeRole_Id", "dbo.EmployeeRole");
            DropForeignKey("dbo.Employee_EmployeeRole_Mapping", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.PermissionRecord_Role_Mapping", "PermissionRecord_Id", "dbo.PermissionRecord");
            DropForeignKey("dbo.PermissionRecord_Role_Mapping", "EmployeeRole_Id", "dbo.EmployeeRole");
            DropForeignKey("dbo.QueuedEmail", "EmailAccountId", "dbo.EmailAccount");
            DropForeignKey("dbo.CustomerShippingInfo", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Orders", "StoreId", "dbo.Store");
            DropForeignKey("dbo.RentalPrices", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "StoreId", "dbo.Store");
            DropForeignKey("dbo.StoreAddress", "StoreId", "dbo.Store");
            DropForeignKey("dbo.Employee", "StoreId", "dbo.Store");
            DropForeignKey("dbo.Customer", "StoreId", "dbo.Store");
            DropForeignKey("dbo.CustomerBillingInfo", "CustomerId", "dbo.Customer");
            DropTable("dbo.Employee_EmployeeRole_Mapping");
            DropTable("dbo.PermissionRecord_Role_Mapping");
            DropTable("dbo.ScheduleTask");
            DropTable("dbo.Log");
            DropTable("dbo.QueuedEmail");
            DropTable("dbo.EmailTemplates");
            DropTable("dbo.EmailAccount");
            DropTable("dbo.CustomerShippingInfo");
            DropTable("dbo.Orders");
            DropTable("dbo.RentalPrices");
            DropTable("dbo.Product");
            DropTable("dbo.StoreAddress");
            DropTable("dbo.PermissionRecord");
            DropTable("dbo.EmployeeRole");
            DropTable("dbo.Employee");
            DropTable("dbo.Store");
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerBillingInfo");
        }
    }
}
