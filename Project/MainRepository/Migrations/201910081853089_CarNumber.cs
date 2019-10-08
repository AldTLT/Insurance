namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarNumber : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Car", name: "CarId", newName: "Policy_PolicyID");
            RenameIndex(table: "dbo.Car", name: "IX_CarId", newName: "IX_Policy_PolicyID");
            DropPrimaryKey("dbo.Car");
            AddColumn("dbo.Car", "CarNumber", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.Car", "CarNumber");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Car");
            DropColumn("dbo.Car", "CarNumber");
            AddPrimaryKey("dbo.Car", "CarId");
            RenameIndex(table: "dbo.Car", name: "IX_Policy_PolicyID", newName: "IX_CarId");
            RenameColumn(table: "dbo.Car", name: "Policy_PolicyID", newName: "CarId");
        }
    }
}
