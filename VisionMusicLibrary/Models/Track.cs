﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VisionMusicLibrary.Models
{
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackID { get; set; }

        public string Title { get; set; }

        public virtual Album Album { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual Repository Repository { get; set; }

        public string RelativePath { get; set; }

        public string AbsolutePath
        {
            get { return Repository?.Path + RelativePath; }
        }
    }
}
