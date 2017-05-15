
using System.Data.Entity;


namespace Cadastro_Alunos.Models
{
    public class Aluno_Context : DbContext
    {
        public Aluno_Context()
                     : base("Escola")
        { }
        public DbSet<Alunos> alunos { get; set; }
    }
}
