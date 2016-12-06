using MarvelApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PokWarVel.Models
{
    public class EvalModel
    {
        #region Prop
        private int _idHero;
        private string _typeHero;
        private int _eval;
        private DateTime _date;
        private ResultModel _Hero;
        private string _commentaire;
        #endregion

        #region Full
        public ResultModel Hero
        {
            get { return _Hero; }
            set { _Hero = value; }
        }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        [Required]
        [Display(Name = "Evaluation")]
        public int Eval
        {
            get { return _eval; }
            set { _eval = value; }
        }
        public string Commentaire
        {
            get { return _commentaire; }
            set { _commentaire = value; }
        }


        //[Required]
        //[Display(Name = "Type de Hero")]
        //public string TypeHero
        //{
        //    get { return _typeHero; }
        //    set { _typeHero = value; }
        //}

        //public int IdHero
        //{
        //    get { return _idHero; }
        //    set { _idHero = value; }
        //} 
        #endregion

        public bool Save()
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = @"Data Source=26R2-4\WADSQL;Initial Catalog=PokeWarVelDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            try
            {
                oConn.Open();
                SqlCommand oCmd = new SqlCommand (@"INSERT INTO [dbo].[Eval] ([Eval], [TypeHeros], [Date], [idHero], [Commentaire])
                                                VALUES (@Eval, @TypeHero, @Date, @idHeros, @Commentaire)"
                                                                    , oConn);
                SqlParameter pEval = new SqlParameter("@Eval", this.Eval);
                SqlParameter pTypeHeros = new SqlParameter("@TypeHero", this.Hero.TypeElement.ToString());
                SqlParameter pDate = new SqlParameter("@Date", DateTime.Now);
                SqlParameter pIdHeros = new SqlParameter("@idHeros", this.Hero.ID);
                SqlParameter pComm = new SqlParameter("@Commentaire", this.Commentaire);

                oCmd.Parameters.Add(pEval);
                oCmd.Parameters.Add(pTypeHeros);
                oCmd.Parameters.Add(pDate);
                oCmd.Parameters.Add(pIdHeros);
                oCmd.Parameters.Add(pComm);

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