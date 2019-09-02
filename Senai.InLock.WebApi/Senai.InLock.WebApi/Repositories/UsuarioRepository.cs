using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public List<Usuarios> Listar()
        {
            using (InLockContext context = new InLockContext())
            {
                return context.Usuarios.ToList();

            }
        } // Lista os usuários

        public void Cadastrar(Usuarios usuario)
        {
            using (InLockContext context = new InLockContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        } //Cadastra um novo usuário

        public void Atualizar (Usuarios usuario, int id)
        {
            using (InLockContext context = new InLockContext())
            {
                Usuarios usuarioBuscado = context.Usuarios.FirstOrDefault(x => x.UsuarioId == id);
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
                usuarioBuscado.Permissao = usuario.Permissao;
                context.Usuarios.Update(usuarioBuscado);
                context.SaveChanges();
            }
        } // Atualiza um usuário

        public void Deletar(int id)
        {
            using (InLockContext context = new InLockContext())
            {
                Usuarios usuarioBuscado = context.Usuarios.Find(id);
                context.Usuarios.Remove(usuarioBuscado);
                context.SaveChanges();
            }
        } // Deleta um usuário da lista

        public Usuarios BuscarPorId(int id)
        {
            using (InLockContext context = new InLockContext())
            {
                return context.Usuarios.FirstOrDefault(x => x.UsuarioId == id);
            }
        } // Encontra um usuário por busca por id

    }
}
