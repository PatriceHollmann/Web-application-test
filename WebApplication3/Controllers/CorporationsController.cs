using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CorporationsController : Controller
    {
        private CorporationContext db = new CorporationContext();

        // GET: Corporations
        public async Task<ActionResult> Index()
        {
            return View(await db.Corporations.ToListAsync());
        }

        // GET: Corporations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporation corporation = await db.Corporations.FindAsync(id);
            if (corporation == null)
            {
                return HttpNotFound();
            }
            return View(corporation);
        }

        // GET: Corporations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Corporations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Salary,Position,Department")] Corporation corporation)
        {
            if (ModelState.IsValid)
            {
                db.Corporations.Add(corporation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(corporation);
        }

        // GET: Corporations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporation corporation = await db.Corporations.FindAsync(id);
            if (corporation == null)
            {
                return HttpNotFound();
            }
            return View(corporation);
        }

        // POST: Corporations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Salary,Position,Department")] Corporation corporation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(corporation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(corporation);
        }

        // GET: Corporations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporation corporation = await db.Corporations.FindAsync(id);
            if (corporation == null)
            {
                return HttpNotFound();
            }
            return View(corporation);
        }

        // POST: Corporations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Corporation corporation = await db.Corporations.FindAsync(id);
            db.Corporations.Remove(corporation);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
