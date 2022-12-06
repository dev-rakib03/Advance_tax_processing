namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTableCreated1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MethodName = c.String(nullable: false),
                        AccountNumber = c.Long(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentSettings");
        }
    }
}
