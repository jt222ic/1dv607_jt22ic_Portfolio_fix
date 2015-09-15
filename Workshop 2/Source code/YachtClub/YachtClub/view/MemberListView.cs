using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class MemberListView
    {
        private model.MemberList m_memberList;
        private view.BaseInputView m_input;

        public MemberListView(model.MemberList memberList)
        {
            m_memberList = memberList;
            m_input = new view.BaseInputView();
        }
        
        /**
         * @return model.Member if m_memberList is populated
         * If it's not, @return null
         */
        public model.Member GetUserChosenFromList(bool compressList)
        {
            ShowMembers(compressList);
            if (m_memberList.IsEmpty())
            {
                Console.WriteLine("-            No users are registered           -");
                Console.WriteLine("-            Press any key to return           -");
                Console.WriteLine("------------------------------------------------");
                Console.ReadKey(true);
                return null;
            }
            else
            {
                model.Member member = null;
                while (true)
                {
                    int id = m_input.GetIntegerFromUser("Select user by ID: ");
                    member = m_memberList.GetMemberById(id);
                    if (member != null)
                    {
                        break;
                    }
                    Console.WriteLine("No user with id {0}", id);
                }
                return member;
            }
        }

        public void ShowMembers(bool compressedList)
        {
            Console.Clear();
            if (compressedList)
            {
                Console.WriteLine("MemberID\t\tName\tAmount of boats");
            }
            else
            {
                Console.WriteLine("MemberID\t\tName\tPersonal number");
            }
            Console.WriteLine("------------------------------------------------");

            foreach (model.Member member in m_memberList.Members)
            {
                Console.Write("{0}", member.MemberId);
                Console.Write("\t\t\t{0}", member.Name);
                if (compressedList)
                {
                    Console.Write("\t\t{0}", member.GetAmountOfBoats());
                }
                else
                {
                    Console.Write("\t{0}\n", member.SocialSecurityNumber);
                    Console.WriteLine();
                    ShowBoats(member.Boats);
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------");
        }

        private void ShowBoats(List<model.Boat> boats)
        {
            Console.WriteLine("Registered boats:");
            foreach (model.Boat boat in boats)
            {
                Console.WriteLine("Type: {0}", boat.Category);
                Console.WriteLine("Length: {0}\n", boat.Length);
            }
        }
    }
}
