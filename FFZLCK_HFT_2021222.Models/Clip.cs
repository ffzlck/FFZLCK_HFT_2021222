using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Models
{
    public  class Clip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClipID { get; set; }
        public string DirectorName { get; set; }
        public int Income { get; set; }
        public int MusicID { get; set; }
        public virtual Performer Performer { get; set; }
    }
}
