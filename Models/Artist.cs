using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LieTunesReview.Models
{
    [Table("Artist")]
    public partial class Artist
    {
        public Artist()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Song> Songs { get; set; }
    }
}
