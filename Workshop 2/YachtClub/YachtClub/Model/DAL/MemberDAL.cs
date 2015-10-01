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
    class MemberDAL
    {
        private static readonly string _FILE_PATH = "Listan.DAT";      //refrens https://www.youtube.com/watch?v=URw86vBWeGE
        public int MemberID { get; set; }
        public string Name { get; set; }
        public int SecurityNumber { get; set; }





        public void SaveToFile(List<Member> listan)                                                 // referens för användning av Serialized 
        {
            using (FileStream fileStream = new FileStream(_FILE_PATH, FileMode.OpenOrCreate))             // object som ska sparas i fil
            { 
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(fileStream,listan);
            }
        }




        public static List<Member> LoadFromFile(List<Member> listanload)                                                    // objekt som ska laddas från 
        {
            FileStream fileStream = null;
            List<Member> loadedList;

            try
            {
                FileStream file = new FileStream(_FILE_PATH, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);

                BinaryFormatter binFormatter = new BinaryFormatter();
                loadedList = (List<Member>)binFormatter.Deserialize(file);
                file.Close();
                return loadedList;

            }

            catch
            {
                  //return new MemberDAL();
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }

            return null;

            
        }
    }
}
