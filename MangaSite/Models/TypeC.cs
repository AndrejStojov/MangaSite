using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MangaSite.Models
{
    public class TypeC
    {
        [Key]
        public int TypeCId { get; set; }
        public string TypeName { get; set; }
        public virtual List<Comic>Comics { get; set; }

        public TypeC()
        {
            Comics = new List<Comic>();
        }
    }
}