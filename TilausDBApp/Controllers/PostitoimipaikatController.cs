﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TilausDBApp.Models;

namespace TilausDBApp.Controllers
{
    public class PostitoimipaikatController : Controller
    {
        private TilausDBEntities db = new TilausDBEntities();

        // GET: Postitoimipaikat
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "Kirjautunut: " + Session["UserName"];
                return View(db.Postitoimipaikat.ToList());
            }
        }

        // GET: Postitoimipaikat/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Postitoimipaikat postitoimipaikat = db.Postitoimipaikat.Find(id);
        //    if (postitoimipaikat == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(postitoimipaikat);
        //}

        // GET: Postitoimipaikat/Create
        public ActionResult Create()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "Kirjautunut: " + Session["UserName"];
                List<Postitoimipaikat> postitoimipaikat = db.Postitoimipaikat.ToList();
                return View();
            }
        }

        // POST: Postitoimipaikat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostiID,Postinumero,Postitoimipaikka")] Postitoimipaikat postitoimipaikat)
        {
            if (ModelState.IsValid)
            {
                db.Postitoimipaikat.Add(postitoimipaikat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postitoimipaikat);
        }

        // GET: Postitoimipaikat/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postitoimipaikat postitoimipaikat = db.Postitoimipaikat.Find(id);
            if (postitoimipaikat == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoggedStatus = "Kirjautunut: " + Session["UserName"];
            return View(postitoimipaikat);
        }

        // POST: Postitoimipaikat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostiID,Postinumero,Postitoimipaikka")] Postitoimipaikat postitoimipaikat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postitoimipaikat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postitoimipaikat);
        }

        // GET: Postitoimipaikat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postitoimipaikat postitoimipaikat = db.Postitoimipaikat.Find(id);
            if (postitoimipaikat == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoggedStatus = "Kirjautunut: " + Session["UserName"];
            return View(postitoimipaikat);
        }

        // POST: Postitoimipaikat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Postitoimipaikat postitoimipaikat = db.Postitoimipaikat.Find(id);
            db.Postitoimipaikat.Remove(postitoimipaikat);
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
