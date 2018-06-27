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
        public ActionResult Index(string sortOrder)
        {
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : "";
            ViewBag.InventoryCountSortParm = sortOrder == "InventoryCount" ? "InventoryCount_desc" : "InventoryCount";
            ViewBag.WeightSortParm = sortOrder == "Weight" ? "Weight_desc" : "Weight";
            ViewBag.VolumeSortParm = sortOrder == "Volume" ? "Volume_desc" : "Volume";
            ViewBag.CostSortParm = sortOrder == "Cost" ? "Cost_desc" : "Cost";
            var boxes = from b in service.GetAllBoxes() select b;
            switch (sortOrder)
            {
                case "Id_desc":
                    boxes = boxes.OrderByDescending(b => b.Id);
                    break;
                case "InventoryCount_desc":
                    boxes = boxes.OrderByDescending(b => b.InventoryCount);
                    break;
                case "InventoryCount":
                    boxes = boxes.OrderBy(b => b.InventoryCount);
                    break;
                case "Weight_desc":
                    boxes = boxes.OrderByDescending(b => b.Weight);
                    break;
                case "Weight":
                    boxes = boxes.OrderBy(b => b.Weight);
                    break;
                case "Volume_desc":
                    boxes = boxes.OrderByDescending(b => b.Volume);
                    break;
                case "Volume":
                    boxes = boxes.OrderBy(b => b.Volume);
                    break;
                case "Cost_desc":
                    boxes = boxes.OrderByDescending(b => b.Cost);
                    break;
                case "Cost":
                    boxes = boxes.OrderBy(b => b.Cost);
                    break;
            }
            return View(boxes.ToList());
        }
    }
}