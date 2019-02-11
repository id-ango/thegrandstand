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

        public decimal Luas { get; set; }
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
        public DateTime Duedate { get; set; }       // Tanggal Transaksi
        [StringLength(100)]
        public string TglString { get; set; }

        public int UnitID { get; set; }         // Unit No 
        [StringLength(20)]
        public string UnitNo { get; set; }
        public int SPesananID { get; set; }
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
        public string BankName { get; set; }
        public string KodeBank { get; set; }
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
        public string TransNo { get; set; }
        [StringLength(250)]
        public string Keterangan { get; set; }
        public decimal Jumlah { get; set; }
        public decimal Terima { get; set; }
        public decimal Bayar { get; set; }
        public virtual OdTransH OdTransH { get; set; }

    }

    public class  OrderViewModel
    {
        public OrderViewModel()
        {
            this.OrderDetails = new HashSet<OrderDetailsViewModel>();
        }

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

/*    public class TabularViewModel
    {
        [Key]
        public int TabID { get; set; }
        public List<AptUnit> Units { get; set; }
        public List<AptGedung> Gedungs { get; set; }
        public List<AptCategorie> Kategoris { get; set; }
    }
*/
    public class GedungViewsModels
    {
        [Key]
        public int TransID { get; set; }    // sama dengan no kodetrans ArPiutang

        [StringLength(20)]
        [Display(Name = "No Ref")]
        public string NoRef { get; set; }    //sama dengan no Dokumen di AptSPesanan

        [Display(Name = "Tanggal")]
        public DateTime Tanggal { get; set; }       // Tanggal Transaksi
        public int GedungID { get; set; }
        [Display(Name = "Level")]
        public string Gedung { get; set; }
        [Display(Name = "Lantai")]
        public int Lantai1 { get; set; }
        [Display(Name = "Lantai")]
        public int Lantai2 { get; set; }
        public int UnitID { get; set; }         // Unit No 
        [Display(Name = "Unit No")]
        [StringLength(10)]
        public string UnitNo { get; set; }
        [StringLength(20)]
        public string Categorie { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
        public int Lantai { get; set; }
        public int CustomerID { get; set; }
        [StringLength(100), Display(Name = "Nama")]
        public string CustomerName { get; set; }

        public decimal Luas { get; set; }
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

    public class MyGedung
    {
        public int MyGedungID { get; set; }      
        public int GedungID { get; set; }
        [Display(Name = "Level")]
        public string Gedung { get; set; }
        [Display(Name = "Lantai")]
        public int Lantai1 { get; set; }
        public int UnitID1 { get; set; }         // Unit No 
        [Display(Name = "Nomor")]       
        public string UnitNo1 { get; set; }
        public int CategorieID1 { get; set; }
        [Display(Name = "Tipe")]
        public string Categorie1 { get; set; }
        public int StatusID1 { get; set; }       
        public string Status1 { get; set; }
        [Display(Name = "Ukuran")]
        public decimal Luas1 { get; set; }
        [Display(Name = "Lantai")]
        public int Lantai2 { get; set; }
        public int UnitID2 { get; set; }         // Unit No 
        [Display(Name = "Nomor")]
        public string UnitNo2 { get; set; }
        public int CategorieID2 { get; set; }
        [Display(Name = "Tipe")]
        public string Categorie2 { get; set; }
        public int StatusID2 { get; set; }
        public string Status2 { get; set; }
        [Display(Name = "Ukuran")]
        public decimal Luas2 { get; set; }
        [Display(Name = "Lantai")]
        public int Lantai3 { get; set; }
        public int UnitID3 { get; set; }         // Unit No 
        [Display(Name = "Nomor")]
        public string UnitNo3 { get; set; }
        public int CategorieID3 { get; set; }
        [Display(Name = "Tipe")]
        public string Categorie3 { get; set; }
        public int StatusID3 { get; set; }
        public string Status3 { get; set; }
        [Display(Name = "Ukuran")]
        public decimal Luas3 { get; set; }
        [Display(Name = "Lantai")]
        public int Lantai4 { get; set; }       
        public int UnitID4 { get; set; }         // Unit No 
        [Display(Name = "Nomor")]
        public string UnitNo4 { get; set; }
        public int CategorieID4 { get; set; }
        [Display(Name = "Tipe")]
        public string Categorie4 { get; set; }
        public int StatusID4 { get; set; }
        public string Status4 { get; set; }
        [Display(Name = "Ukuran")]
        public decimal Luas4 { get; set; }
    }

    public class ArHView
    {
        public int ArHID { get; set; }
        public Guid ArHGd { get; set; }
        public int KodeNo { get; set; }
        [StringLength(20)]
        public string Bukti { get; set; }
        public DateTime Tanggal { get; set; }
        [Display(Name = "Bank")]
        public int BankID { get; set; }
        public string BankName { get; set; }
        [Display(Name = "Customer")]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Alamat { get; set; }
        public int MarketingID { get; set; }
        [Display(Name = "Unit")]
        public int UnitID { get; set; }
        public string Keterangan { get; set; }
        public DateTime JthTempo { get; set; }
        public decimal Jumlah { get; set; }
        public decimal Piutang { get; set; }
        public decimal Unapplied { get; set; }
        public decimal Diskon { get; set; }
        public virtual ICollection<ArDView> TransDetail { get; set; }
    }

    public class ArDView
    {
        [Key]
        public int ArDID { get; set; }
        public Guid ArDGd { get; set; }
        public DateTime Tanggal { get; set; }
        public DateTime? Duedate { get; set; }
        public int SPesananID { get; set; }
        public int CustomerID { get; set; }
        public string Keterangan { get; set; }
        public decimal Piutang { get; set; }
        public decimal Bayar { get; set; }
        public decimal Diskon { get; set; }
        public decimal Sisa { get; set; }
        public Guid ArHGd { get; set; }
        public int ArHID { get; set; }
        public virtual ArHView ArHView { get; set; }

    }

    public class TrsnoVM
    {
        [Key]
        public int TransNoID { get; set; }

        [StringLength(50), Required]
        [Display(Name = "Jenis Transaksi")]
        public string TransNo { get; set; }                // Uang "Tanda Jadi","Surat Pesanan"
        public int GlAkunID { get; set; }
        [Display(Name = "Nama Akun")]
        public string GlAkunName { get; set; }
        [Display(Name = "Kode Akun")]
        public string GlAkun { get; set; }
        [StringLength(20)]
        public string Bukti { get; set; }
        public DateTime Tanggal { get; set; }
        [StringLength(250)]
        public string Keterangan { get; set; }
        [Display(Name = "Jumlah Bayar")]
        public decimal Payment { get; set; }            // Jumlah Pembayaran
        public decimal Piutang { get; set; }            // Jumlah Pembayaran
        public decimal Pembayaran { get; set; }            // Jumlah Pembayaran
        public decimal Sisa { get; set; }            // Jumlah Pembayaran

    }

    public class SpesananVM
    {
        [Key]
        public int SPesananID { get; set; }         // ID Transaksi
        [StringLength(20)]
        public string SPesanan { get; set; }      // No Piutang

        public string Tanggal { get; set; }
        public string Duedate { get; set; }

        // ini adalah field untuk hubungan dengan AptTrans yang generate hubungan surat pesanan dengan detailnya
        public int KodeTrans { get; set; }
        [StringLength(20)]
        public string LPB { get; set; }        // jadi jurnal kalau ada pembayaran
        /// batas tutp

        [StringLength(200)]
        public string Keterangan { get; set; }       // keterangan uang angsuran unit 1010 
        [StringLength(200)]
        public string KetBayar { get; set; }       // keterangan uang angsuran unit 1010 

        public decimal Jumlah { get; set; }       // Harga
        public decimal Bayar { get; set; }            // booking fee
        public decimal Sisa { get; set; }             // bonus
        public decimal SldSisa { get; set; }
        public decimal Diskon { get; set; }


    }

    public class LaporanPiutangVM
    {
        [Key]
        public int TransID { get; set; }    // sama dengan no kodetrans ArPiutang
        public int SPesananID { get; set; }
        [StringLength(20)]
        [Display(Name = "No Ref")]
        public string NoRef { get; set; }    //sama dengan no Dokumen di AptSPesanan
        public Guid SpesananGd { get; set; }
        [Display(Name = "Tanggal")]
        public DateTime Tanggal { get; set; }       // Tanggal Transaksi

        public string UnitNo { get; set; }
        public int UnitID { get; set; }         // Unit No 
        
        public int CustomerID { get; set; }    
        public string CustomerName { get; set; }

        public int MarketingID { get; set; }       
        public string MarketingName { get; set; }

        [StringLength(250)]
        public string Keterangan { get; set; }
        [Display(Name = "Jumlah Bayar")]
        public decimal Payment { get; set; }            // Jumlah Pembayaran

        [Display(Name = "Cara Bayar")]
        public int PaymentID { get; set; }                // jenis pembayaran Tunai,Debet
        public string PaymentName { get; set; }

        public DateTime TglSelesai { get; set; }        // tanggal selesai cicilan
        public int Cicilan { get; set; }                // cicil berapa kali

        public int TransNoID { get; set; }           // No Trans = 1-Surat Pesanan
        public virtual AptTrsNo AptTrsNo { get; set; }

        public int BayarID { get; set; }         // 1-Inhouse,2-KPR,3-Tunai
        public virtual AptBayar AptBayar { get; set; }

        public decimal Harga { get; set; }
        public decimal BookingFee { get; set; }
        public decimal BonusFee { get; set; }
        public decimal Piutang { get; set; }
        public decimal Bayar { get; set; }
        public decimal Sisa { get; set; }


    }
}