﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Models
{
    public class Performer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerformerID { get; set; }
        public string PerformerName { get; set; }
        public string PerformerStyle { get; set; }
        public virtual ICollection<Music> Musics { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Clip> Clips { get; set; }

        public Performer()
        {
            
        }
    }
}