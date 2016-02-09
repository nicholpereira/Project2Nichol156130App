using LayeredApplication.BusinessLayer;
using LayeredApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            VehiclesManager manager = new VehiclesManager();
            return View(model: manager.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vehicle vehicle)
        {
            VehiclesManager manager = new VehiclesManager();
            var item = manager.Add(vehicle);

            return View(viewName: "Details", model: item);
        }

        public ActionResult Edit(int id)
        {
            VehiclesManager manager = new VehiclesManager();
            var item = manager.Get(id);
            return View(model: item);
        }

        [HttpPost]
        public ActionResult Edit(Vehicle vehicle)
        {
            VehiclesManager manager = new VehiclesManager();
            manager.Update(vehicle);
            var item = manager.Get(vehicle.Id);
            return View(viewName: "Details", model: item);
        }

        public ActionResult Details(int id)
        {
            VehiclesManager manager = new VehiclesManager();
            var item = manager.Get(id);
            return View(model: item);
        }

        public ActionResult Delete(int id)
        {
            VehiclesManager manager = new VehiclesManager();
            var item = manager.Get(id);
            manager.Remove(item);
            return View("Index");
        }
    }
}