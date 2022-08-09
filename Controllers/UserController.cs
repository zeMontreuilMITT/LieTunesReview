using LieTunesReview.Models;
using LieTunesReview.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LieTunesReview.Controllers
{
    public class UserController : Controller
    {
        private LieTunesContext _db;

        public UserController(LieTunesContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            UserSelectViewModel vm = new UserSelectViewModel(_db.Users.ToList());
            return View(vm);
        }

        public IActionResult SongList(int? id)
        {
            if(id == null)
            {
                return NotFound();
            } else
            {
                try
                {
                    User user = _db.Users
                        .Include(u => u.UserSongs)
                        .ThenInclude(us => us.Song)
                        .First(u => u.Id == id);

                    ViewBag.UserName = user.Name;

                    List<Song> songs = user.UserSongs
                        .Select(us => us.Song).ToList();

                    return View(songs);
                } 
                    catch(Exception ex)
                {
                    return NotFound();
                }
            }
        }
    }
}
