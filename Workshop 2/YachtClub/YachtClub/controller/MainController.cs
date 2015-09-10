using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class MainController
    {
        private view.StartMenuView m_startMenu = new view.StartMenuView();
        private view.CompactMemberListView m_compactMemberListView = new view.CompactMemberListView();
        private view.VerboseMemberListView m_verboseMemberListView = new view.VerboseMemberListView();
        protected view.AddMemberView m_addMemberView = new view.AddMemberView();
        protected model.MemberList m_memberList = new model.MemberList();
        private controller.AddMemberController m_addMemberController = new controller.AddMemberController();

        public void DoRun()
        {
            m_startMenu.ShowStartMenu();
            view.StartMenuView.Choices option = m_startMenu.GetStartMenuOption();
            switch (option)
            {
                case view.StartMenuView.Choices.ListUsersCompact:
                    m_compactMemberListView.ShowMembers();
                    break;
                case view.StartMenuView.Choices.ListUsersVerbose:
                    m_verboseMemberListView.ShowMembers();
                    break;
                case view.StartMenuView.Choices.AddMember:
                    m_addMemberController.DoAddMember();
                    break;
                case view.StartMenuView.Choices.ExitApplication:
                    return;
            }
        }
    }
}
