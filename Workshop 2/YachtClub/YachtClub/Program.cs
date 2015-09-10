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
            controller.MainController mainController = new controller.MainController();
            mainController.DoRun();
        }
    }
}
