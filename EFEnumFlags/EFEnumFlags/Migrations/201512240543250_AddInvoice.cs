namespace EFEnumFlags.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.T_Product", "InvoiceId", c => c.Int());
            CreateIndex("dbo.T_Product", "InvoiceId");
            AddForeignKey("dbo.T_Product", "InvoiceId", "dbo.T_Invoice", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Product", "InvoiceId", "dbo.T_Invoice");
            DropIndex("dbo.T_Product", new[] { "InvoiceId" });
            DropColumn("dbo.T_Product", "InvoiceId");
            DropTable("dbo.T_Invoice");
        }
    }
}
