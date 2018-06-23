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
        public int GlAKunID { get; set; }

        [Index]
        [StringLength(10)]
        public string GlAkun { get; set; }
        [StringLength(10)]
        public string GlAkun2 { get; set; }
        [StringLength(100)]
        public string GlAkunName { get; set; }

        public int GlTipeID { get; set; } = 0;                    // Cash/bank
        public virtual GlTipe GlTipe { get; set; }

        public virtual ICollection<CbBank> CbBank { get; set; }
    }

    public class GlTipe
    {
        [Key]
        public int GlTipeID { get; set; }

        [StringLength(100)]
        public string GlTipeName { get; set; }

        public virtual ICollection<GlAccount> GlAccount { get; set; }
    }
}