using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLDA.Models;

namespace QLDA.Areas.Admin.Controllers
{
    public class SuaController : Controller
    {
        private QLDAEntities db = new QLDAEntities();

        // GET: Sua
        public ActionResult Index()
        {
            var sua = db.Sua.Include(s => s.HangSX).Include(s => s.LoaiSua);
            return View(sua.ToList());
        }

        // GET: Sua/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sua sua = db.Sua.Find(id);
            if (sua == null)
            {
                return HttpNotFound();
            }
            return View(sua);
        }

        // GET: Sua/Create
        public ActionResult Create()
        {
            ViewBag.HangSX_ID = new SelectList(db.HangSX, "ID", "TenHangSX");
            ViewBag.LoaiSua_ID = new SelectList(db.LoaiSua, "ID", "TenLoai");
            return View();
        }

        // POST: Sua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HangSX_ID,LoaiSua_ID,TenSua,DonGia,SoLuong,AnhMau,MoTa")] Sua sua)
        {
            if (ModelState.IsValid)
            {
                db.Sua.Add(sua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HangSX_ID = new SelectList(db.HangSX, "ID", "TenHangSX", sua.HangSX_ID);
            ViewBag.LoaiSua_ID = new SelectList(db.LoaiSua, "ID", "TenLoai", sua.LoaiSua_ID);
            return View(sua);
        }

        // GET: Sua/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sua sua = db.Sua.Find(id);
            if (sua == null)
            {
                return HttpNotFound();
            }
            ViewBag.HangSX_ID = new SelectList(db.HangSX, "ID", "TenHangSX", sua.HangSX_ID);
            ViewBag.LoaiSua_ID = new SelectList(db.LoaiSua, "ID", "TenLoai", sua.LoaiSua_ID);
            return View(sua);
        }

        // POST: Sua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HangSX_ID,LoaiSua_ID,TenSua,DonGia,SoLuong,AnhMau,MoTa")] Sua sua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HangSX_ID = new SelectList(db.HangSX, "ID", "TenHangSX", sua.HangSX_ID);
            ViewBag.LoaiSua_ID = new SelectList(db.LoaiSua, "ID", "TenLoai", sua.LoaiSua_ID);
            return View(sua);
        }

        // GET: Sua/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sua sua = db.Sua.Find(id);
            if (sua == null)
            {
                return HttpNotFound();
            }
            return View(sua);
        }

        // POST: Sua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sua sua = db.Sua.Find(id);
            db.Sua.Remove(sua);
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
