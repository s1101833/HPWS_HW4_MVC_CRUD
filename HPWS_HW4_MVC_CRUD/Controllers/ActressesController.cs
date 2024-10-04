using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HPWS_HW4_MVC_CRUD.Models;

namespace HPWS_HW4_MVC_CRUD.Controllers
{
    public class ActressesController : Controller
    {
        private ActressDBEntities db = new ActressDBEntities();

        // GET: Actresses
        public ActionResult Index()
        {
            return View(db.Actress.ToList());
        }

        // GET: Actresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actress actress = db.Actress.Find(id);
            if (actress == null)
            {
                return HttpNotFound();
            }
            return View(actress);
        }

        // GET: Actresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actresses/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,name_ch,height,bust,waist,hips,cup,info,stars")] Actress actress)
        {
            if (ModelState.IsValid)
            {
                db.Actress.Add(actress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actress);
        }

        // GET: Actresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actress actress = db.Actress.Find(id);
            if (actress == null)
            {
                return HttpNotFound();
            }
            return View(actress);
        }

        // POST: Actresses/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,name_ch,height,bust,waist,hips,cup,info,stars")] Actress actress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actress);
        }

        // GET: Actresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actress actress = db.Actress.Find(id);
            if (actress == null)
            {
                return HttpNotFound();
            }
            return View(actress);
        }

        // POST: Actresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actress actress = db.Actress.Find(id);
            db.Actress.Remove(actress);
            db.SaveChanges();
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
