using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YachtClub.View
{
    class Console
    {


        public void DisplayInfo()
        {
           System.Console.Clear();
           System.Console.WriteLine("======================================================");
           System.Console.WriteLine("        ****Welcome to YachtClub****                      ");
           System.Console.WriteLine("==========================================");
           System.Console.WriteLine("add a member/boat or remove");
           System.Console.WriteLine("==========================================");
           System.Console.WriteLine("Compact List(name,memberId, number of boats");
           System.Console.WriteLine("Verbose List(name, personal number, memberId  and boatsinfo");
           System.Console.WriteLine("==========================================");
           System.Console.WriteLine("    Save info                          ");


        }
    }
}
