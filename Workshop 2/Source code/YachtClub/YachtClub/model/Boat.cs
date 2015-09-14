using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class Boat
    {
        private double _length;

        public BoatCategory Category { get; set; }
        public int BoatId { get; set; }
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (value <= 0 || value >= 1000)
                {
                    throw new ArgumentException("Model.Boat.Length needs to be between 0 and 1000");
                }
                _length = value;
            }
        }

        public Boat(double length, BoatCategory category, int id)
        {
            Category = category;
            Length = length;
            BoatId = id;
        }
    }
}
