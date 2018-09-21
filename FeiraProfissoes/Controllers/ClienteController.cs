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
    }
}