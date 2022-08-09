using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LieTunesReview.Models
{
    [Table("Song")]
    public partial class Song
    {
        public Song()
        {
            UserSongs = new HashSet<UserSong>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public virtual ICollection<UserSong> UserSongs { get; set; }
    }
}
