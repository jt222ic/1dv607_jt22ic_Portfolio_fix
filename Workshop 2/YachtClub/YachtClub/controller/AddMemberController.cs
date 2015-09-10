using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class AddMemberController
    {
        private model.MemberList m_memberList = new model.MemberList();
        private view.AddMemberView m_addMemberView = new view.AddMemberView();

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
