using System;
using System.Data.SqlClient;
using BDProjeto.Dominio;
using BDProjeto.Aplicacao;
using System.Collections.Generic;

namespace FrontDOS
{
    class Program
    {
        static void Main(string[] args)
        {

            Usuario usuarios = new Usuario();
            UsuarioAplicacao app = new UsuarioAplicacao();


            //Acessar a classe de banco
            //var bd = new bd();
            //var usuarioAplicacao = new UsuarioAplicacao();
            //var usuarios = new Usuarios();

            //Conexao com o autenticacion
            //SqlConnection conexao = new SqlConnection(@"data source=DAYSE ; Integrated Security=SSPI ; Initial Catalog=db_cursoMVC");
            //conexao.Open();

            //string strQueryUpdate = "Update tb_usuarios set nome = 'Lourdes' where usuarioId = 10";
            //SqlCommand cmdComandoUpdate = new SqlCommand(strQueryUpdate, conexao);
            //cmdComandoUpdate.ExecuteNonQuery();

            //string strQueryDelete = "Delete tb_usuarios from where usuarioId = 10";
            //SqlCommand cmdComandoDelete = new SqlCommand(strQueryDelete, conexao);
            //cmdComandoDelete.ExecuteNonQuery();

            Console.WriteLine("Digite o nome do funcionario: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o cargo do funcionario: ");
            string cargo = Console.ReadLine();

            Console.WriteLine("Digite a data do cadastro: ");
            string data = Console.ReadLine();

            Console.WriteLine("Digite o Id que deseja alterar: ");
            string id = Console.ReadLine();

            usuarios.Nome = nome;
            usuarios.Cargo = cargo;
            usuarios.Data = DateTime.Parse(data);
            usuarios.Id = string.IsNullOrEmpty(id)? 0 : int.Parse(id);


            app.Salvar(usuarios);
            //string strQueryInsert = string.Format("Insert Into tb_usuarios(nome, cargo, data) values ('{0}', '{1}', '{2}')", nome.ToString(), cargo, data);
            //bd.ExecutaComando(strQueryInsert);

            //string strQuerySelect = "Select * From tb_usuarios";
            //SqlDataReader dados = bd.ExecutaComandoComRetorno(strQuerySelect);

            IEnumerable<Usuario> dados = new List<Usuario>();
            dados = app.ListarTodos();


            foreach(Usuario item in dados)
            {

                //Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3}",
                //                    dados["usuarioId"], dados["nome"], dados["cargo"], dados["data"]);

                Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3}",
                                    item.Id, item.Nome, item.Cargo, item.Data);
            }
        }
    }
}
