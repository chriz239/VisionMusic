using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VisionMusicLibrary.Models
{
    public class PlaylistItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlaylistItemId { get; set; }
        public int Order { get; set; }
        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }

        public PlaylistItem() { }
    }
}
