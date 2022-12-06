namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PkFkAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Users");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Users", "Id");
        }
    }
}
