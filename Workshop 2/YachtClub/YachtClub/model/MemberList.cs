using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class MemberList
    {
        private List<Member> m_members = new List<Member>();

        public List<Member> Members
        {
            get
            {
                return m_members;
            }
        }

        public void RegisterMember(Member member)
        {
            if (m_members.Contains(member))
            {
                throw new ArgumentException("Member is already registered");
            }
            m_members.Add(member);
        }

        public void DeleteMember(Member member)
        {
            if (!m_members.Contains(member))
            {
                throw new ArgumentException("That member doesn't exist");
            }
            m_members.Remove(member);
        }
    }
}
