using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class News
    {
        public int id { get; set; }
        public string title { get; set; }
        public string bref { get; set; }
        public DateTime datetime { get; set; }
        
        [ForeignKey("Auther")]
        public int autherId { get; set; }
        public virtual List<NewDetails> NewDetails { get; set; }
        public virtual Auther Auther { get; set; }

    }
}
