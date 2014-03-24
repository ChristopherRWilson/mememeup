using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemeMeUp.Models;

namespace MemeMeUp.Controllers
{
    public class CaptionController : Controller
    {
        private CaptionContext db = new CaptionContext();
        private MemeContext memeDb = new MemeContext();
        //
        // GET: /Caption/

        public ActionResult Index()
        {
            return View(db.Captions.ToList());
        }

        //
        // GET: /Caption/Details/5

        public ActionResult Details(long id = 0)
        {
            Caption caption = db.Captions.Find(id);
            Meme parentMeme = memeDb.Memes.Find(caption.MemeID);
            if (parentMeme == null)

            if (caption == null)
            {
                return HttpNotFound();
            }
            return View(caption);
        }

        //
        // GET: /Caption/Create

        public ActionResult Create(long id)
        {
            Meme parentMeme = memeDb.Memes.Find(id);
            ViewBag.MemeTitle = parentMeme.Title;
            ViewBag.ParentMemeUrl = parentMeme.MedUrl;
            return View();
        }

        //
        // POST: /Caption/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Caption caption)
        {
            if (ModelState.IsValid)
            {
                db.Captions.Add(caption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caption);
        }

        /*
        //
        // GET: /Caption/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Caption caption = db.Captions.Find(id);
            if (caption == null)
            {
                return HttpNotFound();
            }
            return View(caption);
        }

        //
        // POST: /Caption/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Caption caption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caption);
        }

        //
        // GET: /Caption/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Caption caption = db.Captions.Find(id);
            if (caption == null)
            {
                return HttpNotFound();
            }
            return View(caption);
        }

        //
        // POST: /Caption/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Caption caption = db.Captions.Find(id);
            db.Captions.Remove(caption);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}