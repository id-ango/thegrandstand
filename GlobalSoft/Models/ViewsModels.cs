using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlobalSoft.Models
{
    public class BookViewsModels
    {
        [Key]
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
        [StringLength(20)]
        public string Categorie { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
        public int Lantai { get; set; }
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
        public decimal Piutang { get; set; }            // Jumlah Pembayaran
        public decimal Pembayaran { get; set; }            // Jumlah Pembayaran
        public decimal Sisa { get; set; }            // Jumlah Pembayaran

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
        [StringLength(20)]
        public string TglString { get; set; }

        public int UnitID { get; set; }         // Unit No 
        [StringLength(20)]
        public string UnitNo { get; set; }

        public int CustomerID { get; set; }
        public virtual ArCustomer ArCustomer { get; set; }


        public int MarketingID { get; set; }
        public virtual AptMarketing AptMarketing { get; set; }

        [StringLength(250)]
        public string Keterangan { get; set; }
        [Display(Name = "Jumlah Bayar")]
        public decimal Payment { get; set; }            // Jumlah Pembayaran
        public decimal Bayar { get; set; }

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

    public class OrderVM
    {
        public int OrderKey { get; set; }
        public string Docno { get; set; }
        public DateTime Tanggal { get; set; }
        public int BankID { get; set; }
        public virtual CbBank CbBank { get; set; }
        [StringLength(100)]
        [Display(Name = "Nama Bank")]
        public string BankName { get; set; }      
        public string Keterangan { get; set; }
        //    public int BankType { get; set; }    // 1: Bank, 2:Cash 3:Kasbon
        public decimal Saldo { get; set; }
        [StringLength(3)]
        public string KodeUrut { get; set; }
        public List<CbTransD> OrderDetails { get; set; }
    }

    public class OdTransH
    {
        [Key]
        public int TranshID { get; set; }
        [StringLength(20)]
        public string Docno { get; set; }
        public int BankID { get; set; }
        public int BankID2 { get; set; }
        public DateTime Tanggal { get; set; }
        [StringLength(250)]
        public string Keterangan { get; set; }
        public decimal Saldo { get; set; }
        public virtual ICollection<OdTransD> OdTransDs { get; set; }


    }

    public class OdTransD
    {
        [Key]
        public int TransdID { get; set; }
        public int TranshID { get; set; }
        public int BankID { get; set; }


        [StringLength(20)]
        public string Docno { get; set; }
        public DateTime Tanggal { get; set; }

        public int TransNoID { get; set; }
        [StringLength(250)]
        public string Keterangan { get; set; }
        public decimal Jumlah { get; set; }
        public decimal Terima { get; set; }
        public decimal Bayar { get; set; }
        public virtual OdTransH OdTransH { get; set; }

    }

    public class  OrderViewModel
    {
        
        public System.Guid MasterId { get; set; }
        public string DocNo { get; set; }
        public string Tanggal { get; set; }
        public string Bank { get; set; }
        public string Deskripsi { get; set; }
        public string Jumlah { get; set; }
        public virtual ICollection<OrderDetailsViewModel> OrderDetails { get; set; }
    }


    public class OrderDetailsViewModel
    {
        public System.Guid DetailId { get; set; }
        public System.Guid MasterId { get; set; }
        public string Source { get; set; }
        public string Keterangan { get; set; }
        public string Terima { get; set; }
        public string Bayar { get; set; }

    }
}