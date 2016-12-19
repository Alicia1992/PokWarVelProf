using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PokWarVel.Models
{
    public class VoteModel
    {
        public string Eval { get; set; }
        
        public static List<VoteModel> Vote()
        {
            List<VoteModel> AffVote = new List<VoteModel>();
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = @"Data Source=26R2-4\WADSQL;Initial Catalog=PokeWarVelDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            try
            {
                oConn.Open();
                SqlCommand oCmd = new SqlCommand(@"SELECT [Eval] FROM [Eval]", oConn);
                SqlDataReader oDr = oCmd.ExecuteReader();

                while(oDr.Read())
                {
                    AffVote.Add(new VoteModel() { Eval = oDr["Eval"].ToString() });
                }


                oConn.Close();
            }
            catch (Exception ex)
            {
            
            }
            return AffVote;
        }
    }
}