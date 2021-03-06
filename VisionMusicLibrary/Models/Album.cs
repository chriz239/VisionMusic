﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VisionMusicLibrary.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumID { get; set; }

        public string Label { get; set; }

        public virtual IList<Track> Tracks { get; set; }

        public virtual Artist Artist { get; set; }

        public Album() { }

        public Album(string label) { Label = label; }
    }
}
