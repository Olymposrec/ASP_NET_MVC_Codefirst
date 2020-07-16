using ASONET_EF_CodeFirst.Models;
using ASONET_EF_CodeFirst.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASONET_EF_CodeFirst.Controllers
{
    public class AdresController : Controller
    {
        // GET: Adres
        public ActionResult Yeni()
        {
            DatabaseContext db = new DatabaseContext();

            List<SelectListItem> kisilerList =
                (from kisi in db.Kisiler.ToList()
                 select new SelectListItem()
                 {
                     Text = kisi.Ad + " " + kisi.Soyad,
                     Value = kisi.ID.ToString()
                 }
                 ).ToList();

            //List < Kisiler > kisiler= db.Kisiler.ToList();

            //List<SelectListItem> kisilerList = new List<SelectListItem>();

            //foreach (Kisiler kisi in kisiler)
            //{
            //    SelectListItem item = new SelectListItem();
            //    item.Text = kisi.Ad + " " + kisi.Soyad;
            //    item.Value = kisi.ID.ToString();

            //    kisilerList.Add(item);
            //}
            TempData["kisiler"] = kisilerList;
            ViewBag.kisiler = kisilerList;
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Adresler adres)
        {
            DatabaseContext db = new DatabaseContext();
            Kisiler kisi = db.Kisiler.Where(x => x.ID == adres.kisi.ID).FirstOrDefault();
            if(kisi!=null)
            {
                adres.kisi = kisi;
                db.Adresler.Add(adres);
                int sonuc= db.SaveChanges();
                if (sonuc > 0)
                {
                    ViewBag.Result = "Veri Eklendi!";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Veri Eklenemedi!";
                    ViewBag.Status = "danger";
                }
            }
            ViewBag.kisiler = TempData["kisiler"];
            return View();
        }
        public ActionResult Duzenle(int? adresid)
        {
            Adresler adres = null;
            if(adresid!=null)
            {
                DatabaseContext db = new DatabaseContext();

                List<SelectListItem> kisilerList =
                    (from kisi in db.Kisiler.ToList()
                     select new SelectListItem()
                     {
                         Text = kisi.Ad + " " + kisi.Soyad,
                         Value = kisi.ID.ToString()
                     }
                     ).ToList();

                TempData["kisiler"] = kisilerList;
                ViewBag.kisiler = kisilerList;

                 adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();
            }
            
            return View(adres);
        }

        [HttpPost]
        public ActionResult Duzenle(Adresler model,int? adresid)
        {
            DatabaseContext db = new DatabaseContext();
            Kisiler kisi = db.Kisiler.Where(x => x.ID == model.kisi.ID).FirstOrDefault();
            Adresler adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();
            if (kisi != null)
            {
                adres.kisi = kisi;
                adres.AdresTanim = model.AdresTanim;
                int sonuc = db.SaveChanges();
                if (sonuc > 0)
                {
                    ViewBag.Result = "Veri Güncellendi!";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Veri Güncellenemedi!";
                    ViewBag.Status = "danger";
                }
            }
            ViewBag.kisiler = TempData["kisiler"];
            return View();
        }

        public ActionResult Sil(int? adresid)
        {
            Adresler adres = null;
            if (adresid != null)
            {
                DatabaseContext db = new DatabaseContext();
                adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();

            }
            return View(adres);
        }
        [HttpPost, ActionName("Sil")]
        public ActionResult SilV(int? adresid)
        {

            if (adresid != null)
            {
                DatabaseContext db = new DatabaseContext();
                Adresler adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();
                db.Adresler.Remove(adres);
                db.SaveChanges();

            }
            return RedirectToAction("Homepage", "Home");
        }
    }
}