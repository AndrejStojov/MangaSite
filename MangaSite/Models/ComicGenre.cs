using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaSite.Models
{
    public class ComicGenre
    {
        public int ComicId { get; set; }
        public int GenreId { get; set; }
        public Comic Comic { get; set; }
        public List<Genre>Genres { get; set; }
        public ComicGenre()
        {
            Genres = new List<Genre>();
        }
    }
}