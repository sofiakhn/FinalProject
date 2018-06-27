using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.Data;
using BoxProblem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoxProblem.Controllers
{
    public class BoxController : Controller
    {
        private BoxService service;
        public BoxController(ApplicationDbContext context)
        {
            service = new BoxService(context);
        }
        public ActionResult Index()
        {
            return View(service.GetAllBoxes());
        }
    }
}