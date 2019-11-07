using BDProjeto.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BDProjeto.Repositorio
{
    public class UsuarioDAO
    {

        //Banco 1
        private ConexaoBD conexaoBD;

        //Banco 2
        //private ConexaoBD2 conexaoBD;

        public UsuarioDAO()
        {
            //instanciar banco 1
            conexaoBD = new ConexaoBD();

            //instanciar banco 2
            //conexaoBD = new ConexaoBD2();

        }

        private void Inserir(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "Insert Into tb_usuarios(nome, cargo, data)";
            strQuery += string.Format(" values ('{0}', '{1}', '{2}')",
                                        usuario.Nome, usuario.Cargo, usuario.Data);

            conexaoBD.ExecutaComando(strQuery);

        }

        private void Alterar(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "Update tb_usuarios set ";
            strQuery += string.Format(" nome = '{0}',", usuario.Nome);
            strQuery += string.Format(" cargo = '{0}',", usuario.Cargo);
            strQuery += string.Format(" data = '{0}'", usuario.Data);
            strQuery += string.Format(" Where usuarioId = {0} ", usuario.Id);

            conexaoBD.ExecutaComando(strQuery);
        }

        public void Salvar(Usuario usuario)
        {
            if (usuario.Id > 0)
            {
                Alterar(usuario);
            }
            else
            {
                Inserir(usuario);
            }
        }

        public void Excluir(int usuarioId)
        {
            var strQuery = "";
            strQuery += string.Format("Delete from tb_usuarios Where usuarioId = {0} ", usuarioId);
            conexaoBD.ExecutaComando(strQuery);
        }

        public SqlDataReader Listar()
        {
            var strQuery = "Select * From tb_usuarios";
            return conexaoBD.ExecutaComandoComRetorno(strQuery);
        }

        public SqlDataReader BuscaPorId(int usuarioId)
        {
            var strQuery = string.Format("Select * From tb_usuarios Where usuarioId = {0} ",usuarioId);
            return conexaoBD.ExecutaComandoComRetorno(strQuery);
        }


        public IEnumerable<Usuario> ListarTodos()
        {

            List<Usuario> usuarios = new List<Usuario>();
            SqlDataReader lista = Listar();

            while (lista.Read())
            {
                Usuario usuario = new Usuario();
                usuario.Id = int.Parse(lista["usuarioId"].ToString());
                usuario.Nome = lista["nome"].ToString();
                usuario.Cargo = lista["cargo"].ToString();
                usuario.Data = DateTime.Parse(lista["data"].ToString());

                usuarios.Add(usuario);
            }
            
            return usuarios;
        }

        public Usuario ListarPorId(string usuarioId)
        {
            Usuario usuario = new Usuario();
            SqlDataReader buscaPorId = BuscaPorId(int.Parse(usuarioId));

            while (buscaPorId.Read())
            {
                usuario.Id = int.Parse(buscaPorId["usuarioId"].ToString());
                usuario.Nome = buscaPorId["nome"].ToString();
                usuario.Cargo = buscaPorId["cargo"].ToString();
                usuario.Data = DateTime.Parse(buscaPorId["data"].ToString());

            }

            return usuario;
        }

    }
}
