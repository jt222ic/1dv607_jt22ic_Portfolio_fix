using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// binary formatter
namespace YachtClub.Model             
{
    class MemberList
    {

         private List<Member> memberList = new List<Member>();
         public Model.DAL.MemberDAL memberDal = new DAL.MemberDAL();
         
        // skapa en objekt som ska sparas i Data acess lager


        //updaterar memberlistan

         public void UpdateMemberList(string name, int memberId, int securityname)                // uppdatera information hämtar in ID, namn och security? allstå ska de hamna i Parameter för att tillämpas
         {
             Member TobeAdded = new Member(name, memberId,securityname);                        // instantisera ny objekt 
             TobeAdded.Add(memberList);                                                       // hämta in objekt listan add
             SaveMember();                                                                     //spara in uppdateringen

             
         }
        public void RemoveMemberList(Member member)              // hämtar hela Member objekt klass för att användas
        {

            memberList.Remove(member);                          // radera av vilken anledning?
            SaveMember();                         
        }

        public void GetMemberID(int memberID)          
        {


           // hämtar in Medlems id 
        }

        public void SaveMember()
        {

            memberDal.SaveToFile(memberList);
           
                    
        }

        //ta bort MemberListan

        //updatera Memberlistan

        // få tag på memberID

        public MemberList()
         {

                     

         }




    }
}
