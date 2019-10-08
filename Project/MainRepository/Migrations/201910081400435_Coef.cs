namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coef : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.CoefficientsId)
                .ForeignKey("dbo.Policy", t => t.CoefficientsId)
                .Index(t => t.CoefficientsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coefficients", "CoefficientsId", "dbo.Policy");
            DropIndex("dbo.Coefficients", new[] { "CoefficientsId" });
            DropTable("dbo.Coefficients");
        }
    }
}
