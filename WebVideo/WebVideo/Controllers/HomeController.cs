using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebVideo.Models;
using System.Threading.Tasks;

namespace WebVideo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index2()
        {
            string result = "You is not registered";
            if (User.Identity.IsAuthenticated)
            {
                result = "Your login is : " + User.Identity.Name;
            }
            return result;
        }
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult UplPhotos()
        {
            return View();
        }
        [Authorize]
        public ActionResult UplVideos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhoto(Photos photos, HttpPostedFileBase upload)
                   
        {
            if (upload != null)
            {
                using (Context db = new Context())
                {

                    // получаем имя файла
                    int count = 1;
                    string format = ".jpg";
                    foreach (var item in db.Photo)
                    {
                        if (item.Name == photos.Name)
                        {
                           
                            
                        }
                    }
                    string fileName1 = photos.Name + format;
                    string fileName = fileName1.Replace(" ", "");
                // сохраняем файл в папку Files в проекте
                 upload.SaveAs(Server.MapPath("~/Files/" + fileName ));
                Photos lol = new Photos();
                
                    foreach (var item in db.Photo)
                    {
                        if (item.Name == photos.Name)
                        {
                           photos.Name= photos.Name + count++ ;
                        }
                    }



                    lol.Name = photos.Name;
                    lol.Link = Convert.ToString("/Files/" +  fileName );
                    db.Photo.Add(lol);
                    db.SaveChanges();
                    
                }
                                          
            }
            
            return RedirectToAction("Index2","Content");
        }

        [HttpPost]
        public ActionResult UploadVideo (Videos videos)
        {
            Videos lol = new Videos();
            using (Context db = new Context())
            {
                lol.Link = videos.Link;
               
                lol.Name = videos.Name;

                db.Video.Add(lol);
                db.SaveChanges();
            }
            return RedirectToAction("Index" );

        }
               
    }

    
}