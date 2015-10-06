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
           System.Console.WriteLine("1.add a Member");                            // info Firstname, Lastname, ID, Boat 
           System.Console.WriteLine("==========================================");
            System.Console.WriteLine("2. Edit");
            System.Console.WriteLine("==========================================");
           System.Console.WriteLine("3.Compact List(name,memberId, number of boats");// view info
           System.Console.WriteLine("4.Verbose List(name, personal number, memberId  and boatsinfo");// view info
           System.Console.WriteLine("==========================================");
           System.Console.WriteLine("0. press to save or quit");
            //REEEDLAJN
            //CONSROSRLCLEARRRUU

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

        //public int GetMember()
        //{
        //    return i;   
        //}


     
        // Compact Lista //
        public void CompactList(IReadOnlyCollection<Member> list)  // spara in listan först
        {

            Console.WriteLine("Members: ");
            foreach (Model.Member member in list)
            {
                System.Console.WriteLine("Name :{0},Security Number :{1}, MemberID :{2}, AmountofBoat : {3}",

                                    member.GetName,
                                    member.GetSecurityNumber,
                                    member.GetMemberID,
                                   member.BoatList.Count);
            }
        }


        // Verbose Listan //
        public void VerboseList(IReadOnlyCollection<Member> list)
        {
            Console.WriteLine("BoatList:");
            int i = 1;   

            foreach(Model.Member member in list)
            {
                 System.Console.WriteLine("name :{0},Security Number :{1}, MemberID :{2},Boats :{3}, Nummer i listan : {4} ", 
                    member.GetName, 
                    member.GetSecurityNumber, 
                    member.GetMemberID, 
                    member.BoatList.Count,
                    i++);
                    // i++;
            

                

            }

        }
        public void ShowBoat(Member member)
        {
            Console.WriteLine("Detaljer");
            foreach (Boat b in member.BoatList)
            {
                System.Console.WriteLine("båt kategori : {0}\n båtlängd :{1}", b.GetCategory, b.GetLength);
            }
        }

           
            
            ////Välja en specifik medlem ur listan med hjälp av siffrorna iu listan
            //int choice = int.Parse(Console.ReadLine());  ok
            //Member chosenMember = list.ElementAt(choice); ok

            ////ändra på vald medlem
            //chosenMember.GetName = "nyanamnethär"; ok ok

            ////Välja en båt
            //Boat chosenBoat = chosenMember.BoatList.ElementAt(choice); ok 
            //chosenBoat.GetLength = 22; 

            ////skriva ut båttyperna till användaren
            ////var BoatTypes = Enum.GetValues(typeof(Boat.type)).Cast<Boat.type>(); ok?
            ////int i = 1;
            ////foreach (Enum Type in BoatTypes)
            ////{
            ////    System.Console.WriteLine(String.Format("{0}: {1}", i, Type)); tillämpar det
            ////    i++;
            ////}

            ////public Boat(int i, double length)
            ////{
            ////    BoatType = (type)i;
            ////    Length = length;
            ////}
            
            
        
        public void ShowMembers(Member member)
        {
           
            System.Console.Clear();
            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("             Selection Screen                                   ");
            System.Console.WriteLine("");
            System.Console.WriteLine("======================================================");

            System.Console.WriteLine("Name: {0}, {1}, {2}", member.GetName, member.GetSecurityNumber, member.GetMemberID);
            System.Console.WriteLine("--------------------------------------------------------------------------------");
            System.Console.WriteLine("Option to choose:\n 1-Rename name\n 2- Delete member \n 3- Change SecurityNumber \n 4- Add Boat \n 5- View the boat \n 0- Exit");
           

            
                             //return int.Parse(System.Console.ReadLine());
        }

      

        

      

        public string OnRegister()
        {
            Console.WriteLine("Inmatning name,MemberID, Security");
            return System.Console.ReadLine();
        }

        public  string OnBoatRegister(Member member)
        {
            System.Console.Clear();
            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("            sparade info?                                 ");
            System.Console.WriteLine("");
            System.Console.WriteLine("======================================================");

            System.Console.WriteLine("Name: {0}, {1}, {2} {3}", member.GetName, member.GetMemberID,member.GetSecurityNumber);
      
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

        //public int i { get; set; }

        internal void ShowMember(Member chosenMember)
        {
            throw new NotImplementedException();
        }
    }
    }





