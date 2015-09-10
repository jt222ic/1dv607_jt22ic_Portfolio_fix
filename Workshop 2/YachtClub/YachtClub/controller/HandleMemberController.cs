using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class HandleMemberController
    {
        private view.MemberView m_memberView;

        public void DoHandleMember(model.Member member)
        {
            m_memberView = new view.MemberView(member);
            m_memberView.ShowMember();
            view.MemberView.MemberHandleOperation whatDo = m_memberView.GetWhatToDoWithUser();
            switch (whatDo)
            {
                case YachtClub.view.MemberView.MemberHandleOperation.Edit:
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.Delete:
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.RegisterBoat:
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.DeleteBoat:
                    m_memberView.ShowMembersBoats();
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.Back:
                    break;
                default:
                    break;
            }
        }
    }
}
