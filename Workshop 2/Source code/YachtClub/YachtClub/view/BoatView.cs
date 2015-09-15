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

        public void DisplayBoatTypes()
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

        /**
         * @return model.BoatCategory
         * Keeps prompting for valid integer representing a model.BoatCategory value
         */
        public model.BoatCategory GetCategoryInput()
        {
            Console.Write("Input boat category: ");
            int categoryId = 0;
            model.BoatCategory? category = null;
            do
            {
                if (int.TryParse(Console.ReadLine(), out categoryId))
                {
                    if (categoryId < Enum.GetNames(typeof(model.BoatCategory)).Length + 1 && categoryId > 0)
                    {
                        // -1 because of zero based enums
                        category = (model.BoatCategory)categoryId - 1;
                        break;
                    }
                    Console.WriteLine("That's not a valid boat category.");
                }
                else
                {
                    Console.WriteLine("That's not an integer..");
                }
            } while (true);
            return (model.BoatCategory)category;
        }
    }
}
