namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carId12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Car", "CarId", "dbo.Policy");
            DropIndex("dbo.Car", new[] { "CarId" });
            DropPrimaryKey("dbo.Car");
            DropPrimaryKey("dbo.Policy");
            AlterColumn("dbo.Car", "CarId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Policy", "PolicyID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Car", "CarId");
            AddPrimaryKey("dbo.Policy", "PolicyID");
            CreateIndex("dbo.Car", "CarId");
            AddForeignKey("dbo.Car", "CarId", "dbo.Policy", "PolicyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Car", "CarId", "dbo.Policy");
            DropIndex("dbo.Car", new[] { "CarId" });
            DropPrimaryKey("dbo.Policy");
            DropPrimaryKey("dbo.Car");
            AlterColumn("dbo.Policy", "PolicyID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Car", "CarId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Policy", "PolicyID");
            AddPrimaryKey("dbo.Car", "CarId");
            CreateIndex("dbo.Car", "CarId");
            AddForeignKey("dbo.Car", "CarId", "dbo.Policy", "PolicyID");
        }
    }
}
