using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaSite.Models
{
    public class ComicGenreViewModel
    {
        public List<Comic>Comics { get; set; }
        public List<Genre> Genres { get; set; }
        public List<TypeC> typeCs { get; set; }

        public ComicGenreViewModel()
        {
            Comics = new List<Comic>();
            Genres = new List<Genre>();
            typeCs = new List<TypeC>();
        }
    }
}