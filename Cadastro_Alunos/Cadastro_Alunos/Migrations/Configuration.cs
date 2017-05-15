namespace Cadastro_Alunos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cadastro_Alunos.Models.Aluno_Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Cadastro_Alunos.Models.Aluno_Context";
        }

        protected override void Seed(Cadastro_Alunos.Models.Aluno_Context context)
        {
            
        }
    }
}
