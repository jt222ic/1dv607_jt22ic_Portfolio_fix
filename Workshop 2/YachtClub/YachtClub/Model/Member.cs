using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.Model
{
    [Serializable]
    class Member
    {

        private int SecurityNumber;                                        // registrera och returnera personlighets nummer fält, måste vara privata för objektorientering
        private int MemberId;
        private string Name;

       //  List<MemberList> MemberList = new List<MemberList>();     tror jag ska skapa listan från en annan klass         kanske vid controller//   skapa en lista av Member klassen ?? är det interface eller bara en lista av en klass
        // List<Boat> list = new List<Boat>();                                // skapar en lista av båt klassen senare

        
        public int GetSecurityNumber
        {
            get {
                return SecurityNumber;
            }

            set
            {
                SecurityNumber = value;                       
            }
        }

        public string GetName
        {

            get{
                return Name;
            }
            set
            {

                if(Name.Length <=0)
                {

                    throw new ArgumentException("Characters need at least more than 1 letter");
                }

                Name = value;
            }

        }

        public int GetMemberID
        {
            get
            {
                return MemberId;
            }
            set
            {
                if(MemberId == null)
                {
                    throw  new ArgumentException("Boat Id doesnt exist");
                }
                else if(value<= 0)
                {
                    throw new ArgumentException("The number require to have 1 or won't get any Id");
                }
                MemberId = value;
            }
        }


        public Member(string name, int memberId, int securityname)
        {
            Name = name;
            MemberId = memberId;
            SecurityNumber = securityname;


            sendToMemberList(this);                // hämta hela objektet 
            
        }

        //public void sendToMemberList(MemberList medlemsinfo)
        //{
        //    medlemsinfo.Addmember(new Member(Name, MemberId, SecurityNumber));
             
        //}

        public void sendToMemberList(Member member)
        {
            MemberList mList = new MemberList();

            mList.Addmember(member);

        }
        
        //Varje gång ett objekt sätts i konstruktorn så kallar vi på sendToMemberList
        //skickar medlemsobjektet (Member member)

        internal void Add(List<Member> memberList)
        {
            throw new NotImplementedException();
        }

        internal void GetMemberID()
        {
            throw new NotImplementedException();
        }
    }
}
