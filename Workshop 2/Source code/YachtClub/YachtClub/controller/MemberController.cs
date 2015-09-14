using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class MemberController
    {
        private model.MemberList m_memberList;
        private view.NavigationView m_navigationView;
        private view.MemberListView m_memberListView;
        private view.BaseInputView m_inputView;
        private view.MemberView m_memberView;
        private view.BoatView m_boatView;

        public MemberController()
        {
            m_memberList = new model.MemberList();
            m_navigationView = new view.NavigationView();
            m_inputView = new view.BaseInputView();
            m_boatView = new view.BoatView(); ;
            m_memberListView = new view.MemberListView(m_memberList);
        }

        public void DoHandleMember(model.Member member)
        {
            m_memberView = new view.MemberView(member);
            m_memberView.ShowMember();
            view.MemberView.MemberHandleOperation whatDo = m_memberView.GetWhatToDoWithUser();
            switch (whatDo)
            {
                case YachtClub.view.MemberView.MemberHandleOperation.Edit:
                    string name = m_inputView.GetStringFromUser("Input name: ");
                    string socialSecurityNumber = m_inputView.GetStringFromUser("Input social security number: ");
                    member.Name = name;
                    member.SocialSecurityNumber = socialSecurityNumber;
                    m_memberView.ShowEditConfirmMessage(member);
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
                    m_boatView.DisplayBoatTypes();
                    model.BoatCategory category = m_boatView.GetCategoryInput();
                    double length = m_inputView.GetDoubleFromUser("Input boat length: ");
                    int id = m_inputView.GetIntegerFromUser("Input boat ID: ");
                    member.RegisterBoat(new model.Boat(length, category, id));
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.DeleteBoat:
                    m_memberView.ShowMembersBoats();
                    while (true)
                    {
                        try
                        {
                            model.Boat boatToDelete = m_memberView.GetBoatToDelete();
                            member.DeleteBoat(boatToDelete);
                            m_memberView.ShowDeleteBoatSuccessMessage(boatToDelete.BoatId);
                            break;
                        }
                        catch
                        {
                            m_memberView.ShowDeleteBoatFailureMessage();
                        }   
                    }
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.Back:
                    break;
                default:
                    break;
            }
        }

        public void DoAddMember()
        {
            try
            {
                string name = m_inputView.GetStringFromUser("Input name: ");
                string socialSecurityNumber = m_inputView.GetStringFromUser("Input social security number: ");
                int memberId = m_inputView.GetIntegerFromUser("Input user ID: ");
                model.Member member = new model.Member(name, socialSecurityNumber, memberId);
                m_memberList.RegisterMember(member);
                m_inputView.PrintAddSuccess(name);
            }
            catch
            {
                Console.WriteLine("Hello");
                m_inputView.PrintAddFailure();
            }
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
                    DoHandleMember(memberCompact);
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
                    DoHandleMember(memberVerbose);
                    DoRun();
                    break;
                case view.NavigationView.Choices.AddMember:
                    DoAddMember();
                    DoRun();
                    break;
                case view.NavigationView.Choices.ExitApplication:
                    return;
            }
        }
    }
}
