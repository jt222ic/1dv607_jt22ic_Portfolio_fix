using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub
{
    class Program
    {
        static void Main(string[] args)
        {

            //Model.dependencies member = new Model.dependencies("hej", 10, 5000);

            //Model.dependencies member2 = new Model.dependencies("pådej", 102, 50020);

            Model.DAL.MemberDAL.Initialize();

            Controller.User j = new Controller.User();
            //View.ConsoleView c = new View.ConsoleView();

            //c.DisplayInfo();
            j.MainMenu();
            //j.ChoicesAlternative();




        }
    }
}
