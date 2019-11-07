using BDProjeto.Aplicacao;
using BDProjeto.Dominio;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var appUsuario = new UsuarioAplicacao();
            var listaUsuarios = appUsuario.ListarTodos();

            return View(listaUsuarios);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var appUsuario = new UsuarioAplicacao();
                appUsuario.Salvar(usuario);

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Editar(string id)
        {
            var appUsuario = new UsuarioAplicacao();
            var usuario = appUsuario.ListarPorId(id);
            
            if(usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var appUsuario = new UsuarioAplicacao();
                appUsuario.Salvar(usuario);

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Detalhes(string id)
        {
            var appUsuario = new UsuarioAplicacao();
            var usuario = appUsuario.ListarPorId(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        public ActionResult Excluir(string id)
        {
            var appUsuario = new UsuarioAplicacao();
            var usuario = appUsuario.ListarPorId(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var appUsuario = new UsuarioAplicacao();
            appUsuario.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}