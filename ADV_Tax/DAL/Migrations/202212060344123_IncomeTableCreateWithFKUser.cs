namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncomeTableCreateWithFKUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false));
        }
    }
}
