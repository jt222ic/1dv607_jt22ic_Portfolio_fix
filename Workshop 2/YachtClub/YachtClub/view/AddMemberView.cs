using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class AddMemberView
    {
        public string RetrieveName()
        {
           Console.Write("Input name: ");
           return Console.ReadLine();
        }

        public string RetrieveSocialSecurityNumber()
        {
            Console.Write("Input social security number: ");
            return Console.ReadLine();
        }

        public int RetrieveMemberId()
        {
            Console.Write("Input member ID: ");
            return int.Parse(Console.ReadLine());
        }

        public void PrintAddSuccess(string name)
        {
            Console.WriteLine("User \"{0}\" successfully added to the registry.", name);
        }

        internal void PrintAddFailure()
        {
            Console.WriteLine("User registration failed.");
        }
    }
}
