using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class NewDetails
    {
        public int Id { get; set; }
        public string description { get; set; }
        public string photo { get; set; }
        public string pdf { get; set; }

        [ForeignKey("News")]
        public int newId { get; set; }   
        public virtual News News { get; set; }

    }
}
