namespace EFEnumFlags.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCertification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Certification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Inspector = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.T_Product", "CertificationId", c => c.Int(nullable: false));
            CreateIndex("dbo.T_Product", "CertificationId");
            AddForeignKey("dbo.T_Product", "CertificationId", "dbo.T_Certification", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Product", "CertificationId", "dbo.T_Certification");
            DropIndex("dbo.T_Product", new[] { "CertificationId" });
            DropColumn("dbo.T_Product", "CertificationId");
            DropTable("dbo.T_Certification");
        }
    }
}
