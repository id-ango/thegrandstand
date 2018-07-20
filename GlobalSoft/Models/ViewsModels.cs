using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlobalSoft.Models
{
    public class BookViewsModels
    {
  
        public int TransID { get; set; }    // sama dengan no kodetrans ArPiutang

        [StringLength(20)]
        [Display(Name = "No Ref")]
        public string NoRef { get; set; }    //sama dengan no Dokumen di AptSPesanan

        [Display(Name = "Tanggal")]

        public DateTime Tanggal { get; set; }       // Tanggal Transaksi


        public int UnitID { get; set; }         // Unit No 
        [Display(Name = "Unit No")]
        [ StringLength(10)]
        public string UnitNo { get; set; }


        public int CustomerID { get; set; }       
        [StringLength(100), Display(Name = "Nama")]
        public string CustomerName { get; set; }


        public int MarketingID { get; set; }
        [StringLength(100), Display(Name = "Marketing")]
        public string MarketingName { get; set; }

        [StringLength(100)]
        [Display(Name = "Nama Agen")]
        public string AgenName { get; set; }

        [StringLength(250)]
        public string Keterangan { get; set; }
        [Display(Name = "Jumlah Bayar")]
        public decimal Payment { get; set; }            // Jumlah Pembayaran

        [Display(Name = "Cara Bayar")]
        public int PaymentID { get; set; }                // jenis pembayaran Tunai,Debet
        [StringLength(20)]
        [Display(Name = "Cara Bayar")]
        public string PaymentName { get; set; }

        

    }

    public class UnitPiutang
    {
        [Key]
        public int ID { get; set; }    // sama dengan no kodetrans ArPiutang

        [StringLength(20)]
        [Display(Name = "No Ref")]
        public string NoRef { get; set; }    //sama dengan no Dokumen di AptSPesanan

        [Display(Name = "Tanggal")]

        public DateTime Tanggal { get; set; }       // Tanggal Transaksi


        public int UnitID { get; set; }         // Unit No 
        public virtual AptUnit AptUnit { get; set; }


        public int CustomerID { get; set; }
        public virtual ArCustomer ArCustomer { get; set; }


        public int MarketingID { get; set; }
        public virtual AptMarketing AptMarketing { get; set; }

        [StringLength(250)]
        public string Keterangan { get; set; }
        [Display(Name = "Jumlah Bayar")]
        public decimal Payment { get; set; }            // Jumlah Pembayaran

        [Display(Name = "Cara Bayar")]
        public int PaymentID { get; set; }                // jenis pembayaran Tunai,Debet
        public virtual AptPayment AptPayment { get; set; }

        public DateTime TglSelesai { get; set; }        // tanggal selesai cicilan
        public int Cicilan { get; set; }                // cicil berapa kali

        public int TransNoID { get; set; }           // No Trans = 1-Booking Fee, 2-Surat Pesanan , 3-Batal
        public virtual AptTrsNo AptTrsNo { get; set; }

        public int BayarID { get; set; }         // 1-Inhouse,2-KPR,3-Tunai
        public virtual AptBayar AptBayar { get; set; }

        public decimal Harga { get; set; }

        public decimal Angsuran { get; set; }

        public decimal Piutang { get; set; }
    }
    
    public class UnitVM
    {
        public AptUnit  Unit  { get; set; }
        public List<UnitPiutang> Piutang { get; set; }
    }
}