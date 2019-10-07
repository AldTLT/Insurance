namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carId7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Car", "CarId", "dbo.Policy");
            DropPrimaryKey("dbo.Policy");
            AlterColumn("dbo.Policy", "PolicyID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Policy", "PolicyID");
            AddForeignKey("dbo.Car", "CarId", "dbo.Policy", "PolicyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Car", "CarId", "dbo.Policy");
            DropPrimaryKey("dbo.Policy");
            AlterColumn("dbo.Policy", "PolicyID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Policy", "PolicyID");
            AddForeignKey("dbo.Car", "CarId", "dbo.Policy", "PolicyID");
        }
    }
}
