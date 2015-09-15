using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class MemberController
    {
        private model.MemberList m_list;
        private view.NavigationView m_nav;
        private view.MemberListView m_listView;
        private view.BaseInputView m_input;
        private view.MemberView m_memberView;
        private view.BoatView m_boatView;

        public MemberController()
        {
            m_list = new model.MemberList();
            m_nav = new view.NavigationView();
            m_input = new view.BaseInputView();
            m_boatView = new view.BoatView(); ;
            m_listView = new view.MemberListView(m_list);
        }

        public void DoRun()
        {
            m_nav.ClearMenu();
            m_nav.ShowStartMenu();
            view.NavigationView.Choices option = m_nav.GetStartMenuOption();

            switch (option)
            {
                case view.NavigationView.Choices.ListUsersCompact:
                    DoListMembers(true);
                    DoRun();
                    break;
                case view.NavigationView.Choices.ListUsersVerbose:
                    DoListMembers(false);
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

        private void DoHandleMember(model.Member member)
        {
            m_memberView = new view.MemberView(member);
            m_memberView.ShowMember();
            view.MemberView.MemberHandleOperation whatDo = m_memberView.GetWhatToDoWithUser();

            switch (whatDo)
            {
                case YachtClub.view.MemberView.MemberHandleOperation.Edit:
                    DoEditMember(member);
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.Delete:
                    DoDeleteMember(member);
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.RegisterBoat:
                    DoRegisterBoat(member);
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.DeleteBoat:
                    DoDeleteBoat(member);
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.Back:
                    break;
                default:
                    break;
            }
        }

        private void DoDeleteMember(model.Member memberToDelete)
        {
            try
            {
                if (m_input.Confirm("Are you sure you want to delete this member? Press \"y\" to delete"))
                {
                    m_list.DeleteMember(memberToDelete);
                    m_input.PrintMessage("Member successfully deleted!");
                }
                else
                {
                    m_input.PrintMessage("User not deleted");
                }
            }
            catch
            {
                m_input.PrintMessage("Deleting user failed. Try again later.");
            }
        }

        private void DoDeleteBoat(model.Member memberWhoseBoatToDelete)
        {
            m_memberView.ShowMembersBoats();
            while (true)
            {
                try
                {
                    model.Boat boatToDelete = m_memberView.GetBoatToDelete();
                    memberWhoseBoatToDelete.DeleteBoat(boatToDelete);
                    m_input.PrintMessage("Boat deleted");
                    break;
                }
                catch
                {
                    m_input.PrintMessage("There is no boat with that ID");
                }
            }
        }

        private void DoRegisterBoat(model.Member memberToRegisterBoat)
        {
            m_boatView.ShowRegistrationStart();
            m_boatView.DisplayBoatTypes();
            model.BoatCategory category = m_boatView.GetCategoryInput();
            double length = m_input.GetDoubleFromUser("Input boat length: ");
            int id = m_input.GetIntegerFromUser("Input boat ID: ");
            memberToRegisterBoat.RegisterBoat(new model.Boat(length, category, id));
        }

        private void DoAddMember()
        {
            try
            {
                string name = m_input.GetStringFromUser("Input name: ");
                string socialSecurityNumber = m_input.GetStringFromUser("Input social security number: ");
                int memberId = m_input.GetIntegerFromUser("Input user ID: ");
                model.Member member = new model.Member(name, socialSecurityNumber, memberId);
                m_list.RegisterMember(member);
                m_input.PrintMessage("User successfully added to the registry. Press any key to continue.");
            }
            catch
            {
                m_input.PrintMessage("User registration failed. Press any key to continue.");
            }
        }

        private void DoEditMember(model.Member memberToEdit)
        {
            string name = m_input.GetStringFromUser("Input name: ");
            string socialSecurityNumber = m_input.GetStringFromUser("Input social security number: ");
            memberToEdit.Name = name;
            memberToEdit.SocialSecurityNumber = socialSecurityNumber;
            m_input.PrintMessage("Member has been updated.");
        }

        private void DoListMembers(bool compressedList)
        {
            try
            {
                model.Member memberChosenFromList = m_listView.GetUserChosenFromList(compressedList);
                DoHandleMember(memberChosenFromList);
            }
            catch
            {
                DoRun();
            }
        }
    }
}
