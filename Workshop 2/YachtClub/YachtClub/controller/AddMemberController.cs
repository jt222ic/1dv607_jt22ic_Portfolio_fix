using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class AddMemberController
    {
        private view.AddMemberView m_addMemberView = new view.AddMemberView();
        private model.MemberList m_memberList;

        public AddMemberController(model.MemberList memberList)
        {
            m_memberList = memberList;
        }

        public void DoAddMember()
        {
            try
            {
                string name = m_addMemberView.RetrieveName();
                string socialSecurityNumber = m_addMemberView.RetrieveSocialSecurityNumber();
                int memberId = m_addMemberView.RetrieveMemberId();
                model.Member member = new model.Member(name, socialSecurityNumber, memberId);
                m_memberList.RegisterMember(member);
                m_addMemberView.PrintAddSuccess(name);
            }
            catch
            {
                m_addMemberView.PrintAddFailure();
            }
        }
    }
}
