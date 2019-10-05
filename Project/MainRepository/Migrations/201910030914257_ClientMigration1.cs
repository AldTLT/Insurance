namespace MainRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "PasswordHash", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "PasswordHash");
        }
    }
}
