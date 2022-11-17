using Microsoft.AspNetCore.Mvc.Rendering;
using VidlyWeb.Models;

namespace VidlyWeb.ViewModels
{
    public class MovieAndGenreViewModel
    {
        public Movie Movie { get; set; }
        public List<SelectListItem> Genres { get; set; }
    }
}
