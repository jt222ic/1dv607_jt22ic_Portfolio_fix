﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class MemberController
    {
        private view.MemberView m_memberView;
        private view.BoatView m_boatView = new view.BoatView();
        private model.MemberList m_memberList;
        private view.AddMemberView m_addMemberView = new view.AddMemberView();

        public MemberController(model.MemberList memberList)
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
                    string name = m_addMemberView.RetrieveName();
                    string socialSecurityNumber = m_addMemberView.RetrieveSocialSecurityNumber();
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
                    model.BoatCategory category = m_boatView.GetCategoryInput();
                    double length = m_boatView.GetLengthInput();
                    int id = m_boatView.GetIdInput();
                    member.RegisterBoat(new model.Boat(length, category, id));
                    break;
                case YachtClub.view.MemberView.MemberHandleOperation.DeleteBoat:
                    m_memberView.ShowMembersBoats();
                    try
                    {
                        model.Boat boatToDelete = m_memberView.GetBoatToDelete();
                        member.DeleteBoat(boatToDelete);
                        m_memberView.ShowDeleteBoatSuccessMessage(boatToDelete.BoatId);
                    }
                    catch 
                    {
                        m_memberView.ShowDeleteBoatFailureMessage();
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
