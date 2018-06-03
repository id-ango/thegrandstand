using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlobalSoft.Models
{
    public class AptCategorie
    {
        
        public int Id { get; set; }

        [Display(Name = "Kategori"),Required]
        [StringLength(20)]
        public string Categorie { get; set; }

        public decimal Size { get; set; }
    }

    public class AptType
    {
        public int Id { get; set; }

        [StringLength(20),Required]
        public string Tipe { get; set; }
    }
}