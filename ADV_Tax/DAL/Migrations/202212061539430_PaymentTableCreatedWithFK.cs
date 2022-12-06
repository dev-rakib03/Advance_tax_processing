namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTableCreatedWithFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncomeId = c.Int(nullable: false),
                        PaymentAccount = c.Long(nullable: false),
                        TrxId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Incomes", t => t.IncomeId, cascadeDelete: true)
                .Index(t => t.IncomeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "IncomeId", "dbo.Incomes");
            DropIndex("dbo.Payments", new[] { "IncomeId" });
            DropTable("dbo.Payments");
        }
    }
}
