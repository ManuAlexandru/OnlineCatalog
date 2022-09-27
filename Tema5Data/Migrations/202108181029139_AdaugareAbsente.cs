namespace Tema5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdaugareAbsente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentisId = c.Int(nullable: false),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Absentes");
        }
    }
}
