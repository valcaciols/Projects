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
    public class StationGroupsController : Controller
    {
        private SfcContext db = new SfcContext();

        // GET: StationGroups
        public ActionResult Index()
        {
            return View(db.StationGroups.ToList());
        }

        // GET: StationGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationGroup stationGroup = db.StationGroups.Find(id);
            if (stationGroup == null)
            {
                return HttpNotFound();
            }
            return View(stationGroup);
        }

        // GET: StationGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StationGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDStationGroup,STATION_GROUP_CODE,DESCRIPTION")] StationGroup stationGroup)
        {
            if (ModelState.IsValid)
            {
                db.StationGroups.Add(stationGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stationGroup);
        }

        // GET: StationGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationGroup stationGroup = db.StationGroups.Find(id);
            if (stationGroup == null)
            {
                return HttpNotFound();
            }
            return View(stationGroup);
        }

        // POST: StationGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDStationGroup,STATION_GROUP_CODE,DESCRIPTION")] StationGroup stationGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stationGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stationGroup);
        }

        // GET: StationGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationGroup stationGroup = db.StationGroups.Find(id);
            if (stationGroup == null)
            {
                return HttpNotFound();
            }
            return View(stationGroup);
        }

        // POST: StationGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StationGroup stationGroup = db.StationGroups.Find(id);
            db.StationGroups.Remove(stationGroup);
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
