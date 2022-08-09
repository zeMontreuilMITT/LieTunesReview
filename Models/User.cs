using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LieTunesReview.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            UserSongs = new HashSet<UserSong>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Wallet { get; set; }

        public virtual ICollection<UserSong> UserSongs{ get; set; }
    }
}
