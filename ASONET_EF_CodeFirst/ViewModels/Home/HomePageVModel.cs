using ASONET_EF_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASONET_EF_CodeFirst.ViewModels.Home
{
    public class HomePageVModel
    {
        public List<Kisiler> Kisiler { get; set; }
        public List<Adresler>Adresler { get; set; }
    }
}