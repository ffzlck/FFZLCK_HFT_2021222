using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Models
{
    public class Drinks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrinkID { get; set; }

        public string DrinkName { get; set; }

        public string DrinkType { get; set; }

        public double AlcoholPercent { get; set; }

        public double DrinkPopularity { get; set; }

        
    }
}
