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
        private view.NavigationView m_navigationView;
        private view.MemberListView m_memberListView; 
        private view.AddMemberView m_addMemberView;
        private controller.MemberController m_memberController;

        public MainController()
        {
            m_memberList = new model.MemberList();
            m_navigationView = new view.NavigationView();
            m_addMemberView = new view.AddMemberView();
            m_memberListView = new view.MemberListView(m_memberList);
            m_memberController = new controller.MemberController(m_memberList);
        }

        public void DoRun()
        {
            m_navigationView.ClearMenu();
            m_navigationView.ShowStartMenu();
            view.NavigationView.Choices option = m_navigationView.GetStartMenuOption();
            switch (option)
            {
                case view.NavigationView.Choices.ListUsersCompact:
                    m_memberListView.ShowMembers(true);
                    m_memberController.DoHandleMember(m_memberListView.GetChosenMember());
                    DoRun();
                    break;
                case view.NavigationView.Choices.ListUsersVerbose:
                    m_memberListView.ShowMembers(false);
                    m_memberController.DoHandleMember(m_memberListView.GetChosenMember());
                    DoRun();
                    break;
                case view.NavigationView.Choices.AddMember:
                    m_memberController.DoAddMember();
                    DoRun();
                    break;
                case view.NavigationView.Choices.ExitApplication:
                    return;
            }
        }
    }
}
