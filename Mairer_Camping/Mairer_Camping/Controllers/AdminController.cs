using Mairer_Camping.Models.DB;
using Mairer_Camping.Models;
using Mairer_Camping.Models.DB.db_script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mairer_Camping.Controllers
{
    public class AdminController : Controller
    {
        IRepositoryReservierung rep;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Reservierungsanfragen()
        {
            return View();
        }
        public ActionResult RegistrierteBenutzer()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {

            rep = new RepositoryReservierungDB();
            rep.Open();

            if (rep.Delete(id))
            {
                rep.Close();
                return View("Message", new Message("Anfrage löschen","Benutzer wurde erfolgreich gelöscht!"));
            }
            else
            {
                rep.Close();
                return View("Message", new Message("Anfrage löschen", "Benutzer konnte nicht gelöscht werden!"));
            }


        }

        public ActionResult WurdeBearbeitet(int id)
        {
            rep = new RepositoryReservierungDB();
            rep.Open();

            if (rep.WurdeBearbeitet(id))
            {
                rep.Close();
                return View("Message", new Message("Anfrage löschen", "Benutzer wurde erfolgreich gelöscht!"));
            }
            else
            {
                rep.Close();
                return View("Message", new Message("Anfrage löschen", "Benutzer konnte nicht gelöscht werden!"));
            }
        }



    }
}