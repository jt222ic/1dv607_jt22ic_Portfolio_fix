using System;
using System.Collections.Generic;
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
        private int SecurityNumber;                                        // registrera och returnera personlighets nummer fält, måste vara privata för objektorientering
        private int MemberId;
        private string Name;
       // private MemberDAL mDAL = new MemberDAL();

         //List<MemberList> MemberList = new List<MemberList>();     tror jag ska skapa listan från en annan klass         kanske vid controller//   skapa en lista av Member klassen ?? är det interface eller bara en lista av en klass
        // List<Boat> list = new List<Boat>();                                // skapar en lista av båt klassen senare


        public List<Boat> BoatList               //hahah glömde att jag hade en båtlista
        {
            get { return Boatlist; }
        }
      

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
