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
            Console.Write(prompt);
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

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey(true);
        }

        public bool Confirm(string prompt)
        {
            Console.WriteLine(prompt);
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            return pressedKey.KeyChar == 'y';
        }
    }
}
