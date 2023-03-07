using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Auther
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public DateTime hiredate { get; set; }

        public virtual List<News> News { get; set; }
    }
}
