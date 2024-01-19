using ServerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BooksTCP
{
    internal class Filters
    {
        private string _title;
        private string _author;
        private string _genre;

        public string Title
        {
            get { return _title; }      
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public static void DataManager(string toParse)
        {
            toParse = toParse.ToLower();
            
            string[] titlesAuthorsGenres = toParse.Split("\n");//splits received data into an array of filters
            List<string[]> tiAuGe = new List<string[]>();
            string[] titles = titlesAuthorsGenres[0].Split(',');
            tiAuGe.Add(titles);
            string[] authors = titlesAuthorsGenres[1].Split(',');
            tiAuGe.Add(authors);
            string[] genres = titlesAuthorsGenres[2].Split(',');
            tiAuGe.Add(genres);




        }





        public Filters(byte[] packetbytes)
        {
            

        }

    }
}
