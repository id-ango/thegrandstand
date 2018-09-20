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
        [StringLength(100), Display(Name = "Nama")]
        public string CustomerName { get; set; }

        [Index]
        [MinLength(2, ErrorMessage = "Min 2 karakter"), MaxLength(10, ErrorMessage = "Max 10 karakter")]
        public string ShortName { get; set; }

        [StringLength(200), Display(Name = "Alamat KTP")]
        public string Alamat { get; set; }

        [StringLength(50), Display(Name = "KTP")]
        public string Ktp { get; set; }

        [StringLength(100), Display(Name = "Telpon")]
        public string Phone { get; set; }

        [StringLength(200), Display(Name = "Alamat Sekarang")]
        public string AlamatSekarang { get; set; }

        [StringLength(20), Display(Name = "Kode Pos")]
        public string KodePos { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(50), Display(Name = "NPWP")]
        public string Npwp { get; set; }
        [StringLength(20)]
        public string AkunSet { get; set; }

        public virtual ICollection<ArPiutang> ArPiutang { get; set; }


    }

    public class ArPiutang
    {
        [Key]
        public int PiutangID { get; set; }         // ID Transaksi
        [StringLength(20)]
        public string Dokumen { get; set; }      // No Piutang

        public DateTime Tanggal { get; set; }
        public DateTime Duedate { get; set; }

        // ini adalah field untuk hubungan dengan AptTrans yang generate hubungan surat pesanan dengan detailnya
        public int KodeTrans { get; set; } = 0;    //ini kode buatan sendiri yaitu 1 untuk surat pesanan, 2- Invoice dari luar, 3-credit note
        [StringLength(20)]
        public string LPB { get; set; }        // sama dengan noRef Surat Pesanan
        /// batas tutp

        [StringLength(200)]
        public string Keterangan { get; set; }       // keterangan uang angsuran unit 1010 

        public decimal Jumlah { get; set; }
        public decimal Bayar { get; set; }
        public decimal Sisa { get; set; }
        public decimal SldSisa { get; set; }
        public decimal Diskon { get; set; }

        public int CustomerID { get; set; }
        public virtual ArCustomer ArCustomer { get; set; }


    }

    public class ArAkunSet
    {
        public int AkunsetID { get; set; }

        [StringLength(20)]
        public string AkunSet { get; set; }

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

    }

    public class PiutangMain
    {
        [Key]
        public int MainID { get; set; }
        public string NoBukti { get; set; }
        public DateTime Tanggal { get; set; }

        public int CustomerID { get; set; }
        public virtual ArCustomer ArCustomer { get; set; }

        public int BankID { get; set; }


        public int? UnitID { get; set; }
        public virtual AptUnit AptUnit { get; set; }

        public int KodeTrans { get; set; }
        [StringLength(250)]
        public string Keterangan { get; set; }
        public decimal Jumlah { get; set; }
        public decimal Piutang { get; set; }
        public decimal Unapplied { get; set; }
        public decimal Diskon { get; set; }
        public virtual ICollection<PiutangDetail> PiutangDetail { get; set; }
    }
    public class PiutangDetail
    {
        [Key]
        public int DetailID { get; set; }
        public int MainID { get; set; }
        public virtual PiutangMain PiutangMain { get; set; }
        public int SPesananID { get; set; }
        public DateTime Duedate { get; set; }
        [StringLength(20)]
        public string TglString { get; set; }
        [StringLength(250)]
        public string Keterangan { get; set; }
        public decimal Piutang { get; set; }
        public decimal Bayar { get; set; }
        public decimal Diskon { get; set; }
        public decimal Sisa { get; set; }
        public int CustomerID { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }
        public int UnitID { get; set; }
        [StringLength(20)]
        public string UnitNo { get; set; }
        [StringLength(20)]
        public string SPesanan { get; set; }

    }
    //
    //
    //
    public class ArTransH
    {
        [Key]
        public int ArHID { get; set; }
        public Guid ArHGd { get; set; }
        public int KodeNo { get; set; }
        [StringLength(20)]
        public string Bukti { get; set; }
        public DateTime Tanggal { get; set; }
        [Display(Name ="Bank")]
        public int BankID { get; set; }
        [Display(Name ="Customer")]
        public int CustomerID { get; set; }
        public int MarketingID { get; set; }
        [Display(Name = "Unit")]
        public int UnitID { get; set; }
        public string Keterangan { get; set; }
        public DateTime? JthTempo { get; set; }
        public decimal Jumlah { get; set; }
        public decimal Piutang { get; set; }
        public decimal Unapplied { get; set; }
        public decimal Diskon { get; set; }
        public virtual ICollection<ArTransD> TransDetail { get; set; }
    }

    public class ArTransD
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
        public virtual ArTransH ArTransH{ get; set; }

    }
}