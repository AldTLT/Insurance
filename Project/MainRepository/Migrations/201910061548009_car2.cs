namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class car2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Car", "PolicyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Car", "PolicyId", c => c.String());
        }
    }
}
