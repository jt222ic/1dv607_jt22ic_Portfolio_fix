using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class BoatView
    {
        public void ShowRegistrationStart() {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("-       BOAT REGISTRATION      -");
            Console.WriteLine("--------------------------------");
        }

        public double GetLengthInput()
        {
            Console.Write("Length of boat: ");
            return double.Parse(Console.ReadLine());
        }

        public model.BoatCategory GetCategoryInput()
        {
            DisplayBoatTypes();
            Console.Write("Choose category: ");
            int categoryId = int.Parse(Console.ReadLine());
            return (model.BoatCategory)categoryId;
        }

        private void DisplayBoatTypes()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("-     Available boat types     -");
            Console.WriteLine("--------------------------------");
            int index = 0;
            foreach (model.BoatCategory category in Enum.GetValues(typeof(model.BoatCategory)))
            {
                index++;
                Console.WriteLine("{0}:           {1}", index, category);
            }
        }
    }
}
