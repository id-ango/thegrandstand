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
        [Display(Name ="Nama Bank")]
        public string BankName { get; set; }

        [StringLength(50)]
        [Display(Name = "Rekening Bank")]
        public string BankAccount { get; set; }

    //    public int BankType { get; set; }    // 1: Bank, 2:Cash 3:Kasbon
        public decimal Saldo { get; set; }
        
        public int GlAkunID { get; set; }
        public virtual  GlAccount GlAccount { get; set; }

        public virtual ICollection<AptPayment> AptPayment { get; set; }

    }

    public class CbTransH
    {
        [Key]
        public int TranshID { get; set; }
        [StringLength(20)]
        public string NoRef { get; set; }
        public DateTime Tanggal { get; set; }
        public string Keterangan { get; set; }
        public decimal SaldoAwal { get; set; }
        public decimal SaldoAkhir { get; set; }
        public decimal Saldo { get; set; }

    }

    public class CbTransD
    {
        [Key]
        public int CbTransdID { get; set; }
        public int CbTransh { get; set; }
        [StringLength(20)]
        public string NoRef { get; set; }
        public DateTime Tanggal { get; set; }
        public decimal Jumlah { get; set; }
        [StringLength(10)]
        public string SourceCode { get; set; }
        public string Label { get; set; }
        public int BankID { get; set; }

    }
}