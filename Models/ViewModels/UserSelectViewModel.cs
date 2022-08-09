using Microsoft.AspNetCore.Mvc.Rendering;

namespace LieTunesReview.Models.ViewModels
{
    public class UserSelectViewModel
    {
        public ICollection<SelectListItem> Users { get; set; }
        public UserSelectViewModel(IEnumerable<User> users)
        {
            Users = new HashSet<SelectListItem>();

            foreach(User u in users)
            {
                Users.Add(new SelectListItem(u.Name, u.Id.ToString()));
            }
        }
    }
}
