using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Models
{
    public class Available
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvailableID { get; set; }

        public int DrinkID { get; set; }
        public int FoodID { get; set; }
        public int PubID { get; set; }

        public virtual ICollection<Drinks> Drinks2 { get; set; }

        public virtual Pub Pub { get; set; }
        public virtual Food Food { get; set; }
        public virtual Drinks Drinks { get; set; }
    }
}
