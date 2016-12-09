using PokWarVel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokWarVel.infra
{
    public static class MesSessions
    {
        /// <summary>
        /// Gets or sets the user in the session
        /// </summary>
        /// <value>
        /// The curent user
        /// </value>
        public static LoginModel Inscrits
        {
            get { return (LoginModel)HttpContext.Current.Session["user"]; }
            set { HttpContext.Current.Session["user"] = value; }
        }
    }
}