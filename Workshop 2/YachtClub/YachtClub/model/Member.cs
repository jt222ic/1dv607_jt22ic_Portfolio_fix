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
        private string _name;
        private List<Boat> m_registeredBoats = new List<Boat>();

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException("Model.Member.Name needs to be 1 character or longer");
                }
                _name = value;

            }
        }
        public int MemberId
        {
            get
            {
                return _memberId;
            }
            set
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
            set
            {
                if (!Regex.IsMatch(value, @"^\d{2,4}-?\d{4}-?\d{4}"))
                {
                    throw new ArgumentException("Model.Member.SocialSecurityNubmer is not valid format");
                }
                _socialSecurityNumber = value;
            }
        }

        public List<Boat> Boats
        {
            get
            {
                return m_registeredBoats;
            }
        }

        public Member(string name, string socialSecurityNumber, int memberId)
        {
            Name = name;
            SocialSecurityNumber = socialSecurityNumber;
            MemberId = memberId;
        }

        public void RegisterBoat(Boat boat)
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

        public void DeleteBoat(Boat boat)
        {
            if (!m_registeredBoats.Contains(boat))
            {
                throw new ArgumentException("That boat doesn't exist");
            }
            else
            {
                m_registeredBoats.Remove(boat);
            }
        }

        public int GetAmountOfBoats()
        {
            return m_registeredBoats.Count;
        }

        public Boat GetBoatByID(int id)
        {
            foreach (Boat boat in Boats)
            {
                if (boat.BoatId == id)
                {
                    return boat;
                }
            }

            return null;
        }
    }
}
