namespace EFEnumFlags.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_Payrecords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PayType = c.Int(nullable: false),
                        PayDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.t_Payrecords");
        }
    }
}
