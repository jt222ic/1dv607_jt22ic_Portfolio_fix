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
        private view.BoatView m_boatView = new view.BoatView();
        private model.MemberList m_memberList;

        public HandleMemberController(model.MemberList memberList)
        {
            m_memberList = memberList;
        }

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
                    try
                    {
                        if (m_memberView.ConfirmDelete())
                        {
                            m_memberList.DeleteMember(member);
                            m_memberView.ShowSuccessDeleteMessage();
                        }
                        else
                        {
                            m_memberView.ShowFailedDeleteMessage();
                        }
                    }
                    catch
                    {
                        m_memberView.ShowFailedDeleteMessage();
                    }
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.RegisterBoat:
                    m_boatView.ShowRegistrationStart();
                    model.BoatCategory category = m_boatView.GetCategoryInput();
                    double length = m_boatView.GetLengthInput();
                    member.RegisterBoat(new model.Boat(length, category));
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
