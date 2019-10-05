namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Policy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Policy",
                c => new
                    {
                        PolicyID = c.String(nullable: false, maxLength: 128),
                        Cost = c.Int(nullable: false),
                        PolicyDate = c.DateTime(nullable: false),
                        Client_EMail = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PolicyID)
                .ForeignKey("dbo.Client", t => t.Client_EMail, cascadeDelete: true)
                .Index(t => t.Client_EMail);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policy", "Client_EMail", "dbo.Client");
            DropIndex("dbo.Policy", new[] { "Client_EMail" });
            DropTable("dbo.Policy");
        }
    }
}
