using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeiraProfissoes.Database;

namespace FeiraProfissoes.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            DatabaseEntities entities = new DatabaseEntities();
            List<Cliente> clientes = entities.Cliente.ToList();
            return View(clientes);
        }

        public ActionResult Novo(Cliente cliente)
        {
            if (Request.HttpMethod == "POST")
            {
                DatabaseEntities entities = new DatabaseEntities();
                entities.Cliente.Add(cliente);
                entities.SaveChanges();
                return Redirect("/Cliente");
            }
            return View();
        }
    }
}