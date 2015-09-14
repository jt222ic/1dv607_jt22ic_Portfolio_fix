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
        private view.BaseInputView m_inputView;
        private controller.MemberController m_memberController;

        public MainController()
        {
            m_memberList = new model.MemberList();
            m_navigationView = new view.NavigationView();
            m_inputView = new view.BaseInputView();
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
                    model.Member memberCompact = null;
                    while (true)
                    {
                        int id = m_inputView.GetIntegerFromUser("Select user by ID: ");
                        memberCompact = m_memberList.GetMemberById(id);
                        if (memberCompact != null)
                        {
                            break;
                        }
                        Console.WriteLine("No user with id {0}", id);
                    }
                    m_memberController.DoHandleMember(memberCompact);
                    DoRun();
                    break;
                case view.NavigationView.Choices.ListUsersVerbose:
                    m_memberListView.ShowMembers(false);
                    model.Member memberVerbose = null;
                    while (true)
                    {
                        int id = m_inputView.GetIntegerFromUser("Select user by ID: ");
                        memberVerbose = m_memberList.GetMemberById(id);
                        if (memberVerbose != null)
                        {
                            break;
                        }
                        Console.WriteLine("No user with id {0}", id);
                    }
                    m_memberController.DoHandleMember(memberVerbose);
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
