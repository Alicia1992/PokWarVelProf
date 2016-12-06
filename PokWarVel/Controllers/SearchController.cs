using MarvelApi;
using MarvelApi.Model;
using PokWarVel.infra;
using PokWarVel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokWarVel.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Home");
        }


        public ActionResult Results(string Search="", string page="")
        {
            int Current =0;
            
            if (page == "" || page=="-1")
            {
                ViewBag.Next = 1;
                ViewBag.Prev = -1;
                Current = 0;
            }
            else
            {
                Current = int.Parse(page);
                if (Current > 1)
                {
                    
                    ViewBag.Prev = Current- 1;
                }

                ViewBag.Next = Current + 1;
            }

            MarvelRequester r = new MarvelRequester();
            List<Characters> info = r.SearchCharacters(limit: 10, offset: Current*10, SearchString:Search);


            ViewBag.searchword = Search;
            if (info!=null && info.Count > 0)
            {
                return View(info.Select(i => Mapper.FromMarvelToLocal(i)).ToList());
            }
            else
            {
                return View(new List<ResultModel>());
            }
        }
    }
}