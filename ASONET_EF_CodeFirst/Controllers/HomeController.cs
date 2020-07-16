using ASONET_EF_CodeFirst.Models;
using ASONET_EF_CodeFirst.Models.Managers;
using ASONET_EF_CodeFirst.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASONET_EF_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Homepage()
        {
            DatabaseContext db = new DatabaseContext();
            List<Kisiler> kisiler = db.Kisiler.ToList(); //Select*from Kisiler

            HomePageVModel model = new HomePageVModel();
            model.Kisiler = db.Kisiler.ToList();
            model.Adresler = db.Adresler.ToList();
            return View(model);
        }
    }
}