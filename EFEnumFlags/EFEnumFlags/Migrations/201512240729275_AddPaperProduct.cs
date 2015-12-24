namespace EFEnumFlags.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaperProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_PaperProduct",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PageNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Product", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_PaperProduct", "Id", "dbo.T_Product");
            DropIndex("dbo.T_PaperProduct", new[] { "Id" });
            DropTable("dbo.T_PaperProduct");
        }
    }
}
