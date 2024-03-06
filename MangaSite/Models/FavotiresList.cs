using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaSite.Models
{
    public class FavotiresList
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual List<Comic>Comics { get; set; }
        public FavotiresList()
        {
            Comics = new List<Comic>();
        }
    }
}