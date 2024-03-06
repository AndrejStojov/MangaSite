using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaSite.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Comic> Comics { get; set; }
        public Genre()
        {
            Comics = new List<Comic>();
        }
    }
}