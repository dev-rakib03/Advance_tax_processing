namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role_correction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "Permission", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Permission", c => c.Int(nullable: false));
        }
    }
}
