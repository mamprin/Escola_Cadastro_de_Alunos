using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastro_Alunos.Models
{
    [Table("Alunos")]
    public class Alunos
    {
        [Key]
        public int ID_ALUNO { get; set; }
        public string NOME { get; set; }
        public string NOME_MAE { get; set; }
        public string ENDERECO { get; set; }
        public string SERIE { get; set; }
    }
}