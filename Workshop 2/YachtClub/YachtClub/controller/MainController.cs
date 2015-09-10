using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class MainController
    {
        private model.MemberList m_memberList;
        private view.StartMenuView m_startMenu;
        private view.MemberListView m_memberListView; 
        private view.AddMemberView m_addMemberView;
        private controller.AddMemberController m_addMemberController;

        public MainController()
        {
            m_memberList = new model.MemberList();
            m_startMenu = new view.StartMenuView();
            m_addMemberView = new view.AddMemberView();
            m_memberListView = new view.MemberListView(m_memberList);
            m_addMemberController = new controller.AddMemberController(m_memberList);
        }

        public void DoRun()
        {
            m_startMenu.ClearMenu();
            m_startMenu.ShowStartMenu();
            view.StartMenuView.Choices option = m_startMenu.GetStartMenuOption();
            switch (option)
            {
                case view.StartMenuView.Choices.ListUsersCompact:
                    m_memberListView.ShowMembers(true);
                    break;
                case view.StartMenuView.Choices.ListUsersVerbose:
                    m_memberListView.ShowMembers(false);
                    break;
                case view.StartMenuView.Choices.AddMember:
                    m_addMemberController.DoAddMember();
                    DoRun();
                    break;
                case view.StartMenuView.Choices.Back:
                    break;
                case view.StartMenuView.Choices.ExitApplication:
                    return;
            }
        }
    }
}
