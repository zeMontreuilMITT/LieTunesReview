namespace LieTunesReview.Models.ViewModels
{
    public class TopSellingViewModel
    {
        public Song TopSellingSong { get; set; }
        public Artist TopSellingArtist { get; set; }
        public ICollection<Song> TopThreeRatedSongs { get; set; }
        public TopSellingViewModel(Song song, Artist artist, ICollection<Song> songs)
        {
            TopSellingSong = song;
            TopSellingArtist = artist;
            TopThreeRatedSongs = songs;
        }
    }
}
