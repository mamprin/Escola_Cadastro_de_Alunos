namespace Cadastro_Alunos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        ID_ALUNO = c.Int(nullable: false, identity: true),
                        NOME = c.String(),
                        NOME_MAE = c.String(),
                        ENDERECO = c.String(),
                        SERIE = c.String(),
                    })
                .PrimaryKey(t => t.ID_ALUNO);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Alunos");
        }
    }
}
