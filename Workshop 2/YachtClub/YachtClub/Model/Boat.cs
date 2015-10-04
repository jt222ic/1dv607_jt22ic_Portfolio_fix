using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.Model
{
    class Boat
    {

        private double Length;
        
        private int BoatID;
        private BoatCategory Categories;


        public double GetLength
        {
            get { return Length; }
            set { Length = value; }
        }

        public int GetBoatID
        {
            get { return BoatID; }
            set { 
                if(value<= 0)
                {
                    throw new ArgumentException("There's no value in Boat ID");
                }
                
                BoatID = value; }
        }

        public enum BoatCategory
        {
            SailBoat,
            Motorsailer,
            Canoe,
            other

        }

        public BoatCategory GetBoten
        {
            get {return Categories;}


            set { 
                Categories = value;
                }
        }


     
        public Boat(double length,BoatCategory categories, int boatid)
        {   Length = length;
             BoatID = boatid;
             Categories = categories;
        }



        

        

            // enumerable för båt kategorier
            // Kapsla in alla info
        // Boatname,BoatCategory, BoatLength
            // get: set;
            // konstruktor 
            // jonas säger att jag ska kalla till båtklasssen ifrån medlemmen
            // controller för att kalla på objekt skapade, med GetName, GetName ID, Security number) med instans av ny objekt klass

        internal void Add(List<Boat> Boatlist)
        {
            throw new NotImplementedException();
        }
    }
  
}
