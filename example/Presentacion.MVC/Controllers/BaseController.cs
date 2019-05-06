using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.MVC.Controllers
{
    public class BaseController : Controller
    {
        protected string DatabaseEngine = "EFCore";
    }
}