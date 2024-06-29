
using api_desafio21dias;

namespace api.Servicos
{
    public class AlunoServico
    {
        public static async Task<bool> ValidarAluno(int id)
        {
            using (var http = new HttpClient())
            {
                using (var response = await http.GetAsync($"{Program.AlunoApi}/alunos/{id}"))
                {
                    return response.IsSuccessStatusCode;
                }
            }
        }
    }
}