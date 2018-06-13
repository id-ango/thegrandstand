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
        public int StatusID { get; set; }
        [StringLength(20)]
        [Display(nameof="Status Unit")]
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

        [DisplayFormat(DataFormatString ="{0:n}")]
        public decimal Inhouse { get; set; }
        [DisplayFormat(DataFormatString = "{0:n}"),Display(Name ="KPR")]

        public decimal PriceKPR { get; set; }
        public int StatOld { get; set; }

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
       public virtual ICollection<AptTrans> AptTrans { get; set; }
    }

    public class AptTrans
    {
        [Key]
        public int TransID { get; set; }

        [StringLength(20)]
        [Display(Name ="No Ref")]
        public string NoRef { get; set; }

        [Display(Name ="Tanggal UTJ")]
        public DateTime Tanggal { get; set; }       // Tanggal Transaksi

        [Display(Name ="Unit No.")]
        public int   UnitID { get; set; }         // Unit No 
        public virtual AptUnit AptUnit { get; set; }

        [Display(Name = "Customer")]
        public int CustomerID { get; set; }
        public virtual ArCustomer ArCustomer { get; set; }

        [Display(Name ="Marketing")]
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

        public int TransNo { get; set; }           // No Trans = 1-Booking Fee, 2-Surat Pesanand,3-Batal
        public virtual AptTrsNo AptTrsNo { get; set; }
    }

    public class AptTrsNo
    {
        [Key]
        public int TransNoID { get; set; }

        [StringLength(20),Required]
        [Display(Name ="Jenis Transaksi")]
        public string TransNo { get; set; }                // Uang "Tanda Jadi","Surat Pesanan"
        public int NoUrut { get; set; }

        public virtual ICollection<AptTrans> AptTrans { get; set; }
    }

    public class ApartmentDBContext : DbContext
    {
        public ApartmentDBContext() { }

        public DbSet<AptType> AptTipes { get; set; }
        public DbSet<AptCategorie> AptCategories { get; set; }
        public DbSet<AptUnit> AptUnits { get; set; }
        public DbSet<AptStatus> AptStatuses { get; set; }
        public DbSet<AptAgen> AptAgens { get; set; }
        public DbSet<AptMarketing> AptMarketings { get; set; }
        public DbSet<AptPayment> AptPayments { get; set; }
        public DbSet<AptTrans> AptTranss { get; set; }
        public DbSet<AptTrsNo> AptTrsNo { get; set; }
        public DbSet<ArCustomer> ArCustomers { get; set; }
    }
}