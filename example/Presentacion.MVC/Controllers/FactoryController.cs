using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Factories;
using Interfaces.Presentacion;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.MVC.Controllers
{
    public class FactoryController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            Interfaces.Presentacion.Entities.Factory factory = new Interfaces.Presentacion.Entities.Factory();
            return View(factory);
        }

        public IActionResult Add(Interfaces.Presentacion.Entities.Factory factory)
        {
            FactoryCommands factoryCommands = new FactoryCommands();
            IFactoryCommand factoryCommand = factoryCommands.CreateFactoryCommand(this.DatabaseEngine);

            factoryCommand.CreateFactory(factory);

            return RedirectToAction("Index", "Factory");
        }
    }
}