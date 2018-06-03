using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlobalSoft.Models
{

    public class AptType                // Tipe = 1BR,2BR    not Mapped
    {
        public int Id { get; set; }

        [StringLength(20), Required]
        public string Tipe { get; set; }
    }

    public class AptStatus              // Status , 0 Available, 1 Hold, 5 Sold    not Mapped
    {
        public int Id { get; set; }
        public String Status { get; set; }
    }


    public class AptCategorie       //Kategori = Emerald
    {
        
        public int Id { get; set; }

        [Display(Name = "Kategori"),Required]
        [StringLength(20)]
        public string Categorie { get; set; }

        public decimal Size { get; set; }
    }
   
    public class AptUnit                                // Unit Apartment
    {
        public int Id { get; set; }

        [Display(Name = "Unit"),Required]
        public int UnitNo { get; set; }

        public int CategorieId { get; set; }
        public virtual AptCategorie AptCategorie { get; set; }

        public int StatusId { get; set; }
        public virtual AptStatus AptStatus { get; set; }

    }
}