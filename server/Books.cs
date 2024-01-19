using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BooksTCP
{
    internal class Books
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string author;
        public string Author
        {
            get { return author; }
            set { title = value; }
        }
        private string genre;
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public Books(string title,string author, string genre)
        {
            this.title = title;
            this.author = author;
            this.genre = genre;
        }


        public void printBookData()
        {
            Console.WriteLine(title);
            Console.WriteLine(author);
            Console.WriteLine(genre);
        }

        public static string DataManager(string toParse, List<Books> listOfBooks)
        {
            toParse = toParse.ToLower();

            string[] titlesAuthorsGenres = toParse.Split('\n');//splits received data into an array of filters
            List<string[]> tiAuGe = new List<string[]>();
            string[] titles = titlesAuthorsGenres[0].Split(',');
            tiAuGe.Add(titles);
            if (!titlesAuthorsGenres[1].Equals('\n'))
            {
                string[] authors = titlesAuthorsGenres[1].Split(',');
                tiAuGe.Add(authors);
            }
            if (titlesAuthorsGenres[2] != null)
            {
                string[] genres = titlesAuthorsGenres[2].Split(',');
                tiAuGe.Add(genres);
            }
            List<Books> listOfSearched = new List<Books>();

            foreach (Books book in listOfBooks)
            {
                foreach (string[] s in tiAuGe)
                {

                    if (s.Any(s => book.Title.ToLower().Contains(s.ToLower())) && !(listOfSearched.Contains(book)))
                    {
                        listOfSearched.Add(book);
                    }
                    if (s.Any(s => book.Author.ToLower().Contains(s.ToLower())) && !(listOfSearched.Contains(book)))
                    {
                        listOfSearched.Add(book);
                    }
                    if (s.Any(s => book.Genre.ToLower().Contains(s.ToLower())) && !(listOfSearched.Contains(book)))
                    {
                        listOfSearched.Add(book);
                    }
                }

            }

            string json = JsonConvert.SerializeObject(listOfSearched);
            return json;


        }

        public static void printListOfSearched(List<Books> books)
        {
            foreach (Books book in books)
            {
                book.printBookData();
            }
        }




    }
}
