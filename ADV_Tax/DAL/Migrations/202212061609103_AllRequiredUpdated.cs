namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllRequiredUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incomes", "IncomeInfo", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "Details", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Details", c => c.String());
            AlterColumn("dbo.Tickets", "Subject", c => c.String());
            AlterColumn("dbo.Incomes", "IncomeInfo", c => c.String());
        }
    }
}
