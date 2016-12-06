using MarvelApi;
using MarvelApi.Model;
using PokWarVel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokWarVel.Controllers
{
    public class HeroController : Controller
    {
        // GET: Hero
        public ActionResult Index(long id)
        {
            MarvelRequester r = new MarvelRequester();
            //rechercher le hero via ton id
            EvalModel ev = new EvalModel();
            Characters info = r.GetCharacter(id);
            ev.Hero = new ResultModel() { ID = info.id, Avatar = info.ptiAvatar, TypeElement = ResultModel.Etype.Marvel};
            return View(ev);
        }

        [HttpPost]
        public ActionResult Index(EvalModel em)
        {
            MarvelRequester r = new MarvelRequester();
            //rechercher le hero via ton id

            List<Characters> info = r.GetCharacters();
            em.Hero = new ResultModel()
            {
                ID = info[0].id,
                Avatar = info[0].ptiAvatar,
                TypeElement = ResultModel.Etype.Marvel
            };
            
            if(em.Save())
            {
                return RedirectToAction("Thanks");
            }

            else
            {
                ViewBag.Erreur = "Erreur Hero";
                return View(em);
            }
        }

        public ActionResult Thanks()
        {
            return View();
        }
    }
}