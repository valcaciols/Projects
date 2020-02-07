using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SFCTest.DAL;
using SFCTest.Models;

namespace SFCTest.Controllers
{
    public class RoutingGroupsController : Controller
    {
        private SfcContext db = new SfcContext();

        // GET: RoutingGroups
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            ViewData["IDProduct"] = id;
            var routingGroups = db.RoutingGroups.Where(r => r.IDProduct == id);
            return View(routingGroups.ToList());              
        }

        // GET: RoutingGroups/Create
        /*public ActionResult Create()
        {
            ViewBag.IDProduct = new SelectList(db.Products, "IDProduct", "ProductModel");
            return View();
        }*/

        public ActionResult Create(int id)
        {
            ViewBag.IDProduct = new SelectList(db.Products.Where(c => c.IDProduct == id), "IDProduct", "ProductModel");
            RoutingGroup group = new RoutingGroup();
            group.IDProduct = id;

            return View("Create", group);
        }

        // POST: RoutingGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRoutingStation,IDProduct,StationGroup,PassGroup,FailGroup,DateCreate")] RoutingGroup routingGroup)
        {
            if (ModelState.IsValid)
            {
                db.RoutingGroups.Add(routingGroup);
                db.SaveChanges();
                return RedirectToAction("Index", new {id = routingGroup.IDProduct});
            }

            ViewBag.IDProduct = new SelectList(db.Products, "IDProduct", "ProductModel", routingGroup.IDProduct) ;
            return View(routingGroup);
        }

        // GET: RoutingGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoutingGroup routingGroup = db.RoutingGroups.Find(id);
            if (routingGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProduct = new SelectList(db.Products, "IDProduct", "ProductModel", routingGroup.IDProduct);
            return View(routingGroup);
        }

        // POST: RoutingGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRoutingStation,IDProduct,StationGroup,PassGroup,FailGroup,DateCreate")] RoutingGroup routingGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routingGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = routingGroup.IDProduct });
            }
            ViewBag.IDProduct = new SelectList(db.Products, "IDProduct", "ProductModel", routingGroup.IDProduct);
            return View(routingGroup);
        }

        // GET: RoutingGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoutingGroup routingGroup = db.RoutingGroups.Find(id);
            if (routingGroup == null)
            {
                return HttpNotFound();
            }
            return View(routingGroup);
        }

        // POST: RoutingGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoutingGroup routingGroup = db.RoutingGroups.Find(id);
            db.RoutingGroups.Remove(routingGroup);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = routingGroup.IDProduct });
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
