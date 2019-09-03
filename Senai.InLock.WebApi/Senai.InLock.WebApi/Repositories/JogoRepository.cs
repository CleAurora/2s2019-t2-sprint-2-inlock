using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {

        private string StringConexao = "Data Source=localhost; initial catalog=M_InLock; Integrated Security=true";

        /// <summary>
        /// Lista os jogos
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();
            }
        }

        /// <summary>
        /// Cadastra novo Jogo
        /// </summary>
        /// <param name="jogo"></param>
        public void Cadastrar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca Jogo por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>jogo</returns>
        public Jogos BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.JogoId == id);
            }
        }

        /// <summary>
        /// Artualiza jogo
        /// </summary>
        /// <param name="jogo"></param>
        public void Atualizar(Jogos jogo, int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.FirstOrDefault(x => x.JogoId == id);
                JogoBuscado.NomeJogo = jogo.NomeJogo;
                ctx.Update(JogoBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta Jogo
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.Find(id);
                ctx.Jogos.Remove(JogoBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista os jogos com os respectivos Estudios
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        public List<Jogos> ListarJogosEEstudios()
        {
            List<Jogos> jogos = new List<Jogos>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select Jogos.JogoId, Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudios.NomeEstudio from Jogos join Estudios on Jogos.EstudioId = Estudios.EstudioId";

                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // executa a query
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Jogos jogo = new Jogos
                        {
                            JogoId = Convert.ToInt32(sdr["JogoId"]),
                            NomeJogo = sdr["Nome"].ToString(),
                            Estudio = new Estudios
                            {
                                EstudioId = Convert.ToInt32(sdr["EstudioId"]),
                                NomeEstudio = sdr["NomeEstudio"].ToString(),
                                DataCriacao = Convert.ToDateTime(sdr["DataCriacao"]),
                                PaisOrigem = sdr["PaisOrigem"].ToString()
                            }
                        };
                        jogos.Add(jogo);
                    }

                }
            }
            return jogos;

        }
    }
}
