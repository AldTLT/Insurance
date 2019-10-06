namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carpolicyId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Car", "PolicyId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Car", "PolicyId");
        }
    }
}
