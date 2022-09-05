using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingAppMVC1.Data;
using TrainingAppMVC1.Models;

namespace TrainingAppMVC1.Controllers
{
    public class TestModelsController : Controller
    {
        private TestContext db = new TestContext();

        // GET: TestModels
        public async Task<ActionResult> Index()
        {
            return View(await db.TestModels.ToListAsync());
        }

        // GET: TestModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestModel testModel = await db.TestModels.FindAsync(id);
            if (testModel == null)
            {
                return HttpNotFound();
            }
            return View(testModel);
        }

        // GET: TestModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,colOne,colTwo,colThree")] TestModel testModel)
        {
            if (ModelState.IsValid)
            {
                db.TestModels.Add(testModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(testModel);
        }

        // GET: TestModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestModel testModel = await db.TestModels.FindAsync(id);
            if (testModel == null)
            {
                return HttpNotFound();
            }
            return View(testModel);
        }

        // POST: TestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,colOne,colTwo,colThree")] TestModel testModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testModel);
        }

        // GET: TestModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestModel testModel = await db.TestModels.FindAsync(id);
            if (testModel == null)
            {
                return HttpNotFound();
            }
            return View(testModel);
        }

        // POST: TestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TestModel testModel = await db.TestModels.FindAsync(id);
            db.TestModels.Remove(testModel);
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
