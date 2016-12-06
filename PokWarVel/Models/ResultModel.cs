using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokWarVel.Models
{
   public class ResultModel
    {
        /// <summary>
        /// Enum to define the type of the result
        /// </summary>
        public enum Etype
        {
            Marvel,
            Starwars,
            Pokemon
        }
        private long _id;
        private string _name;
        private string _avatar;
        private Etype _typeElement;
        private int _badge;

        public Etype TypeElement
        {
            get { return _typeElement; }
            set { _typeElement = value; }
        }

        /// <summary>
        /// Gets or sets the avatar.
        /// </summary>
        /// <value>
        /// The avatar.
        /// </value>
        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the badge.
        /// </summary>
        /// <value>
        /// The badge.
        /// </value>
        public int Badge
        {
            get
            {
                return _badge;
            }

            set
            {
                _badge = value;
            }
        }
    }
}
