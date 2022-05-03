using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Models
{
    public class Music
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusicID { get; set; }

        public string MusicName { get; set; }
        public string Style { get; set; }
        public int PerfromerID { get; set; }
        public int AlbumID { get; set; }
        [NotMapped]
        public virtual Performer Performer { get; set; }
    }
}
