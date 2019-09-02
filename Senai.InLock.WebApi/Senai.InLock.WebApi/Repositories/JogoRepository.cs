﻿using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
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
        public void Atualizar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.FirstOrDefault(x => x.JogoId == jogo.JogoId);
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
    }
}