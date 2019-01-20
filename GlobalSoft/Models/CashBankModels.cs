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
        public string KodeBank { get; set; }

        public int BankType { get; set; }    // 1: Bank, 2:Cash 3:Kasbon
        public decimal Saldo { get; set; }
        
        public int GlAkunID { get; set; }
        public virtual  GlAccount GlAccount { get; set; }

        public virtual ICollection<AptPayment> AptPayment { get; set; }

    }

    public class CbTransH
    {
        public CbTransH()
        {
            this.CbTransDs = new HashSet<CbTransD>() ;
        }

        [Key]
        public int TranshID { get; set; }
        public Guid GuidCb { get; set; }
        [StringLength(20)]
        public string Docno { get; set; }

        public int BankID { get; set; }
        public virtual CbBank Bank1 { get; set; }

        public int BankID2 { get; set; } = 0;

        public string kodebank { get; set; }
        public DateTime Tanggal { get; set; }
        [StringLength(250)]
        public string Keterangan { get; set; }
        public bool Posted { get; set; } = false;
        public string Createdby { get; set; }
        public decimal Saldo { get; set; }
        public virtual ICollection<CbTransD> CbTransDs { get; set; }


    }

    public class CbTransD
    {
        [Key]
        public int TransdID { get; set; }
        
        public Guid GuidDb { get; set; }
        public Guid GuidCb { get; set; }

        [StringLength(20)]
        public string Docno { get; set; }
        public DateTime Tanggal { get; set; }           
        
        public int TransNoID { get; set; }
        public virtual AptTrsNo AptTrsNo { get; set; }
        public string SourceCode { get; set; }

        [StringLength(250)]
        public string Keterangan { get; set; }
        public int BankID { get; set; }
        public decimal Jumlah { get; set; }
        public decimal Terima { get; set; }
        public decimal Bayar { get; set; }

        public int TranshID { get; set; }
        public virtual CbTransH CbTransH { get; set; }
    }

    public class CbTrans
    {
        [Key]
        public int TransID { get; set; }    // sama dengan no kodetrans ArPiutang

        [StringLength(20)]
        [Display(Name = "No Bukti")]
        public string NoRef { get; set; }    //sama dengan no Dokumen di AptSPesanan

       
        [Display(Name = "Tanggal")]
        public DateTime Tanggal { get; set; }       // Tanggal Transaksi

        public string Unit { get; set; }
        public int UnitID { get; set; }         // Unit No 
        public virtual AptUnit AptUnit { get; set; }

        [Required]
        public int PersonID { get; set; }         //customer atau Supplier
        public string ShortCode { get; set; }

        public string KodeMarketing { get; set; }
        public int MarketingID { get; set; }
        public virtual AptMarketing AptMarketing { get; set; }

        [StringLength(250)]
        public string Keterangan { get; set; }

        [Display(Name = "Jumlah Bayar")]


        public decimal Payment { get; set; }            // Jumlah Pembayaran

        [Display(Name = "Pembayaran")]
        public int PaymentID { get; set; }                // jenis pembayaran Tunai,Debet
        public virtual AptPayment AptPayment { get; set; }
        public string kodebayar { get; set; }

        public int BankID { get; set; }
        public string KodeBank { get; set; }

        public DateTime TglSelesai { get; set; }        // tanggal selesai cicilan
        public int Cicilan { get; set; }                // cicil berapa kali

        public int TransNoID { get; set; }           // No Trans = 1-Booking Fee, 2-Surat Pesanan , 3-Batal
        public virtual AptTrsNo AptTrsNo { get; set; }

        public int BayarID { get; set; }         // 1-Inhouse,2-KPR,3-Tunai
        public virtual AptBayar AptBayar { get; set; }

       
        public decimal Jumlah { get; set; }
      
        public decimal Bayar { get; set; }
       
        public decimal Sisa { get; set; }
        
        public decimal SldSisa { get; set; }
      
        public decimal Harga { get; set; }

        public decimal Angsuran { get; set; }
     
        public decimal Piutang { get; set; }
      
        public decimal Diskon { get; set; }

        public int SPesananID { get; set; }

        [StringLength(20)]
        public string NoSPesanan { get; set; }
        [StringLength(20)]
        public string NoJurnal { get; set; }

        
    }

    public partial class OrderMaster
    {
        public string OrderDateString { get; set; }
    }
}