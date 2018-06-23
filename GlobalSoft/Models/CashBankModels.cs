using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlobalSoft.Models
{
    public class CbBank
    {
        [Key]
        public int BankID { get; set; }

        [StringLength(100)]
        public string BankName { get; set; }

        [StringLength(50)]
        public string BankAccount { get; set; }

        public int BankType { get; set; }    // 1: Bank, 2:Cash 3:Kasbon
        public decimal Saldo { get; set; }
        
        public int GlAkunID { get; set; }
        public virtual  GlAccount GlAccount { get; set; }

        public virtual ICollection<AptPayment> AptPayment { get; set; }

    }
}