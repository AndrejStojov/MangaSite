using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaSite.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Bio { get; set; }
        public string ImgURL { get; set; }
        public virtual List<Comic> Comics { get; set; }

        public Author()
        {
            Comics = new List<Comic>();
        }
    }
}