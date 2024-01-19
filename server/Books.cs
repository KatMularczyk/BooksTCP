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
    }
}
