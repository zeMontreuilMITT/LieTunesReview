using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LieTunesReview.Models
{
    [Table("UserSong")]
    public partial class UserSong
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int SongId { get; set; }
        public virtual Song Song { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        public DateTime DateOfPurchase { get; set; }
        public int? Rating { get; set; }
    }
}
