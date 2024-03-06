using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaSite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTime Time { get; set; }
        public int ComicId { get; set; }
        public virtual Comic Comic { get; set; }
    }
}