using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBilirTask2.Models.Concrete.Entity
{
    public class TypeOf
    {
        [Key]
        public int TypeOfID { get; set; }
        public string typeOfCost { get; set; }
    }
}
