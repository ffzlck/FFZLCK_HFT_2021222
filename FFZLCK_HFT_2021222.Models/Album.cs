using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public int AlbumPopularity { get; set; }
        [JsonIgnore]
        public virtual ICollection<Music> Musics { get; set; }
        public int PerformerID { get; set; }
        public virtual Performer Performer { get; private set; }
    }
}
