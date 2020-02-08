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
        public ActionResult Index()
        {
            var routingGroups = db.RoutingGroups.Include(r => r.FailStation).Include(r => r.PassStation).Include(r => r.Product).Include(r => r.Station);
            return View(routingGroups.ToList());
        }

        // GET: RoutingGroups/Details/5
        public ActionResult Details(int? id)
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

        // GET: RoutingGroups/Create
        public ActionResult Create()
        {
            ViewBag.IDFailGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE");
            ViewBag.IDPassGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE");
            ViewBag.IDProduct = new SelectList(db.Products, "IDProduct", "ProductModel");
            ViewBag.IDStationGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE");
            return View();
        }

        // POST: RoutingGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRoutingStation,IDProduct,IDStationGroup,IDPassGroup,IDFailGroup")] RoutingGroup routingGroup)
        {
            if (ModelState.IsValid)
            {
                routingGroup.DateCreate = DateTime.Now;
                db.RoutingGroups.Add(routingGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDFailGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE", routingGroup.IDFailGroup);
            ViewBag.IDPassGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE", routingGroup.IDPassGroup);
            ViewBag.IDProduct = new SelectList(db.Products, "IDProduct", "ProductModel", routingGroup.IDProduct);
            ViewBag.IDStationGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE", routingGroup.IDStationGroup);
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
            ViewBag.IDFailGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE", routingGroup.IDFailGroup);
            ViewBag.IDPassGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE", routingGroup.IDPassGroup);
            ViewBag.IDProduct = new SelectList(db.Products, "IDProduct", "ProductModel", routingGroup.IDProduct);
            ViewBag.IDStationGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE", routingGroup.IDStationGroup);
            return View(routingGroup);
        }

        // POST: RoutingGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRoutingStation,IDProduct,IDStationGroup,IDPassGroup,IDFailGroup")] RoutingGroup routingGroup)
        {
            if (ModelState.IsValid)
            {
                routingGroup.DateCreate = DateTime.Now;
                db.Entry(routingGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDFailGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE", routingGroup.IDFailGroup);
            ViewBag.IDPassGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE", routingGroup.IDPassGroup);
            ViewBag.IDProduct = new SelectList(db.Products, "IDProduct", "ProductModel", routingGroup.IDProduct);
            ViewBag.IDStationGroup = new SelectList(db.StationGroups, "IDStationGroup", "STATION_GROUP_CODE", routingGroup.IDStationGroup);
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
