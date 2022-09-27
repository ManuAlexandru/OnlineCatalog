namespace Tema5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudenti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Studentis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(nullable: false),
                        Prenume = c.String(nullable: false),
                        CNP = c.Long(nullable: false),
                        Email = c.String(nullable: false),
                        StudentiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Studentis", t => t.StudentiId)
                .Index(t => t.StudentiId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Studentis", "StudentiId", "dbo.Studentis");
            DropIndex("dbo.Studentis", new[] { "StudentiId" });
            DropTable("dbo.Studentis");
            DropTable("dbo.Clases");
        }
    }
}
