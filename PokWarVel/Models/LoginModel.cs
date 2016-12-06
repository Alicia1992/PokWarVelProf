using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PokWarVel.Models
{
    public class LoginModel
    {
        private string Login;
        private string _password;

        [Required]
        public string _login
        {
            get { return Login; }
            set { Login = value; }
        }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        

        
    }
}