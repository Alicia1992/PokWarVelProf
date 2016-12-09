using PokWarVel.infra;
using PokWarVel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokWarVel.Controllers
{
    public class InscriptionController : Controller
    {
        // GET: Inscription
        public ActionResult Index()
        {
                     

            return View();
        }

        [HttpPost]
        public ActionResult Index(InscriptionModel im)
        {
            if(im.Save())
            {
                return RedirectToAction("Mercii");
            }
            else
            {
                ViewBag.ErrInsc = "Erreur lors de l'inscription";
                return View(im);
            }
        }

        public ActionResult Mercii()
        {
            return View();
        }


        public ActionResult LogMe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogMe (LoginModel lm)
        {
            if(lm.Verif())
            {
                string login = MesSessions.Inscrits.Login;
                MesSessions.Inscrits = lm;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErreurLogin = "Login ou mot de passe invalide";
                return View("LogMe");
            }
        }
    }
}