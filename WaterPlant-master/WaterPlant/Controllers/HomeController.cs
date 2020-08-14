using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaterPlant.Models;

namespace WaterPlant.Controllers
{
    public class HomeController : Controller
    {
        Db db = new Db();
        //home page
        public ActionResult Index()
        {
            
            var list = db.Plant.ToList();
            return View(list);
        }
        // watering start
        [HttpPost]
        public JsonResult Watering(int plantid)
        {
            var plant = db.Plant.Where(c => c.Id == plantid).SingleOrDefault();

            plant.Status = "Watering";

            plant.LastWatered = DateTime.Now;

            db.SaveChanges();
            var result = new
            {
                Status = "Watering",
                Time=DateTime.Now.ToString()
            };
            return Json(result, JsonRequestBehavior.AllowGet);


        }

        //watering stop

        [HttpPost]
        public JsonResult WateringStop(int plantid)
        {
            var plant = db.Plant.Where(c => c.Id == plantid).SingleOrDefault();

            plant.Status = "Watered";

            plant.LastWatered = DateTime.Now;

            db.SaveChanges();
            var result = new
            {
                Status = "Watered",
                Time = DateTime.Now.ToString(),

            };
            return Json(result, JsonRequestBehavior.AllowGet);


        }

        //get whether plant is watered before 30 seconds
        [HttpGet]
        public JsonResult GetLastTime(int plantid)
        {
            var plant = db.Plant.Where(c => c.Id == plantid).SingleOrDefault();
            var res = true;
            var lw = DateTime.Parse(plant.LastWatered.ToString());
            var td = (DateTime.Now - plant.LastWatered).Value.TotalSeconds;

            if(td<30)
            {
                res = false;
            }
           

            return Json(res, JsonRequestBehavior.AllowGet);


        }

    }
}