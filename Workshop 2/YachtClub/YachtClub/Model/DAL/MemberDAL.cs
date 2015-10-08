using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace YachtClub.Model.DAL
{
    [Serializable]
    static class MemberDAL
    {
        private static readonly string _FILE_PATH = "Listan.bin";      //refrens https://www.youtube.com/watch?v=URw86vBWeGE

        private static List<Member> memberList = new List<Member>();
        

        public static void Initialize()
        {
            memberList = LoadFromFile();
        }

        public static void removeMember(int choice)
        {
            memberList.RemoveAt(choice);
          
        }

        public static void SaveToFile()                                                 // referens för användning av Serialized 
        {
            using (FileStream fileStream = new FileStream(_FILE_PATH, FileMode.OpenOrCreate))             // object som ska sparas i fil
            { 
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(fileStream, memberList);
            }
        }


        public static void AddMemberToList(Member member)
        {
            memberList.Add(member);
        }

        public static IReadOnlyCollection<Member> getMemberList()
        {

            return memberList.AsReadOnly();

        }

     
        public static List<Member> LoadFromFile()                                                    // objekt som ska laddas från 
        {
            FileStream fileStream = null;
            List<Member> loadedList = null;

            FileStream file = new FileStream(_FILE_PATH, FileMode.OpenOrCreate, FileAccess.Read);

            BinaryFormatter binFormatter = new BinaryFormatter();
            try
            {
                loadedList = (List<Member>)binFormatter.Deserialize(file);
            }
            catch (Exception e)
            {
                Console.Write("Error occurred while deserializing {0}", _FILE_PATH);
                loadedList = new List<Member>();
            }
            file.Close();
            // fileStream.Close();
            return loadedList;
            
        }
    }
}
