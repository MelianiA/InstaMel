using InstaMel.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaMel.Models
{
    public class Seen
    {
        public int ID { get; set; }
        public int storyID { get; set; }
        public string UserID { get; set; }
        public virtual Story Story { get; set; }
        public virtual InstaMelUser User { get; set; }

    }
}
