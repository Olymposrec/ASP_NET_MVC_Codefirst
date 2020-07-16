using ASONET_EF_CodeFirst.Models;
using ASONET_EF_CodeFirst.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASONET_EF_CodeFirst.Controllers
{
    public class KisiController : Controller
    {
        // GET: Kisi
        public ActionResult Yeni()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Kisiler kisi)
        {
            DatabaseContext db = new DatabaseContext();
            db.Kisiler.Add(kisi);
            int sonuc = db.SaveChanges();

            if(sonuc>0)
            {
                ViewBag.Result = "Veri Eklendi!";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Veri Eklenemedi!";
                ViewBag.Status = "danger";
            }
                


            return View();
        }
        public ActionResult Duzenle(int? kisiid)
        {
            Kisiler kisi = null;
            if(kisiid!=null)
            {
                DatabaseContext db = new DatabaseContext();
                kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
            }
            return View(kisi);

        }
        [HttpPost]
        public ActionResult Duzenle(Kisiler model, int? kisiid)
        {
            DatabaseContext db = new DatabaseContext();
            Kisiler kisi= db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
            if(kisi!=null)
            {
                kisi.Ad = model.Ad;
                kisi.Soyad = model.Soyad;
                kisi.Yas = model.Yas;
                kisi.Mail = model.Mail;
                int sonuc =db.SaveChanges();
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
            return View(kisi);

        }
        [HttpGet]
        public ActionResult Sil(int? kisiid)
        {
            Kisiler kisi = null;
            if(kisiid!=null)
            {
                DatabaseContext db = new DatabaseContext();
                kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();

            }
            return View(kisi);
        }
        [HttpPost,ActionName("Sil")]
        public ActionResult SilV(int? kisiid)
        {
            
            if (kisiid != null)
            {
                DatabaseContext db = new DatabaseContext();
                Kisiler kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
                db.Kisiler.Remove(kisi);
                db.SaveChanges();

            }
            return RedirectToAction("Homepage","Home");
        }
    }
}