using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class HandleMemberController 
    {
        private model.MemberList m_memberList;

        public HandleMemberController(model.MemberList memberList)
        {
            m_memberList = memberList;
        }

        public void DoHandleMember(model.Member member)
        {
            throw new NotImplementedException();
        }
    }
}
