using MovieProject.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class AdminGenresVm
    {
        public List<AdminGenreVm> Genres { get; set; }
    }

    public class AdminGenreVm
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
