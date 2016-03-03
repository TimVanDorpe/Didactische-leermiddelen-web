using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.Controllers
{
    public class ReservatieController : Controller
    {
        // GET: Reservatie
        public ActionResult Index(Gebruiker gebruiker)
        {
            
            return View(gebruiker.ReservatieLijst);
        }
    }
}