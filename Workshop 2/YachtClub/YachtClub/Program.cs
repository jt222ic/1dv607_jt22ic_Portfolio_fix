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

            //Model.Member member = new Model.Member("hej", 10, 5000);

            //Model.Member member2 = new Model.Member("pådej", 102, 50020);

            Model.DAL.MemberDAL.Initialize();

            Controller.User j = new Controller.User();
            //View.ConsoleView c = new View.ConsoleView();

            //c.DisplayInfo();
            j.MainMenu();
            //j.ChoicesAlternative();




        }
    }
}
