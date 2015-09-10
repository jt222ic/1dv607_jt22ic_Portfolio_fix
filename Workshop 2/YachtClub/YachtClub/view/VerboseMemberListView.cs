using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class VerboseMemberListView : MemberListView
    {
        public override void ShowMembers()
        {
            foreach (model.Member member in m_memberList.Members)
            {
                Console.WriteLine("Name: {0}", member.Name);
                Console.WriteLine("Personal number: {0}", member.SocialSecurityNumber);
                Console.WriteLine("Member ID: {0}", member.MemberId);
                ShowBoats(member.Boats);
            }
        }

        private void ShowBoats(List<model.Boat> boats)
        {
            foreach (model.Boat boat in boats)
            {
                Console.WriteLine("Type: {0}", boat.Category);
                Console.WriteLine("Length: {0}", boat.Length);
            }
        }
    }
}
