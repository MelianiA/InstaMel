using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaMel.Models
{
    public class Notifications
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string UserID { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public string Texte { get; set; }

        public string Href { get; set; }

        public bool Ischecked { get; set; }



    }
}
