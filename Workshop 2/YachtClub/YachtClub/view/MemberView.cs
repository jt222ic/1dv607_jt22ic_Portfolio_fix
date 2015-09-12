using System;
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
                sb.AppendLine(String.Format("              ID: {0}       ", boat.BoatId));
                sb.AppendLine(String.Format("             Type: {0}        ", boat.Category));
                sb.AppendLine(String.Format("            Length: {0}       ", boat.Length));
            }

            Console.WriteLine(sb.ToString());
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

        public bool ConfirmDelete()
        {
            Console.WriteLine("Are you sure you want to delete this member? Press \"y\" to delete");
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            return pressedKey.KeyChar == 'y';
        }

        public void ShowFailedDeleteMessage()
        {
            Console.WriteLine("Member not deleted");
            Console.ReadKey();
        }

        public void ShowSuccessDeleteMessage()
        {
            Console.WriteLine("Member successfully deleted!");
            Console.ReadKey();
        }

        public void ShowEditConfirmMessage(model.Member memberAdded)
        {
            Console.WriteLine("Member {0} has been updated.", memberAdded.Name);
        }

        public model.Boat GetBoatToDelete()
        {
            Console.Write("ID for boat to delete: ");
            return m_member.GetBoatByID(int.Parse(Console.ReadLine()));
        }

        public void ShowDeleteBoatSuccessMessage(int id)
        {
            Console.WriteLine("Boat {0} was deleted", id);
            Console.ReadKey();
        }

        public void ShowDeleteBoatFailureMessage()
        {
            Console.WriteLine("There is no boat with that ID");
            Console.ReadKey();
        }
    }
}
