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




        public static MemberDAL LoadFromFile(List<Member> listanload)                                                    // objekt som ska laddas från 
        {
            FileStream fileStream = null;

            try
            {
                FileStream file = new FileStream(_FILE_PATH, FileMode.Open);

                BinaryFormatter binFormatter = new BinaryFormatter();
                return (MemberDAL)binFormatter.Deserialize(fileStream);

            }

            catch
            {
                return new MemberDAL();
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }

            
        }
    }
}
