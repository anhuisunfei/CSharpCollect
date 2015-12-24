namespace EFEnumFlags.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductPhoto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_ProductPhoto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileSize = c.Single(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_ProductPhoto", "ProductId", "dbo.T_Product");
            DropIndex("dbo.T_ProductPhoto", new[] { "ProductId" });
            DropTable("dbo.T_ProductPhoto");
        }
    }
}
