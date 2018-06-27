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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BoxInventory box)
        {
            if (ModelState.IsValid)
            {
                service.AddBox(box);
                return RedirectToAction("Index");
            }

            return View(box);
        }


        public ActionResult Delete(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            return View(box);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            service.DeleteBox(box);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            return View(box);
        }

        [HttpPost]
        public ActionResult Edit(BoxInventory box)
        {
            if (ModelState.IsValid)
            {
                service.SaveEdits(box);
                return RedirectToAction("Index");
            }
            return View(box);
        }

    }
}