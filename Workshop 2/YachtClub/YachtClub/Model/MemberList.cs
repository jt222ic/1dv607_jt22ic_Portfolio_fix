﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// binary formatter
namespace YachtClub.Model             
{
    [Serializable]
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
            // SaveMember();                                                                     //spara in uppdateringen

         }


        public void Addmember(Member AddMember)
         {  
             memberList.Add(AddMember);
             SaveMember(); 
           
                                                                                                    //foreach (Member m in memberList)
                                                                                                        //{
                                                                                                        //    Console.WriteLine(m.GetName);
            }

        //metod som tar emot en (Member member), lägger till member till listan memberList.Add(member);
        //listan har objekt i sig, då skickar vi listan till MemberDAL (memberList)
        //
        public void RemoveMemberList(Member member)              // hämtar hela Member objekt klass för att användas
        {

            memberList.Remove(member);                          // radera av vilken anledning?
                                 
        }

        public void GetMemberID(Member memberID)          
        {
            memberID.GetMemberID();
                                                             // hämtar in Medlems id 
        }

        public void SaveMember()
        {

             memberDal.SaveToFile(memberList);

             List<Member> newList = DAL.MemberDAL.LoadFromFile(memberList);

             foreach (Member m in newList)
             {
                 Console.WriteLine(m.GetName);
             }
           
                    
        }

        //ta bort MemberListan

        //updatera Memberlistan

        // få tag på memberID

        public MemberList()
         {

                     //automatisk genererad konstruktor

         }



        internal void Addmember()
        {
            throw new NotImplementedException();
        }
    }
}