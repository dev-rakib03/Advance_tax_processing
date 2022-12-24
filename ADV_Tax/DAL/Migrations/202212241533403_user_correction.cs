namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_correction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "AccountType", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "TinNumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "TinNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "AccountType", c => c.Int(nullable: false));
        }
    }
}
