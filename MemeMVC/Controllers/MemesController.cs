using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemeMeUp.Models;

using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MemeMeUp.Controllers
{
    public class MemesController : Controller
    {
        private MemeContext db = new MemeContext();

        //
        // GET: /Memes/

        public ActionResult Index()
        {
            return View(db.Memes.ToList());
        }

        //
        // GET: /Memes/Details/5

        public ActionResult Details(long id = 0)
        {
            Meme meme = db.Memes.Find(id);
            if (meme == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemeID = meme.Id;
            ViewBag.FileUrl = meme.MedUrl;
            return View(meme);
        }

        //
        // GET: /Memes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Memes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Meme meme)
        {
            HttpPostedFileBase image;// = new HttpPostedFileBase();
            string fileExtension = "";

            if (Request.Files.Count == 0)
                return View(meme);

            image = Request.Files[0];

            switch (image.ContentType.ToLower())
            {
                case "image/jpeg":
                    fileExtension = ".jpg";
                    break;
                case "image/png":
                    fileExtension = ".png";
                    break;
                default:
                    return View(meme);
            }

            if (ModelState.IsValid)
            {
                string fileType = image.ContentType.ToString();
                string imageFileName = Guid.NewGuid().ToString();
                string imageUrl = string.Format("{0}{1}", imageFileName, fileExtension);
                string imageUrlMed = string.Format("{0}_med{1}", imageFileName, fileExtension);
                string imageUrlThumb = string.Format("{0}_thumb{1}", imageFileName, fileExtension);
                string imagePath = string.Format("{0}/{1}{2}", Server.MapPath("~/Uploads"), imageFileName, fileExtension);
                string imagePathMed = string.Format("{0}/{1}_med{2}", Server.MapPath("~/Uploads"), imageFileName, fileExtension);
                string imagePathTemp = string.Format("{0}/{1}_temp{2}", Server.MapPath("~/Uploads"), imageFileName, fileExtension);
                string imagePathThumb = string.Format("{0}/{1}_thumb{2}", Server.MapPath("~/Uploads"), imageFileName, fileExtension);
                image.SaveAs(imagePathTemp);
                image.InputStream.Close();

                Image tempImage = Image.FromFile(imagePathTemp);

                tempImage = MemeMeUp.Models.Helpers.MemeGraphics.OverlayText(tempImage, "Test!", true);
                tempImage = MemeMeUp.Models.Helpers.MemeGraphics.OverlayText(tempImage, "Something on the bottom", false);
                
                Image finalImage = MemeMeUp.Models.Helpers.MemeGraphics.ScaleImage(tempImage, 600, 600);
                Image medImage = MemeMeUp.Models.Helpers.MemeGraphics.ScaleImage(tempImage, 400, 400);
                Image thumbImage = MemeMeUp.Models.Helpers.MemeGraphics.ScaleImage(tempImage, 175, 175);

                finalImage.Save(imagePath);
                medImage.Save(imagePathMed);
                thumbImage.Save(imagePathThumb);

                tempImage.Dispose();
                medImage.Dispose();
                finalImage.Dispose();
                thumbImage.Dispose();

                System.IO.File.Delete(imagePathTemp);

                meme.AddedDate = DateTime.Now;
                meme.AddedBy = 0;
                meme.FileUrl = imageUrl;
                meme.MedUrl = imageUrlMed;
                meme.ThumbUrl = imageUrlThumb;

                db.Memes.Add(meme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meme);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Creates the folder if needed.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}