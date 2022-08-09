using LieTunesReview.Models;
using LieTunesReview.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LieTunesReview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LieTunesContext _context;

        public HomeController(ILogger<HomeController> logger, LieTunesContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult TopSales()
        {
            try
            {
                // get top selling song
                Song topSellingSong = _context.Songs.Include(s => s.UserSongs)
                    .OrderByDescending(s => s.UserSongs.Count()).First();

                // top selling artist
                int topArtistId = _context.UserSongs
                    .Include(us => us.Song).ThenInclude(s => s.Artist).ToList()
                    .GroupBy(us => us.Song.Artist.Id)
                    .OrderByDescending(g => g.Count())
                    .First().Key;

                Artist topSellingArtist = _context.Artists.First(a => a.Id == topArtistId);

                // get a sum of all of the usersongs with the particular artist
                // Group UserSongs by artist and take the one with the highst count

                // top rated songs
                List<Song> TopRatedSongs = _context.Songs
                    .Include(s => s.UserSongs)
                    .OrderByDescending(s => s.UserSongs.Average(us => us.Rating)).Take(3).ToList();

                TopSellingViewModel vm = new TopSellingViewModel(topSellingSong, topSellingArtist, TopRatedSongs);

                return View(vm);
            } catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}