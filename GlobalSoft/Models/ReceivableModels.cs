using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GlobalSoft.Models
{
    public class ArCustomer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [StringLength(100),Display(Name = "Nama")]
        public string CustomerName { get; set; }

        [Index]       
        [MinLength(2,ErrorMessage = "Min 2 karakter"),MaxLength(10,ErrorMessage ="Max 10 karakter")]
        public string ShortName { get; set; }

        [StringLength(200), Display(Name = "Alamat KTP")]
        public string Alamat { get; set; }

        [StringLength(50),Display(Name = "KTP")]
        public string Ktp  { get; set; }

        [StringLength(100),Display(Name = "Telpon")]
        public string Phone { get; set; }

        [StringLength(200), Display(Name = "Alamat Sekarang")]
        public string AlamatSekarang { get; set; }

        [StringLength(20),Display(Name = "Kode Pos")]
        public string KodePos { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(50),Display(Name = "NPWP")]
        public string Npwp { get; set; }

        [StringLength(11)]
        public string AccounSet { get; set; }

        public virtual ICollection<AptUnit> AptUnit { get; set; }
        public virtual ICollection<ArPiutang> ArPiutang { get; set; }
    }

    public class ArPiutang
    {
        [Key]
        public int PiutangID { get; set; }
        [StringLength(20)]
        public string Dokumen { get; set; }

        public DateTime Tanggal { get; set; }
        public DateTime Duedate { get; set; }
        
        public int KodeTrans { get; set; }     // 1-invoice, 2- pembayaran
        public string LPB { get; set; }

        [StringLength(200)]
        public string Keterangan { get; set; }

        public decimal Jumlah { get; set; }
        public decimal Bayar { get; set; }
        public decimal Sisa { get; set; }
        public decimal SldSisa { get; set; }
        public decimal Diskon { get; set; }    
        
        public int CustomerID { get; set; }
        public virtual ArCustomer ArCustomer { get; set; }


    }

}