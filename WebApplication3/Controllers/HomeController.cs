using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.Entity;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        CorporationContext db =new CorporationContext();

        public ActionResult Index()
        {
            var people = db.People.Include(p => p.Corporation);
            ViewBag.Corporation = db.Corporations;             
            ViewBag.Person = people; 
                return View();
        }
        [HttpGet]
        public ActionResult EditPerson (int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            Person person = db.People.Find(id);
            if (person!=null)
            {
                SelectList dep = new SelectList(db.Corporations, "Id", "Department", person.Corporation_Id);
                SelectList pos = new SelectList(db.Corporations, "Id", "Position", person.Corporation_Id);
                ViewBag.Departments = dep;
                ViewBag.Positions = pos;
                return View(person);
            }
            //ViewBag.Id = id;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditPerson (Person person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddPerson(int id)//, int depId)
        {
            //depId = db.Corporations.Select(x => x.Id).FirstOrDefault();
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
            return RedirectToAction("Index");
                //"Сотрудник  " + person.Name + "  добавлен ";// + corpId;
        }
        public ActionResult Partial()
        {
           // ViewBag.Person = db.People;
            return PartialView();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetRedirect()
        {
            return RedirectToAction("GetContact");
           // return Redirect("/Home/GetContact");
        }
        public ActionResult GetContact()
        {
            return View();
        }
        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
        [HttpGet]
        public ActionResult Delete (int id)
        {
            Person per = db.People.Find(id);
            if (per==null) return HttpNotFound();
            return View(per);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed (int id)
        {
            Person per = db.People.Find(id);
            if (per == null) return HttpNotFound();
            db.People.Remove(per);
            return RedirectToAction("Index");
        }
    }
}