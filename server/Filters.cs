using System;
using System.Collections.Generic;
using System.Linq;
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

        public Filters(byte[] packetbytes)
        {

        }

    }
}
