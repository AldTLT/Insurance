namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guid_policy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Car", "Policy_PolicyID", "dbo.Policy");
            DropIndex("dbo.Car", new[] { "Policy_PolicyID" });
            DropColumn("dbo.Car", "CarId");
            RenameColumn(table: "dbo.Car", name: "Policy_PolicyID", newName: "CarId");
            DropPrimaryKey("dbo.Car");
            DropPrimaryKey("dbo.Policy");
            AlterColumn("dbo.Car", "CarId", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Policy", "PolicyID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Role", "RoleName", c => c.String(maxLength: 30));
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
            AlterColumn("dbo.Role", "RoleName", c => c.String());
            AlterColumn("dbo.Policy", "PolicyID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Car", "CarId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Policy", "PolicyID");
            AddPrimaryKey("dbo.Car", "CarId");
            RenameColumn(table: "dbo.Car", name: "CarId", newName: "Policy_PolicyID");
            AddColumn("dbo.Car", "CarId", c => c.Guid(nullable: false, identity: true));
            CreateIndex("dbo.Car", "Policy_PolicyID");
            AddForeignKey("dbo.Car", "Policy_PolicyID", "dbo.Policy", "PolicyID");
        }
    }
}
