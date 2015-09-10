using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace YachtClub.model
{
    class Member
    {
        private string _socialSecurityNumber;
        private int _memberId;
        private List<Boat> m_registeredBoats = new List<Boat>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MemberId
        {
            get
            {
                return _memberId;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Model.Member.MemberId needs to be 1 or higher");
                }
                _memberId = value;
            }
        }
        public string SocialSecurityNumber
        {
            get
            {
                return _socialSecurityNumber;
            }
            private set
            {
                if (Regex.IsMatch(value, @"^\d{2,4}-?\d{4}-?\d{4}"))
                {
                    throw new ArgumentException("Model.Member.SocialSecurityNubmer is not valid format");
                }
                _socialSecurityNumber = value;
            }
        }

        public Member(string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public void RegisterBoats(Boat boat)
        {
            if (m_registeredBoats.Contains(boat)) 
            {
                throw new ArgumentException("Boat is already registered");
            }
            else
            {
                m_registeredBoats.Add(boat);
            }
        }
    }
}
