namespace Tema5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchimbareClasa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Studentis", "ClaseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Studentis", "ClaseId");
            AddForeignKey("dbo.Studentis", "ClaseId", "dbo.Clases", "Id", cascadeDelete: true);
            DropColumn("dbo.Studentis", "StudentiId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Studentis", "StudentiId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Studentis", "ClaseId", "dbo.Clases");
            DropIndex("dbo.Studentis", new[] { "ClaseId" });
            DropColumn("dbo.Studentis", "ClaseId");
        }
    }
}
