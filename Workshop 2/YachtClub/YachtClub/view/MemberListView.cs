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
            if (compressedList)
            {
                Console.WriteLine("Name\t\tMemberID\tAmount of boats");
            }
            else
            {
                Console.WriteLine("Name\t\tMemberID\tPersonal number");
            }
            Console.WriteLine("------------------------------------------------");
            foreach (model.Member member in m_memberList.Members)
            {
                Console.Write("{0}", member.Name);
                Console.Write("\t\t{0}", member.MemberId);
                if (compressedList)
                {
                    Console.Write("\t\t{0}", member.GetAmountOfBoats());
                }
                else
                {
                    Console.Write("\t\t{0}\n", member.SocialSecurityNumber);
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
                Console.WriteLine("Length: {0}", boat.Length);
            }
        }
    }
}
