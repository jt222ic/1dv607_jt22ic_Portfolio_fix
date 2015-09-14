using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class NavigationView
    {
        public enum Choices
        {
            ListUsersCompact,
            ListUsersVerbose,
            AddMember,
            ExitApplication
        };

        public void ShowStartMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--------------------------------");
            sb.AppendLine("-           WELCOME            -");
            sb.AppendLine("-     Boat Club Sys. 1.0       -");
            sb.AppendLine("--------------------------------");
            sb.AppendLine("-         Press a key          -");
            sb.AppendLine("-      to pick an option       -");
            sb.AppendLine("-                              -");
            sb.AppendLine("-     1. Show users in a       -");
            sb.AppendLine("-         compact view         -");
            sb.AppendLine("-       2. Show all info       -");
            sb.AppendLine("-          about users         -");
            sb.AppendLine("-       3. Add a new user      -");
            sb.AppendLine("-           4. Exit            -");
            sb.AppendLine("--------------------------------");

            Console.WriteLine(sb.ToString());
        }
        
        /**
         * @return view.NavigationView.Choices - enum representing chosen start menu operation
         * Key presses outside 1, 2, 3 and 4 are ignored
         */
        public Choices GetStartMenuOption()
        {
            // The @param true to ReadKey supresses printing of the pressed key
            do
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                switch (keyPressed.KeyChar)
                {
                    case '1':
                        return Choices.ListUsersCompact;
                    case '2':
                        return Choices.ListUsersVerbose;
                    case '3':
                        return Choices.AddMember;
                    case '4':
                        return Choices.ExitApplication;

                }
            } while (true);
        }

        public void ClearMenu()
        {
            Console.Clear();
        }
    }
}
