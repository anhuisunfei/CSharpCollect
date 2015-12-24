namespace EFEnumFlags.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductTag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_ProductTag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Product_Tag_Mapping",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Tag_Id })
                .ForeignKey("dbo.T_Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.T_ProductTag", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Tag_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Product_Tag_Mapping", "Tag_Id", "dbo.T_ProductTag");
            DropForeignKey("dbo.T_Product_Tag_Mapping", "Product_Id", "dbo.T_Product");
            DropIndex("dbo.T_Product_Tag_Mapping", new[] { "Tag_Id" });
            DropIndex("dbo.T_Product_Tag_Mapping", new[] { "Product_Id" });
            DropTable("dbo.T_Product_Tag_Mapping");
            DropTable("dbo.T_ProductTag");
        }
    }
}
