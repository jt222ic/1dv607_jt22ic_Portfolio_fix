using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    abstract class MemberListView
    {
        protected model.MemberList m_memberList = new model.MemberList();

        public abstract void ShowMembers();
    }
}
