using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtClub.Model.DAL;

namespace YachtClub.Model
{
    [Serializable]
    class Member
    {

        List<Boat> Boatlist = new List<Boat>();
        private int SecurityNumber;                                        
        private string MemberId;
        private string Name;
       
                                      


        public List<Boat> BoatList               
        {
            get { return Boatlist; }
        }

        public int GetSecurityNumber
        {
            get
            {
                return SecurityNumber;
            }

            set
            {
                SecurityNumber = value;
            }
        }

        public string GetName
        {

            get
            {
                return Name;
            }
            set
            {

                if (Name.Length <= 0)
                {

                    throw new ArgumentException("Characters need at least more than 1 letter");
                }

                Name = value;
            }
        }

        public string MemberID
        {
            get
            {
                return MemberId;
            }
            set
            {
                MemberId = value;

            }
        }


        public Member(string name, int securityname)
        {
            Name = name;

            SecurityNumber = securityname;
            MemberId = Guid.NewGuid().ToString();
            sendToMemberList(this);        // hämta ut hela objekt       
        }

        public void sendToBoatList(Boat boat)
        {
            Boatlist.Add(boat);
        }
        public void RemoveBoatList(int boat)
        {
            Boatlist.RemoveAt(boat);
        }

        public void sendToMemberList(Member member)
        {
            MemberDAL.AddMemberToList(member);
        }
    }
}
