namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class car : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Policy", "Client_EMail", "dbo.Client");
            DropIndex("dbo.Policy", new[] { "Client_EMail" });
            DropPrimaryKey("dbo.Client");
            AlterColumn("dbo.Client", "EMail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Policy", "Client_EMail", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.Client", "EMail");
            CreateIndex("dbo.Policy", "Client_EMail");
            AddForeignKey("dbo.Policy", "Client_EMail", "dbo.Client", "EMail", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policy", "Client_EMail", "dbo.Client");
            DropIndex("dbo.Policy", new[] { "Client_EMail" });
            DropPrimaryKey("dbo.Client");
            AlterColumn("dbo.Policy", "Client_EMail", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Client", "EMail", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Client", "EMail");
            CreateIndex("dbo.Policy", "Client_EMail");
            AddForeignKey("dbo.Policy", "Client_EMail", "dbo.Client", "EMail", cascadeDelete: true);
        }
    }
}
