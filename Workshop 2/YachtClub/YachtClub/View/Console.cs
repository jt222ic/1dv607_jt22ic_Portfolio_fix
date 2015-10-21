using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtClub.Model;


namespace YachtClub.View
{
    class ConsoleView
    {
        public void DisplayInfo()
        {
            System.Console.Clear();
            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("        ****Welcome to YachtClub****                      ");
            System.Console.WriteLine("==========================================");
            System.Console.WriteLine("1.add a Member");
            System.Console.WriteLine("==========================================");
            System.Console.WriteLine("2. Edit");
            System.Console.WriteLine("==========================================");
            System.Console.WriteLine("3.Compact List(name,memberId, number of boats");
            System.Console.WriteLine("4.Verbose List(name, personal number, memberId  and boatsinfo");
            System.Console.WriteLine("==========================================");
            System.Console.WriteLine("0. press to save or quit");

        }

        public int ListEditChoices()
        {
            System.Console.Clear();
            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("1.Edit Member");
            System.Console.WriteLine("0.to return to Main Menu");
            System.Console.WriteLine("======================================================");



            Console.Write("Choice: ");
            return int.Parse(Console.ReadLine());

        }


        // Compact Lista //
        public void CompactList(IReadOnlyCollection<Member> list)  // spara in listan först
        {

            Console.WriteLine("Members: ");
            foreach (Model.Member member in list)
            {
                System.Console.WriteLine("Name :{0},Security Number :{1}, MemberID :{2}, AmountofBoat : {3}",

                member.GetName,
                member.GetSecurityNumber,
                member.MemberID,
                member.BoatList.Count);
            }
        }


        // Verbose Listan //
        public void VerboseList(IReadOnlyCollection<Member> list)
        {
            Console.WriteLine("BoatList:");
            int i = 1;

            foreach (Model.Member member in list)
            {
                System.Console.WriteLine("name :{0},Security Number :{1}, MemberID :{2},Boats :{3}, Nummer i listan : {4} ",
                    member.GetName,

                    member.GetSecurityNumber,
                    member.MemberID,
                    member.BoatList.Count,
                    i++);

            }

        }
        public void ShowBoat(Member member)
        {
            int i = 1;
            Console.WriteLine("Detaljer");
            foreach (Boat boat in member.BoatList)
            {
                System.Console.WriteLine("båt kategori : {0}   båtlängd :{1}   ID : {2}", boat.GetCategory, boat.GetLength, i++);
            }
            System.Console.Write("Chooice one boat ID to remove or update   :");
        }

        public void boatChoices()
        {

            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("1. remove Boat from Medlem");
            System.Console.WriteLine("2. To Update Boat from Medlem");
            System.Console.WriteLine("0.  To Quit");
            System.Console.WriteLine("======================================================");

        }

        public void Boatchanges()
        {
            System.Console.WriteLine("Pick the new Length   :");

        }

        public void ShowMembers(Member member)
        {

            System.Console.Clear();
            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("             Selection Screen                                   ");
            System.Console.WriteLine("");
            System.Console.WriteLine("======================================================");

            System.Console.WriteLine("Name: {0}, {1}, {2}", member.GetName, member.GetSecurityNumber, member.MemberID);
            System.Console.WriteLine("--------------------------------------------------------------------------------");
            System.Console.WriteLine("Option to choose:\n 1-Rename name\n 2- Delete member \n 3- Change SecurityNumber \n 4- Add Boat \n 5- View the boat \n 0- Exit");

        }


        public string OnRegister()
        {
            Console.WriteLine("Inmatning name, Security");
            return System.Console.ReadLine();
        }

        public string OnBoatRegister(Member member)
        {
            System.Console.Clear();
            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("            sparade info?                                 ");
            System.Console.WriteLine("");
            System.Console.WriteLine("======================================================");

            System.Console.WriteLine("Name: {0}, {1}, {2} {3}", member.GetName, member.MemberID, member.GetSecurityNumber);
            return System.Console.ReadLine();
        }

        public void ChooseID()
        {
            Console.Write("Choose Number in List   :");
        }
        public string Rename()
        {
            return System.Console.ReadLine();
        }

        public int ChangeNumber()
        {
            Console.Write("Write your new Security Number   :");
            return int.Parse(System.Console.ReadLine());
        }

        public void ViewBoattype()
        {

            System.Console.WriteLine("Pick a boattype");
            var BoatTypes = Enum.GetValues(typeof(Boat.BoatCategory)).Cast<Boat.BoatCategory>();
            int i = 1;

            foreach (Enum BoatCategory in BoatTypes)
            {
                System.Console.WriteLine("{0}: {1}", i, BoatCategory);
                System.Console.WriteLine("-----------");
                i++;
            }
        }

        public string Boattypeinfo()
        {
            return System.Console.ReadLine();
        }

        public string BoattypeLength()
        {
            System.Console.WriteLine("Pick boatLength");
            return System.Console.ReadLine();
        }




    }
}





