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

        public MemberListView(model.MemberList memberList)
        {
            m_memberList = memberList;
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

            if (m_memberList.IsEmpty())
            {
            Console.WriteLine("-            No users are registered           -");
            }

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

        public model.Member GetChosenMember()
        {
            model.Member selectedMember = null;

            while (true)
            {
                Console.Write("Select a user (by ID): ");
                var id = int.Parse(Console.ReadLine());
                selectedMember = m_memberList.GetMemberById(id);
                if (selectedMember != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("No user with that ID..");
                }
            }

            return selectedMember;     
        }

        public void ShowFailedUserPickMessage()
        {
            Console.WriteLine("There is no user with that ID. Press any key to continue.");
            Console.ReadKey(true);
        }
    }
}
