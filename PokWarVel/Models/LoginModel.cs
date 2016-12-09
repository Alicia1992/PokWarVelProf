using PokWarVel.infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PokWarVel.Models
{
    public class LoginModel
    {
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool Verif()
        {
            bool isVerif = false;

            SqlConnection oConn = new SqlConnection();

            oConn.ConnectionString = @"Data Source=26R2-4\WADSQL;Initial Catalog=PokeWarVelDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            try
            {
                oConn.Open();

                SqlCommand oCmd = new SqlCommand(@"SELECT * from Inscription 
                                                    WHERE [Login] = @login 
                                                    AND [Password] = @password", oConn);
                SqlParameter pLogin = new SqlParameter("@login", this.Login);
                SqlParameter pPassword = new SqlParameter("@password", this.Password);

                oCmd.Parameters.Add(pLogin);
                oCmd.Parameters.Add(pPassword);

                SqlDataReader oDr = oCmd.ExecuteReader();

                if(oDr.Read())
                {
                    MesSessions.Inscrits = this;
                    isVerif = true;
                }

                oDr.Close();
                oConn.Close();
            }

            catch (Exception ex)
            {
                isVerif = false;
            }
            return isVerif;
        }
        
    }
}