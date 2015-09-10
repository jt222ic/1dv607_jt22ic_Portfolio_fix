using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class StartMenuView
    {
        public enum Choices
        {
            ListUsers, 
            AddUser,
            ExitApplication
        };

        public void ShowStartMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------");
            sb.AppendLine("-       WELCOME      -");
            sb.AppendLine("- Boat Club Sys. 1.0 -");
            sb.AppendLine("----------------------");
            sb.AppendLine("-    Press a key     -");
            sb.AppendLine("-  to pick an option -");
            sb.AppendLine("-                    -");
            sb.AppendLine("- 1. Show all users  -");
            sb.AppendLine("- 2. Add a new user  -");
            sb.AppendLine("- 3. Exit            -");
            sb.AppendLine("----------------------");

            Console.WriteLine(sb.ToString());
        }

        public Choices GetStartMenuOption()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            switch (keyPressed.KeyChar)
            {
                case '1':
                    return Choices.ListUsers;
                case '2':
                    return Choices.AddUser;
                case '3':
                    return Choices.ExitApplication;
                
            }
            throw new NotImplementedException();
        }
    }
}
