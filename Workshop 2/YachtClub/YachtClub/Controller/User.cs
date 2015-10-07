using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YachtClub.View;
using YachtClub.Model.DAL;
using YachtClub.Model;

namespace YachtClub.Controller
{
    class User
    {
        private Member member;

        public void MainMenu()
        {
            View.ConsoleView c = new View.ConsoleView();
            do
            {
                try
                {
                c.DisplayInfo();
                int Choice;
                string choices = System.Console.ReadLine();

              
                    Choice = int.Parse(choices);

                    switch (Choice)
                    {
                        case 0:
                            MemberDAL.SaveToFile();
                            return;

                        case 1:
                            Console.Clear();
                            member = new Member(c.OnRegister(), int.Parse(c.OnRegister()), int.Parse(c.OnRegister()));   
                            break;

                        case 2:
                            EditMenu(c);
                            break;

                        case 3:
                                                         
                            c.CompactList(MemberDAL.getMemberList());
                            
                            break;

                        case 4:
                            c.VerboseList(MemberDAL.getMemberList());
                            
                            break;
                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine("nåt gick fel");
                    
                }

            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public void EditMenu(ConsoleView view)
        {
            

            do{
                try
               { 
            int choice = view.ListEditChoices();

               
                    IReadOnlyCollection<Member> m_list = MemberDAL.getMemberList();
                    switch(choice){

                        case 0:
                            return;

                        case 1: 
                            view.VerboseList(m_list);
                            view.ChooseID();
                            selectMember(m_list);
                            
                            break;

                        default: break;
                      
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("nåt gick fel");
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        public void selectMember(IReadOnlyCollection<Member> list)             // argument Listan
        {
            ConsoleView test = new ConsoleView();
                         // show menyn
            
            int choice = int.Parse(Console.ReadLine());
            if(choice == 0)
            { 
                return;
            }
            choice--;
            Member member = list.ElementAt(choice);
            test.ShowMembers(member);                        // skickar till show member visning av medlemmar
           int menuChoicce = int.Parse(Console.ReadLine());

                switch (menuChoicce)                    // menualternativ för Medlemmen
                {
                    case 0:
                        return;

                    case 1:
                       member.GetName = test.Rename();        // change name
                        break;

                    case 2:

                        MemberDAL.removeMember(choice);           // tas bort medlemmen
                        break;

                    case 3:
                        member.GetSecurityNumber = test.ChangeNumber();   // ändra personlighets nummer
                        break;

                    case 4:
                        test.ViewBoattype();
                        int Boatchoice = int.Parse(test.Boattypeinfo());            // användning av inmatning av boatchoice

                        double BoatLength = double.Parse(test.BoattypeLength());      //inmatning båtlängd // kan inte använda console write line eftersom det är void
                        Boat FullBoat = new Boat(Boatchoice,BoatLength);      // instans av ny objekt( med intagen längd av båtlängd och båtkategorier 
                        member.sendToBoatList(FullBoat);
                        break;
                    case 5:
                        test.ShowBoat(member);
                        selectBoat(member);
                          break;

                    default: break;

                }
            }

        public void selectBoat(Member member)
        {
            Boat boaten;
            IReadOnlyCollection<Member> newlist = MemberDAL.getMemberList(); ;
            ConsoleView test2 = new ConsoleView();
            //test2.bild();
            int choices = int.Parse(Console.ReadLine());
            if (choices == 0)
            {
                return;
            }
            choices--;
             
            test2.boatChoices();
            int boatchoice = int.Parse(Console.ReadLine());
            boaten = member.BoatList.ElementAt(choices);
            switch(boatchoice)
            {
                case 1:
                    member.RemoveBoatList(choices); 
                    break;

                case 2:
                    test2.ViewBoattype();
                    choices = int.Parse(Console.ReadLine()); 
                test2.Boatchanges();
                    double newLength = double.Parse(Console.ReadLine());         
                    //Boat FullBoat = new Boat(choices, newLength);
                    boaten.GetLength = newLength;                                  // egenskap == nya värdet
                    boaten.GetCategory = (Model.Boat.BoatCategory)choices;    // kan inte skicka in i egenskaper eftersom de inte har parameteer
                                                                          // hämtade objektet från båten
                                                                              // ändra värden via parse
                    break;

            }

        }
            

        }

    }


