namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coef1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coefficients", "CoefficientsId", "dbo.Policy");
            DropIndex("dbo.Coefficients", new[] { "CoefficientsId" });
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
            
            DropTable("dbo.Coefficients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Coefficients",
                c => new
                    {
                        CoefficientsId = c.Guid(nullable: false),
                        CarAge = c.Double(nullable: false),
                        DrivingExperience = c.Double(nullable: false),
                        DriverAge = c.Double(nullable: false),
                        EnginePower = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CoefficientsId);
            
            DropForeignKey("dbo.Ratio", "RatioId", "dbo.Policy");
            DropIndex("dbo.Ratio", new[] { "RatioId" });
            DropTable("dbo.Ratio");
            CreateIndex("dbo.Coefficients", "CoefficientsId");
            AddForeignKey("dbo.Coefficients", "CoefficientsId", "dbo.Policy", "PolicyID");
        }
    }
}
