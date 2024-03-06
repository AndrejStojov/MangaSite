using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MangaSite.Models
{
    public class Comic
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int TypeCId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Descripion { get; set; }
        public string ImgURL { get; set; }
        
        public string Serialized { get; set; }
        [Required]
        [Range(0, 10)]
        public float Rating { get; set; }

        public virtual Author Author { get; set; }
        public virtual TypeC Type { get; set; }
        public virtual List<Genre>Genres { get; set; }
        public virtual List<Comment>Comments { get; set; }

        public Comic()
        {
            Genres = new List<Genre>();
            Comments = new List<Comment>();
        }

    }
}