﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class MemberView
    { 
        public enum MemberHandleOperation {
            Edit,
            Delete,
            RegisterBoat, 
            DeleteBoat,
            Back
        };

        private model.Member m_member;

        public MemberView(model.Member member)
        {
            m_member = member;
        }

        public void ShowMember()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--------------------------------");
            sb.AppendLine(String.Format("          Member #{0}         ", m_member.MemberId));
            sb.AppendLine(String.Format("          Name: {0}           ", m_member.Name));
            sb.AppendLine(String.Format(" Personal Number: {0}  ", m_member.SocialSecurityNumber));
            sb.AppendLine("--------------------------------");
            sb.AppendLine("-           OPTIONS            -");
            sb.AppendLine("-           1. Edit            -");
            sb.AppendLine("-          2. Delete           -");
            sb.AppendLine("-       3. Register boat       -");
            sb.AppendLine("-        4. Delete boat        -");
            sb.AppendLine("-           5. Back            -");
            sb.AppendLine("--------------------------------");

            Console.WriteLine(sb.ToString());
        }

        public void ShowMembersBoats()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--------------------------------");
            sb.AppendLine("-       Registered boats       -");
            sb.AppendLine("--------------------------------");

            foreach (model.Boat boat in m_member.Boats)
            {
                sb.AppendLine(String.Format("             Type: {0}        ", boat.Category));
                sb.AppendLine(String.Format("            Length: {0}       ", boat.Length));
            }

            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }

        public MemberHandleOperation GetWhatToDoWithUser()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            switch (keyPressed.KeyChar)
            {
                case '1':
                    return MemberHandleOperation.Edit;
                case '2':
                    return MemberHandleOperation.Delete;
                case '3':
                    return MemberHandleOperation.RegisterBoat;
                case '4':
                    return MemberHandleOperation.DeleteBoat;
                case '5':
                    return MemberHandleOperation.Back;
                default:
                    return MemberHandleOperation.Back;
            }
        }
    }
}
