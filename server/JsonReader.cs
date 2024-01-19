using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BooksTCP
{
    internal class JsonReader
    {
        private string path;
        private List<Books> books = new List<Books>();
        public JsonReader(string path)
        {
            this.path = path;
        }

        public List<Books> listCreator() 
        {
            string jsonText = File.ReadAllText(path);
            JArray array = JArray.Parse(jsonText);
            List<Books> list = new List<Books>();
            foreach (JObject obj in array.Children<JObject>())
            {
                string ti = (string)obj.GetValue("title");
                string au = (string)obj.GetValue("author");
                string ge = (string)obj.GetValue("genre");
                
                Books b = new Books(ti, au, ge);
                list.Add(b);
            }

            return list;
        }




    }
}
