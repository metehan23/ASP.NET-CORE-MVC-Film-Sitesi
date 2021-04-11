using MovieProject.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class AdminMoviesVm
    {
        public List<Movie> Movies { get; set; }
    }
    public class AdminEditMovieVM
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }      
        public string SelectedGenres { get; set; }
    }
}
