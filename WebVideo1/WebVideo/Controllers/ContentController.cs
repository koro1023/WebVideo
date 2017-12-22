using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebVideo.Models;

namespace WebVideo.Controllers
{
    public class ContentController : Controller
    {
        const int pageSize = 4;
        const int photopageSize = 20;
        // GET: Content
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Index4()
        {
            using (Context db = new Context())
            {
                var videocontent = db.Video.OrderBy(m => m.ID).Take(6);

                return View(videocontent.ToList());
            }
        }
        public ActionResult Index2()
        {
            Context db = new Context();
            
                db.Photo.Load();
                return View(db.Photo.Local.ToBindingList());
        }

        public ActionResult Index3(int? id)
        {
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Index3", GetItemsPage(page));
            }
            return View(GetItemsPage(page));

        }
        
        private List<Videos> GetItemsPage(int page = 1)
        {
            using (Context db = new Context())
            {                
                var itemsToSkip = page * pageSize;

                return db.Video.OrderBy(t => t.ID).Skip(itemsToSkip).
                    Take(pageSize).ToList();
            }
        }
        /*   Controllers for photo   */
        public ActionResult Index5(int? id)
        {
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Index5", GetItemPage(page));
            }
            return View(GetItemPage(page));

        }

        private List<Photos> GetItemPage(int page = 1)
        {
            using (Context db = new Context())
            {
                var itemsToSkip = page * photopageSize;

                return db.Photo.OrderBy(t => t.ID).Skip(itemsToSkip).
                    Take(photopageSize).ToList();
            }
        }






        [HttpGet]
        public FileResult GetPhotos(int ID)
        {
            Photos x = new Photos();
            using (Context db = new Context())
            {
                x = db.Photo.FirstOrDefault(g => g.ID == ID);
                if (x != null)
                {
                    string Path = x.Link;
                    byte[] mas = System.IO.File.ReadAllBytes(Path);
                    string Name = x.Name;




                    return File(mas, Name);
                }
                return (null);

            }

        }
    }
}