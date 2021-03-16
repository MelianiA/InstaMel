using InstaMel.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaMel.Models
{
    public class Like
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int PostID { get; set; }

        public virtual InstaMelUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}
