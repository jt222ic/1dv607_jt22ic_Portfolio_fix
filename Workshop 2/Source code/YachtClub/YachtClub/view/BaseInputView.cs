using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class BaseInputView
    {
        public int GetIntegerFromUser(string prompt)
        {
            Console.Write(prompt);
            int input = 0;
            do
            {
                string textInput = Console.ReadLine();
                if (int.TryParse(textInput, out input))
                {
                    break;
                }
                Console.Write("That's not a valid number! Try again.");
            } while (true);
            return input;
        }

        public double GetDoubleFromUser(string prompt)
        {
            Console.WriteLine(prompt);
            double input = 0;
            do
            {
                string textInput = Console.ReadLine();
                if (double.TryParse(textInput, out input))
                {
                    break;
                }
                Console.Write("That's not a valid number! Try again.");
            } while (true);
            return input;
        }

        public string GetStringFromUser(string prompt)
        {
            Console.Write(prompt);
            string input = "";
            do
            {
                input = Console.ReadLine().Trim();
                if (!String.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                Console.CursorTop--;
            } while (true);
            return input;
        }

        public void PrintAddSuccess(string name)
        {
            Console.WriteLine("User \"{0}\" successfully added to the registry. Press any key to continue.", name);
            Console.ReadKey();
        }

        public void PrintAddFailure()
        {
            Console.WriteLine("User registration failed. Press any key to continue.");
            Console.ReadKey();
        }

        public void ShowFailedUserPickMessage()
        {
            Console.WriteLine("There is no user with that ID. Press any key to continue.");
            Console.ReadKey(true);
        }
    }
}
