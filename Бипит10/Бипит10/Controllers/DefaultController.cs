using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Бипит10.Controllers
{
    public class DefaultController : Controller
    {
        BIPIT3Entities basa = new BIPIT3Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FIO()
        {
            IEnumerable<FIO> fio = basa.FIO;
            ViewBag.FIO = fio;
            return View("FIO");
        }

        public ActionResult Avto()
        {
            IEnumerable<Avto> avto = basa.Avto;
            ViewBag.Avto = avto;
            return View("Avto");
        }

        public ActionResult Arenda()
        {
            IEnumerable<Arenda> arenda = basa.Arenda;
            ViewBag.Arenda = arenda;
            return View("Arenda");
        }

        [HttpGet]
        public ActionResult AddFIO()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFIO(FIO s)
        {
            basa.FIO.Add(s);
            basa.SaveChanges();
            return RedirectToAction("FIO");
        }

        [HttpGet]
        public ActionResult AddAvto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAvto(Avto s)
        {
            basa.Avto.Add(s);
            basa.SaveChanges();
            return RedirectToAction("Avto");
        }

        [HttpPost]
        public ActionResult AddArenda(Arenda s)
        {
            basa.Arenda.Add(s);
            basa.SaveChanges();
            return RedirectToAction("Arenda");
        }
        [HttpGet]
        public ActionResult AddArenda()
        {
            SelectList FIO = new SelectList(basa.FIO, "Id", "FIO1");
            ViewBag.FIO = FIO;
            SelectList Avto = new SelectList(basa.Avto, "Id", "Model");
            ViewBag.Avto = Avto;
            return View();
        }

        public ActionResult DeleteFIO(int id)
        {
            FIO s = new FIO { Id = id };
            basa.Entry(s).State = EntityState.Deleted;
            basa.SaveChanges();
            return RedirectToAction("FIO");
        }

        public ActionResult DeleteAvto(int id)
        {
            Avto s = new Avto { Id = id };
            basa.Entry(s).State = EntityState.Deleted;
            basa.SaveChanges();
            return RedirectToAction("Avto");
        }

        public ActionResult DeleteArenda(int id)
        {
            Arenda s = new Arenda { Id = id };
            basa.Entry(s).State = EntityState.Deleted;
            basa.SaveChanges();
            return RedirectToAction("Arenda");
        }

        [HttpGet]
        public ActionResult EditFIO(int? id)
        {
            if (id == null)
                return HttpNotFound();
            FIO s = basa.FIO.Find(id);
            if (s != null)
                return View(s);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditFIO(FIO s)
        {
            basa.Entry(s).State = EntityState.Modified;
            basa.SaveChanges();
            return RedirectToAction("FIO");
        }

        [HttpGet]
        public ActionResult EditAvto(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Avto s = basa.Avto.Find(id);
            if (s != null)
                return View(s);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditAvto(Avto s)
        {
            basa.Entry(s).State = EntityState.Modified;
            basa.SaveChanges();
            return RedirectToAction("Avto");
        }

        [HttpGet]
        public ActionResult EditArenda(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Arenda app = basa.Arenda.Find(id);
            if (app != null)
            {
                SelectList FIO = new SelectList(basa.FIO, "Id", "FIO1");
                ViewBag.FIO = FIO;
                SelectList Avto = new SelectList(basa.Avto, "Id", "Model");
                ViewBag.Avto = Avto;
                return View(app);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditArenda(Arenda s)
        {
            basa.Entry(s).State = EntityState.Modified;
            basa.SaveChanges();
            return RedirectToAction("Arenda");
        }

    }
}