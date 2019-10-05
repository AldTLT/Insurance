namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        EMail = c.String(nullable: false, maxLength: 50),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: true),
                        DriverLicenseDate = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.EMail);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Client");
        }
    }
}
