using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class MemberView
    {
        private model.Member m_member;

        public MemberView(model.Member member)
        {
            m_member = member;
        }

        public void ShowMember()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--------------------------------");
            sb.AppendLine("-                              -");
            sb.AppendLine(String.Format("- Member #{0}                   -", m_member.MemberId));
            sb.AppendLine("--------------------------------");

            Console.WriteLine(sb.ToString());
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
