﻿using System;
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
                if (ModelState.IsValid)
                {
                    DatabaseEntities entities = new DatabaseEntities();
                    entities.Cliente.Add(cliente);
                    entities.SaveChanges();
                    return Redirect("/Cliente");
                }
                else
                {
                    return View(cliente);
                }
                
            }
            return View();
        }

        public ActionResult Editar(int Id = 0)
        {
            DatabaseEntities entities = new DatabaseEntities();
            Cliente cliente = entities.Cliente.Find(Id);

            if(cliente == null)
            {
                return HttpNotFound();
            }
            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(cliente, "", new string[] { "Nome", "Telefone", "Endereco" }))
                    {
                        entities.SaveChanges();
                        return Redirect("/Cliente");
                    }
                }
                
            }
            return View(cliente);
        }

        public ActionResult Deletar(int Id = 0)
        {
            DatabaseEntities entities = new DatabaseEntities();
            Cliente cliente = entities.Cliente.Find(Id);

            if (Id <= 0 || cliente == null)
            {
                return HttpNotFound();        
            }
            entities.Cliente.Remove(cliente);
            entities.SaveChanges();

            return Redirect("/Cliente");
        }
          
    }
}