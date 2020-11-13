using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnotacoesAPI.Models;
using MongoDB.Driver;


namespace AnotacoesAPI.Controllers
{
    public class FuncionariosController : Controller
    {
        MongoDbContext dbContext = new MongoDbContext();
        public IActionResult Index()
        {
            List<Funcionario> listaFuncs = dbContext.Funcionarios.Find(m => true).ToList();
            return View(listaFuncs);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var entity = dbContext.Funcionarios.Find(m => m.Id == id).FirstOrDefault();
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Funcionario entity)
        {
            dbContext.Funcionarios.ReplaceOne(m => m.Id == entity.Id, entity);

            return View(entity);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Funcionario entity)
        {
            entity.Id = Guid.NewGuid();

            dbContext.Funcionarios.InsertOne(entity);

            return RedirectToAction("Index", "Funcionarios");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MongoDbContext dbContext = new MongoDbContext();
            dbContext.Funcionarios.DeleteOne(m => m.Id == id);
            return RedirectToAction("Index", "Funcionarios");
        }
    }
}
