using System.Web.Mvc;

namespace PokWarVel.Areas.ZoneMembre
{
    public class ZoneMembreAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ZoneMembre";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ZoneMembre_default",
                "ZoneMembre/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}