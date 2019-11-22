namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        CarNumber = c.String(nullable: false, maxLength: 20),
                        Model = c.String(maxLength: 50),
                        ManufacturedYear = c.Int(nullable: false),
                        CarCost = c.Int(nullable: false),
                        EnginePower = c.Int(nullable: false),
                        Policy_PolicyID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CarNumber)
                .ForeignKey("dbo.Policy", t => t.Policy_PolicyID)
                .Index(t => t.Policy_PolicyID);
            
            CreateTable(
                "dbo.Policy",
                c => new
                    {
                        PolicyID = c.Guid(nullable: false, identity: true),
                        policyCost = c.Int(nullable: false),
                        PolicyDate = c.DateTime(nullable: false),
                        Client_EMail = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PolicyID)
                .ForeignKey("dbo.Client", t => t.Client_EMail, cascadeDelete: true)
                .Index(t => t.Client_EMail);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        EMail = c.String(nullable: false, maxLength: 50),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        DriverLicenseDate = c.DateTime(nullable: false),
                        PasswordHash = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.EMail);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.RoleName);
            
            CreateTable(
                "dbo.Ratio",
                c => new
                    {
                        RatioId = c.Guid(nullable: false),
                        CarAge = c.Double(nullable: false),
                        DrivingExperience = c.Double(nullable: false),
                        DriverAge = c.Double(nullable: false),
                        EnginePower = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RatioId)
                .ForeignKey("dbo.Policy", t => t.RatioId)
                .Index(t => t.RatioId);
            
            CreateTable(
                "dbo.RoleModelClientModels",
                c => new
                    {
                        RoleModel_RoleName = c.String(nullable: false, maxLength: 30),
                        ClientModel_EMail = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.RoleModel_RoleName, t.ClientModel_EMail })
                .ForeignKey("dbo.Role", t => t.RoleModel_RoleName, cascadeDelete: true)
                .ForeignKey("dbo.Client", t => t.ClientModel_EMail, cascadeDelete: true)
                .Index(t => t.RoleModel_RoleName)
                .Index(t => t.ClientModel_EMail);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Car", "Policy_PolicyID", "dbo.Policy");
            DropForeignKey("dbo.Ratio", "RatioId", "dbo.Policy");
            DropForeignKey("dbo.RoleModelClientModels", "ClientModel_EMail", "dbo.Client");
            DropForeignKey("dbo.RoleModelClientModels", "RoleModel_RoleName", "dbo.Role");
            DropForeignKey("dbo.Policy", "Client_EMail", "dbo.Client");
            DropIndex("dbo.RoleModelClientModels", new[] { "ClientModel_EMail" });
            DropIndex("dbo.RoleModelClientModels", new[] { "RoleModel_RoleName" });
            DropIndex("dbo.Ratio", new[] { "RatioId" });
            DropIndex("dbo.Policy", new[] { "Client_EMail" });
            DropIndex("dbo.Car", new[] { "Policy_PolicyID" });
            DropTable("dbo.RoleModelClientModels");
            DropTable("dbo.Ratio");
            DropTable("dbo.Role");
            DropTable("dbo.Client");
            DropTable("dbo.Policy");
            DropTable("dbo.Car");
        }
    }
}
