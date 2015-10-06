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
                
             
                c.DisplayInfo();
                int Choice;
                string choices = System.Console.ReadLine();

                try
                {
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
                                                         //IReadOnlyCollection<Member> list = Mlist.GetList();
                            c.CompactList(MemberDAL.getMemberList());
                            
                            break;

                        case 4:
                            c.VerboseList(MemberDAL.getMemberList());
                            
                            break;
                    }

                }

                catch (System.FormatException e)
                {
                    throw new ArgumentException(e.Message);
                }

            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public void EditMenu(ConsoleView view)
        {
            

            do{
                
            int choice = view.ListEditChoices();

                try {
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
                        //case 3:

                        //    Boat boat = new Boat(300,(Boat.BoatCategory)1,3);  // skickade in parameter båt till en medlems klass
                            
                        //    break;
                    }
                }
                catch (System.FormatException e)
                {
                    throw new ArgumentException(e.Message);
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
            test.ShowMembers(member);
            
            int menuChoicce = int.Parse(Console.ReadLine());

            
                switch (menuChoicce)
                {
                    case 0:
                        return;

                    case 1:
                       member.GetName = test.Rename();        // change name
                        break;

                    case 2:

                        MemberDAL.removeMember(choice);
                        break;

                    case 3:
                        member.GetSecurityNumber = test.ChangeNumber();
                        break;

                    case 4:
                        test.ViewBoattype();
                        int Boatchoice = int.Parse(test.Boattypeinfo());

                        double BoatLength = double.Parse(test.BoattypeLength());// kan inte använda console write line eftersom det är void
                        Boat FullBoat = new Boat(Boatchoice,BoatLength);
                        member.sendToBoatList(FullBoat);
                        break;
                    case 5:
                        test.ShowBoat(member);
                        
                        break;

                    default: break;

                    

                }
            }
            

            


           
        }

    }


