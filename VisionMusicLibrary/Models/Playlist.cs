using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VisionMusicLibrary.Models
{
    public class Playlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public virtual IList<PlaylistItem> Items { get; set; }
    }
}
