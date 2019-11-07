using BDProjeto.Dominio;
using BDProjeto.Repositorio;
using System.Collections.Generic;

namespace BDProjeto.Aplicacao
{
    public class UsuarioAplicacao
    {

        private readonly UsuarioDAO usuarioDAO;

        public UsuarioAplicacao()
        {
            usuarioDAO = new UsuarioDAO();
        }



        public void Salvar(Usuario usuario)
        {
            usuarioDAO.Salvar(usuario);
        }

        public void Excluir(int usuarioId)
        {
            usuarioDAO.Excluir(usuarioId);
        }

        public IEnumerable<Usuario> ListarTodos()
        {

            return usuarioDAO.ListarTodos();
        }
        

        public Usuario ListarPorId(string id)
        {

            return usuarioDAO.ListarPorId(id);
        }


    }
}
