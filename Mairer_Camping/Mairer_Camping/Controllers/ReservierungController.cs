﻿using Mairer_Camping.Models;
using Mairer_Camping.Models.DB;
using Mairer_Camping.Models.DB.db_script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mairer_Camping.Controllers
{
    public class ReservierungController : Controller
    {

        private IRepositoryReservierung rep;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Anfrage()
        {
            return View(new Reservierung());
        }
        [HttpPost]
        public ActionResult Anfrage(Reservierung reservierung)
        {
            if (reservierung == null)
            {
                return RedirectToAction("Anfrage");
            }

            if (!ModelState.IsValid)
            {
                return View(reservierung);
            }
            else
            {
                rep = new RepositoryReservierungDB();

                rep.Open();
                if (rep.Insert(reservierung))
                {
                    return View("Message", new Message("Anfrage", "Ihre Anfrage wurden erfolgreich abgespeichert"));
                }
                else
                {
                    rep.Close();
                    return View("Message", new Message("Anfrage", "Ihre Anfrage konnten nicht gespeichert werden"));
                }

            }
        }

    }
}