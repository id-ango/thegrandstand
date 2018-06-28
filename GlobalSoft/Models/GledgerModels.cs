using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GlobalSoft.Models
{
    public class GlAccount
    {
        [Key]
        public int GlAkunID { get; set; }

        [Index]
        [StringLength(10,ErrorMessage = "Max 10 Karakter"),MinLength(2),MaxLength(10)]
        [Display(Name ="Kode Akun")]
        public string GlAkun { get; set; }
        [StringLength(10), MinLength(2), MaxLength(10)]
        [Display(Name ="Department")]
        public string GlAkun2 { get; set; }
        [StringLength(100)]
        [Display(Name = "Nama Akun")]
        public string GlAkunName { get; set; }
        
        public int GlTipeID { get; set; }                   // Cash/bank
        public virtual GlTipe GlTipe { get; set; }

        public virtual ICollection<CbBank> CbBank { get; set; }
    }

    public class GlTipe
    {
        [Key]
        public int GlTipeID { get; set; }

        [StringLength(100)]
        [Display(Name = "Tipe Akun")]
        public string GlTipeName { get; set; }

        public virtual ICollection<GlAccount> GlAccount { get; set; }
    }
}