using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PokWarVel.Models
{
    public class InscriptionModel
    {
        #region Prop
        private string _nom;
        private string _prenom;
        private string _login;
        private string _password;
        private string _email; 
        #endregion


        #region Full
        [Required]
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        [Required]
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }
        [Required]
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adresse mail")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        #endregion
        
        public bool Save()
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = @"Data Source=26R2-4\WADSQL;Initial Catalog=PokeWarVelDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            try
            {
                oConn.Open();
                SqlCommand oCmd = new SqlCommand(@"INSERT INTO [dbo].[Inscription] ([Nom], [Prenom], [Login], [Password], [Email])
                                                    VALUES (@Nom, @Prenom, @Login, @Password, @Email)"
                                                    , oConn);
                SqlParameter pNom = new SqlParameter("@Nom", this.Nom);
                SqlParameter pPrenom = new SqlParameter("@Prenom", this.Prenom);
                SqlParameter pLogin = new SqlParameter("@Login", this.Login);
                SqlParameter pPassword = new SqlParameter("@Password", this.Password);
                SqlParameter pEmail = new SqlParameter("@Email", this.Email);

                oCmd.Parameters.Add(pNom);
                oCmd.Parameters.Add(pPrenom);
                oCmd.Parameters.Add(pLogin);
                oCmd.Parameters.Add(pPassword);
                oCmd.Parameters.Add(pEmail);

                oCmd.ExecuteNonQuery();

                oConn.Close();
            }
            catch (Exception ex)
            {
                if(oConn.State == System.Data.ConnectionState.Open)
                {
                    oConn.Close();
                }
                return false;
            }
            return true;
        }
    }
}