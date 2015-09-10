using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class CompactMemberListView : MemberListView
    {
        public override void ShowMembers()
        {
            foreach (model.Member member in m_memberList.Members)
            {
                Console.WriteLine("Name: {0}", member.Name);
                Console.WriteLine("Member ID: {0}", member.MemberId);
                Console.WriteLine("Number of boats: {0}", member.GetAmountOfBoats());
            }
        }
    }
}
