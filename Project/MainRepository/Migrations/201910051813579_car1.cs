namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class car1 : DbMigration
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
                        Policy_PolicyID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Policy", t => t.Policy_PolicyID)
                .Index(t => t.Policy_PolicyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Car", "Policy_PolicyID", "dbo.Policy");
            DropIndex("dbo.Car", new[] { "Policy_PolicyID" });
            DropTable("dbo.Car");
        }
    }
}
