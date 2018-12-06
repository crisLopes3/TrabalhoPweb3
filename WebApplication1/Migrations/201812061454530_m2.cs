namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.XXX", newName: "AlunosPropostas");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AlunosPropostas", newName: "XXX");
        }
    }
}
