using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.Model
{
    [Serializable]
    class Boat
    {

        private double _Length;
        private BoatCategory _Boattype;




        public double GetLength
        {
            get
            {
                return _Length;
            }

            set
            {
                if (_Length <= 0 || _Length >= 500)
                {
                    throw new ArgumentException("unnessary length of a boat");
                }
                _Length = value;
            }
        }

        public enum BoatCategory
        {
            SailBoat,
            Motorsailer,
            Canoe,
            other

        }
        public BoatCategory GetCategory
        {
            get
            {
                return _Boattype;
            }
            set
            {
                if (BoatCategory.IsDefined(typeof(BoatCategory), value))
                {
                    _Boattype = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
        }


        public Boat(int i, double length)
        {
            _Length = length;
            _Boattype = (BoatCategory)i;

        }

        // enumerable för båt kategorier
        // Kapsla in alla info
        // Boatname,BoatCategory, BoatLength
        // get: set;
        // konstruktor 
        // jonas säger att jag ska kalla till båtklasssen ifrån medlemmen
        // controller för att kalla på objekt skapade, med GetName, GetName ID, Security number) med instans av ny objekt klass


    }

}
