namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        CarId = c.Guid(nullable: false, identity: true),
                        Model = c.String(maxLength: 50),
                        ManufacturedYear = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        EnginePower = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Policy", t => t.CarId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Policy",
                c => new
                    {
                        PolicyID = c.Guid(nullable: false),
                        Cost = c.Int(nullable: false),
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
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EMail);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Car", "CarId", "dbo.Policy");
            DropForeignKey("dbo.Policy", "Client_EMail", "dbo.Client");
            DropIndex("dbo.Policy", new[] { "Client_EMail" });
            DropIndex("dbo.Car", new[] { "CarId" });
            DropTable("dbo.Role");
            DropTable("dbo.Client");
            DropTable("dbo.Policy");
            DropTable("dbo.Car");
        }
    }
}
