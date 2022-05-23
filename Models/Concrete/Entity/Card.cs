using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBilirTask2.Models.Concrete.Entity
{
    public class Card
    {
        [Key]
        public int CardID { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public string Describtion { get; set; }
    }
}
