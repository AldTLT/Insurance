namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Car", new[] { "CarId" });
            DropPrimaryKey("dbo.Car");
            AlterColumn("dbo.Car", "CarId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Car", "CarId");
            CreateIndex("dbo.Car", "CarId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Car", new[] { "CarId" });
            DropPrimaryKey("dbo.Car");
            AlterColumn("dbo.Car", "CarId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Car", "CarId");
            CreateIndex("dbo.Car", "CarId");
        }
    }
}
