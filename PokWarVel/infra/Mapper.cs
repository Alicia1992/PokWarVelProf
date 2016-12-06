using MarvelApi.Model;
using PokWarVel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokWarVel.infra
{
    public static class Mapper
    {
        /// <summary>
        /// Create a neuw ResultModel from a Marvel Character
        /// </summary>
        /// <param name="c">The character to use</param>
        /// <returns>A ResultModel with data from Marvel Character</returns>
        public static ResultModel FromMarvelToLocal(Characters c)
        {
            ResultModel rm = new Models.ResultModel();
            rm.Name = c.name;
            rm.ID = c.id;
            rm.Avatar = c.ptiAvatar;
            rm.TypeElement = ResultModel.Etype.Marvel;
            if(c.ComicLists!=null)
            {
                rm.Badge = c.ComicLists.ComicSummaries.Count;
            }

            return rm;
        }
    }
}
