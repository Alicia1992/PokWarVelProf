using MarvelApi;
using MarvelApi.Model;
using PokWarVel.infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokWarVel.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// The default action to HomeController.
        /// </summary>
        /// <param name="page">The page to display ( for Marvel Pagination)</param>
        /// <returns>The view Views/Home/Index.cshtml</returns>
        public ActionResult Index(string page="")
        {
           
            //Si aucune page n'est transmise c'est que nous sommes sur la 
            //première page donc nous ne devons pas "passer" de
            //héros avant l'affichage
            if(page=="")
            {
                //Variable de session mise à zéro
                SessionUtil.offsetGal = 0;
            }
            else
            {
                //Si je demande de retourner en arrière et que le nombre 
                // de héros à "passer" est suppérieur à 12,
                //je peux donc diminuier le nombre de héros à passer de 12
                //cela permet un affichage de 12 par 12
                if(page=="prev" && SessionUtil.offsetGal>12)
                {
                    SessionUtil.offsetGal -= 12;
                }
                
                //Si je demande d'avancer, je prend les 12 héros suivants
                //Remarque : idéalement, on devrait connaitre le nombre total 
                // ce qui permettrait de ne pas dépasser le nombre de héros lors
                // de l'interrogation du service
                if(page=="next")
                {
                    SessionUtil.offsetGal += 12;
                }
            }

            //Création de l'objet requester permettant de dialoguer avec le service Marvel
            MarvelRequester r = new MarvelRequester();
            //Appel de la fonction permettant de récupére les héros en lui
            // transmettant le offest qui définit le début de récupération
            // 12 => les 12 premier
            // 24 ==> les 12 suivants...

            List<Characters> info = r.GetCharacters(limit: 12, offset: SessionUtil.offsetGal);



            //Retour de la vue en lui transmettant le model à utiliser
            // Comme la _Fiche accepte un model ResultModel, je
            // doit transformer l'objet Character en ResultModel avant de renvoyer vers la vue
            // je le fais via la méthode statique FromMarvelToLocal
            return View(info.Select(s=> Mapper.FromMarvelToLocal(s)).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}