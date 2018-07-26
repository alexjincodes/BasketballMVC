using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasketballMVC.Models;
using System.Data.Entity;

namespace BasketballMVC.Controllers
{
    public class BasketballController : Controller
    {
        // GET: Basketball
        public ActionResult Index()
        {
            return View();
        }

        //**** Loading the database onto the MVC *****//
        public ActionResult GetData()
        {
            using (BasketballEntities db = new BasketballEntities())
            {
                var bList = db.Basketballs.ToList();    
                return Json(new { data = bList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]

        public ActionResult AddOrEdit(int id=0)
        {
                return View(new Basketball());
        }

        [HttpPost]
        public ActionResult AddOrEdit(Basketball entry)
        {
            using (BasketballEntities db = new BasketballEntities())
            {
                var success = true;   //Setting condition
                var message = "";     //Test logic
                var newList = db.Basketballs.ToList();      //creating new list to compare too
                var compare = from c in newList
                              where c.Exercise == entry.Exercise && c.ExerciseDate == entry.ExerciseDate
                              select c;     //LINQ to filter what to compare
                if (compare.Any())     //Checking if same exercise added on same day
                {
                    success = false;
                    message = "false!";
                }
                else     //IF condition is met, add and save data entry
                {
                    db.Basketballs.Add(entry);
                    db.SaveChanges();
                    success = true;
                    message = "succesful save!";
                }
                 return Json(new { success, message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}