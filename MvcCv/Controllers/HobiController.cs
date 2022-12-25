using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobiler=repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim p)
        {
            //TblHobilerim t=new TblHobilerim();
            var h = repo.Find(x => x.ID == 1);
            h.Aciklama1 = p.Aciklama1;
            h.Aciklama2 = p.Aciklama2;
            repo.TUpdate(h);
            return RedirectToAction("Index");
        }
    }
}