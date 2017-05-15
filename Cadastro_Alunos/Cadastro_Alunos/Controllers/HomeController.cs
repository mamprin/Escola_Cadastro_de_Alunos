using Cadastro_Alunos.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Cadastro_Alunos.Controllers
{
    public class HomeController : Controller
    {
        // Home
        public ActionResult Index()
        {
            return View();
        }

        // Método que retorna a lista de todos os alunos
        public JsonResult GetTodosAlunos()
        {
            using (Aluno_Context contextObj = new Aluno_Context())
            {
                // Try Catch utilizado caso ocorra algum erro não previsto
                try
                {
                    // Realiza a busca de todos os alunos e retorna o resultado
                    var listaAlunos = contextObj.alunos.ToList();

                    // Retorna o resultado da busca
                    return Json(listaAlunos, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    // Dispara a excessão
                    throw ex;
                }
            }
        }

        // Método que realiza o cadastro de alunos
        public string AdicionarAluno(Alunos aluno)
        {
            // Valida se o objeto é nulo
            if (aluno != null)
            {
                using (Aluno_Context contextObj = new Aluno_Context())
                {
                    // Try Catch utilizado caso ocorra algum erro não previsto 
                    try
                    {
                        // Adiciona o aluno e salva as alterações
                        contextObj.alunos.Add(aluno);
                        contextObj.SaveChanges();

                        // Retorna a mensagem para o usuário
                        return "Cadastro de aluno realizado com sucesso.";
                    }
                    catch (Exception ex)
                    {
                        // Dispara a excessão
                        throw ex;
                    }
                }
            }
            else
            {
                // Retorna a mensagem para o usuário
                return "Não foi possível cadastrar o aluno.";
            }
        }

        // Método para realizar a atualização do Aluno
        public string AtualizaAluno(Alunos aluno)
        {
            // Valida se o objeto é nulo
            if (aluno != null)
            {
                // Try Catch utilizado caso ocorra algum erro não previsto
                try
                {
                    using (Aluno_Context contextObj = new Aluno_Context())
                    {
                        int alunoId = Convert.ToInt32(aluno.ID_ALUNO);

                        // Realiza a busca do aluno utilizando o ID
                        Alunos _aluno = contextObj.alunos.Where(a => a.ID_ALUNO == alunoId).FirstOrDefault();

                        // Realiza as alterações no Aluno
                        _aluno.NOME = aluno.NOME;
                        _aluno.ENDERECO = aluno.ENDERECO;
                        _aluno.NOME_MAE = aluno.NOME_MAE;
                        _aluno.SERIE = aluno.SERIE;

                        // Salva as alterações
                        contextObj.SaveChanges();

                        // Retorna a mensagem para o usuário
                        return "Dados do aluno atualizados com sucesso.";
                    }
                }
                catch (Exception ex)
                {
                    // Dispara a excessão
                    throw ex;
                }
            }
            else
            {
                // Retorna a mensagem para o usuário
                return "Aluno inválido.";
            }
        }

        // Método que exclui o Aluno
        public string ExcluirAluno(string idAluno)
        {

            // Valida se a string está vazia ou nula
            if (!String.IsNullOrEmpty(idAluno))
            {
                // Try Catch utilizado caso ocorra algum erro não previsto
                try
                {
                    int alunoId = Int32.Parse(idAluno);

                    using (Aluno_Context contextObj = new Aluno_Context())
                    {
                        // Realiza a busca do Aluno
                        var _aluno = contextObj.alunos.Find(alunoId);

                        // Remove o aluno e salva as alterações
                        contextObj.alunos.Remove(_aluno);
                        contextObj.SaveChanges();

                        // Retorna a mensagem para o usuário
                        return "Aluno selecionado excluído com sucesso.";
                    }
                }
                catch (Exception ex)
                {
                    // Dispara a excessão
                    throw ex;
                }
            }
            else
            {
                // Retorna a mensagem para o usuário
                return "Operação inválida.";
            }
        }
    }
}