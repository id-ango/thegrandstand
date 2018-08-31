using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GlobalSoft.Models
{
   
    public class AptType                // Tipe = 1BR,2BR    not Mapped
    {
        [Key]
        public int TipeID { get; set; }
       
        [StringLength(20), Required]
        public string Tipe { get; set; }
        public virtual ICollection<AptCategorie> AptCategorie { get; set; }
    }

    public class AptStatus              // Status , 0 Available, 1 Hold, 5 Sold    not Mapped
    {
        [Key]
        [Display(Name ="Kode")]
        public int StatusID { get; set; }
        [StringLength(20)]
        [Display(Name = "Status Unit")]
        public String Status { get; set; }
        public virtual ICollection<AptUnit> AptUnit { get; set; }

    }
    

    public class AptCategorie       //Kategori = Emerald
    {
        [Key]
        public int CategorieID { get; set; }

        [Display(Name = "Kategori"),Required]
        [StringLength(20)]
        [Index (IsUnique = true)]
        public string Categorie { get; set; }
        public decimal Luas { get; set; }

        public int TipeID { get; set; }
        public virtual AptType AptType { get; set; }
        
        public virtual  ICollection<AptUnit> AptUnit { get; set; }
    }
   
    public class AptUnit                                // Unit Apartment
    {
        
        [Key]
        public int UnitID { get; set; }

        [Display(Name = "Unit No"),Required]
        [Index(IsUnique = true), StringLength(10)]
        public string UnitNo { get; set; }             // No Apartment
        
        public int Lantai { get; set; }

        [Display(Name = "Kategori")]
        public int CategorieID { get; set; }                 // Kategori 
        public virtual AptCategorie AptCategorie { get; set; }

        [Display(Name = "Status")]
        public int StatusID { get; set; }                   // Status Available/Pending/Sold
        public virtual AptStatus AptStatus { get; set; }

        [DisplayFormat(DataFormatString ="{0:n0}")]
        public decimal Inhouse { get; set; }
        [DisplayFormat(DataFormatString = "{0:n0}"),Display(Name ="KPR")]
        public decimal PriceKPR { get; set; }
        public int StatOld { get; set; } = 0;

        [StringLength(10, ErrorMessage = "Max 10 Karakter"), MinLength(2), MaxLength(10)]
        [Display(Name = "Kode Akun")]
        public string GlAkun1 { get; set; }
        [StringLength(10, ErrorMessage = "Max 10 Karakter"), MinLength(2), MaxLength(10)]
        [Display(Name = "Kode Akun")]
        public string GlAkun2 { get; set; }
        [StringLength(10, ErrorMessage = "Max 10 Karakter"), MinLength(2), MaxLength(10)]
        [Display(Name = "Kode Akun")]
        public string GlAkun3 { get; set; }
        [StringLength(10, ErrorMessage = "Max 10 Karakter"), MinLength(2), MaxLength(10)]
        [Display(Name = "Kode Akun")]
        public string GlAkun4 { get; set; }

        public virtual ICollection<AptTrans> AptTrans { get; set; }
    }

    

    public class AptMarketing
    {
        [Key]
        public int MarketingID { get; set; }

        [StringLength(100), Display(Name = "Marketing")]
        public string MarketingName { get; set; }

        [StringLength(20), Display(Name = "Telpon")]
        public string Phone { get; set; }

        [Display(Name = "Agen")]
        public int AgenID { get; set; }
        public virtual AptAgen AptAgen { get; set; }

        public virtual ICollection<AptTrans> AptTrans { get; set; }

    }

    public class AptAgen
    {
        [Key]
        public int AgenID { get; set; }

        [StringLength(100)]
        [Display(Name = "Nama Agen")]
        public string AgenName { get; set; }

        [StringLength(20), Display(Name = "Telpon")]
        public string Phone { get; set; }

        public virtual ICollection<AptMarketing> AptMarketing { get; set; }
    }

    public class AptPayment
    {
        [Key]
        public int PaymentID { get; set; }

        [StringLength(20)]
        [Display(Name = "Cara Bayar")]
        public string PaymentName { get; set; }

        public int BankID { get; set; }
        public virtual CbBank CbBank { get; set; }

        public virtual ICollection<AptTrans> AptTrans { get; set; }
    }

    public class AptTrans
    {
        [Key]
        public int TransID { get; set; }    // sama dengan no kodetrans ArPiutang

        [StringLength(20)]
        [Display(Name ="No Ref")]
        public string NoRef { get; set; }    //sama dengan no Dokumen di AptSPesanan

        [Display(Name ="Tanggal")]
      
        public DateTime  Tanggal { get; set; }       // Tanggal Transaksi

        
        public int   UnitID { get; set; }         // Unit No 
        public virtual AptUnit AptUnit { get; set; }

      
        public int CustomerID { get; set; }
        public virtual ArCustomer ArCustomer { get; set; }

       
        public int MarketingID { get; set; }
        public virtual AptMarketing AptMarketing { get; set; }

        [StringLength(250)]
        public string Keterangan { get; set; }
        [Display(Name ="Jumlah Bayar")]
        public decimal Payment { get; set; }            // Jumlah Pembayaran

        [Display(Name ="Cara Bayar")]
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

        public ICollection<AptSPesanan> AptSPesanan { get; set; }
    }

    public class AptBayar
    {
        [Key]
        public int BayarID { get; set; }
        [StringLength(20)]
        public string CaraBayar { get; set; }   //Inhouse,KPR,Tunai

        public decimal Bunga { get; set; } = 0;

        public virtual ICollection<AptTrans> AptTrans { get; set; }



    }

    public class AptTrsNo
    {
        [Key]
        public int TransNoID { get; set; }

        [StringLength(20),Required]
        [Display(Name ="Jenis Transaksi")]
        public string TransNo { get; set; }                // Uang "Tanda Jadi","Surat Pesanan"
        public int GlAkunID { get; set; }
        

        public virtual ICollection<AptTrans> AptTrans { get; set; }
        public virtual ICollection<CbTrans> CbTrans { get; set; }
    }

    public class AptSPesanan
    {
        [Key]
        public int SPesananID { get; set; }         // ID Transaksi
        [StringLength(20)]
        public string SPesanan { get; set; }      // No Piutang

        public DateTime Tanggal { get; set; }
        public DateTime Duedate { get; set; }

        // ini adalah field untuk hubungan dengan AptTrans yang generate hubungan surat pesanan dengan detailnya
        public int KodeTrans { get; set; }   
        public virtual AptTrans AptTrans { get; set; }
        [StringLength(20)]
        public string LPB { get; set; }        // jadi jurnal kalau ada pembayaran
        /// batas tutp

        [StringLength(200)]
        public string Keterangan { get; set; }       // keterangan uang angsuran unit 1010 
        [StringLength(200)]
        public string KetBayar { get; set; }       // keterangan uang angsuran unit 1010 

        public decimal Jumlah { get; set; }
        public decimal Bayar { get; set; }
        public decimal Sisa { get; set; }
        public decimal SldSisa { get; set; }
        public decimal Diskon { get; set; }


    }

    public class AptUrut
    {
        public int AptUrutID { get; set; }
        public int TipeTrans { get; set; }        // 1-BookingFee,2-SuratPesanan,3-BayarAngsuran
        public DateTime Tanggal { get; set; }
        public int NoUrut { get; set; }
    }

   
    public class GlobalsoftDBContext : DbContext
    {
        public GlobalsoftDBContext() { }

        public DbSet<AptType> AptTipes { get; set; }
        public DbSet<AptCategorie> AptCategories { get; set; }
        public DbSet<AptUnit> AptUnits { get; set; }
        public DbSet<AptStatus> AptStatuses { get; set; }
        public DbSet<AptAgen> AptAgens { get; set; }
        public DbSet<AptMarketing> AptMarketings { get; set; }
        public DbSet<AptPayment> AptPayments { get; set; }
        public DbSet<AptTrans> AptTranss { get; set; }
        public DbSet<AptTrsNo> AptTrsNoes { get; set; }
        public DbSet<ArCustomer> ArCustomers { get; set; }
        public DbSet<ArPiutang> ArPiutangs { get; set; }
        public DbSet<CbBank> CbBanks { get; set; }
        public DbSet<CbTrans> CbTranss { get; set; }
        public DbSet<GlAccount> GlAccounts { get; set; }
        public DbSet<GlTipe> GlTipes { get; set; }
        public DbSet<AptBayar> AptBayars { get; set; }
        public DbSet<AptSPesanan> AptSPesanans { get; set; }
        public DbSet<AptUrut> AptUruts { get; set; }
        public DbSet<PiutangMain> PiutangMains { get; set; }
        public DbSet<PiutangDetail> PiutangDetails { get; set; }
        public DbSet<CbTransH> CbTransHs { get; set; }
        public DbSet<CbTransD> CbTransDs { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<ArTransH> ArTransHs { get; set; }
        public DbSet<ArTransD> ArTransDs { get; set; }



    }
}