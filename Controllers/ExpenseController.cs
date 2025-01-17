﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Icarus.Models;

namespace Icarus.Controllers
{
    public class ExpenseController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        // GET: Expens
        public ActionResult Index()
        {
            return View(db.tblExpenses.ToList());
        }

        // GET: Expens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExpens tblExpens = db.tblExpenses.Find(id);
            if (tblExpens == null)
            {
                return HttpNotFound();
            }
            return View(tblExpens);
        }

        // GET: Expens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDExpense,DatePosted,ExpenseDate,ORNumber,IDVendor,Particulars,WithReceipt,IDAccount,EncodedBy,IsVerified,ChargeToCodep,VATSales,VATAmount,VATExempt,Amount,PostedDate,ChargedToCodep,TIN")] tblExpens tblExpens)
        {
            if (ModelState.IsValid)
            {
                db.tblExpenses.Add(tblExpens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblExpens);
        }

        // GET: Expens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExpens tblExpens = db.tblExpenses.Find(id);
            if (tblExpens == null)
            {
                return HttpNotFound();
            }
            return View(tblExpens);
        }

        // POST: Expens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDExpense,DatePosted,ExpenseDate,ORNumber,IDVendor,Particulars,WithReceipt,IDAccount,EncodedBy,IsVerified,ChargeToCodep,VATSales,VATAmount,VATExempt,Amount,PostedDate,ChargedToCodep,TIN")] tblExpens tblExpens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblExpens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblExpens);
        }

        // GET: Expens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExpens tblExpens = db.tblExpenses.Find(id);
            if (tblExpens == null)
            {
                return HttpNotFound();
            }
            return View(tblExpens);
        }

        // POST: Expens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblExpens tblExpens = db.tblExpenses.Find(id);
            db.tblExpenses.Remove(tblExpens);
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
