using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GlobalSoft.Models
{
    public class ApSupplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        [StringLength(100), Display(Name = "Nama")]
        public string SupplierName { get; set; }

        [Index]
        [MinLength(2, ErrorMessage = "Min 2 karakter"), MaxLength(10, ErrorMessage = "Max 10 karakter")]
        public string ShortName { get; set; }

        [StringLength(200), Display(Name = "Alamat")]
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
        public int AkunSetID { get; set; }
        public string DistribSet { get; set; }
        public int DistribID { get; set; }
        public virtual ICollection<ApHutang> ApHutang { get; set; }


    }

    public class ApHutang
    {
        [Key]
        public int HutangID { get; set; }         // ID Transaksi
        [StringLength(20)]
        public string Dokumen { get; set; }      // No Piutang

        public DateTime Tanggal { get; set; }
        public DateTime Duedate { get; set; }

        // ini adalah field untuk hubungan dengan AptTrans yang generate hubungan surat pesanan dengan detailnya 
        public int KodeTrans { get; set; } = 0;    //ini kode buatan sendiri yaitu 1 untuk Invoice, 2- Invoice dari luar, 3-credit note
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

        public int SupplierID { get; set; }
        public virtual ApSupplier ApSupplier { get; set; }


    }

    public class ApAkunSet
    {
        [Key]
        public int AkunsetID { get; set; }

        [StringLength(20)]
        [Display(Name ="Akun Set")]
        public string AkunSet { get; set; }
        [Display(Name ="Ap Control")]
        public int GlAkunID1 { get; set; }
        public virtual GlAccount GlAkunI1 { get; set; }
        [Display(Name ="Booking Fee")]
        public int GlAkunID2 { get; set; }
        public virtual GlAccount GlAkunI2 { get; set; }
        [Display(Name ="Angsuran")]
        public int GlAkunID3 { get; set; }
        public virtual GlAccount GlAkunI3 { get; set; }
        [Display(Name ="Payment Credit")]
        public int GlAkunID4 { get; set; }
        public virtual GlAccount GlAkunI4 { get; set; }
        public string GlAkun1 { get; set; }
        public string GlAkun2 { get; set; }
        public string GlAkun3 { get; set; }
        public string GlAkun4 { get; set; }

    }

    public class ApDistribSet
    {
        [Key]
        public int DistribID { get; set; }

        [StringLength(20)]
        [Display(Name = "Distribution Set")]
        public string AkunSet { get; set; }
        [Display(Name = "GL Akun")]
        public int GlAkunID1 { get; set; }
        public virtual GlAccount GlAkunI1 { get; set; }
        [Display(Name = "Booking Fee")]
        public int GlAkunID2 { get; set; }
        public virtual GlAccount GlAkunI2 { get; set; }
        [Display(Name = "Angsuran")]
        public int GlAkunID3 { get; set; }
        public virtual GlAccount GlAkunI3 { get; set; }
        [Display(Name = "Payment Credit")]
        public int GlAkunID4 { get; set; }
        public virtual GlAccount GlAkunI4 { get; set; }
        public string GlAkun1 { get; set; }
        public string GlAkun2 { get; set; }
        public string GlAkun3 { get; set; }
        public string GlAkun4 { get; set; }

    }

    public class ApHutangH
    {
        [Key]
        public int ApHID { get; set; }
        public Guid ApHGd { get; set; }
        public int KodeNo { get; set; }
        [StringLength(20)]
        public string Bukti { get; set; }
        public DateTime Tanggal { get; set; }
        [Display(Name = "Bank")]
        public int BankID { get; set; }
        [Display(Name = "Supplier")]
        public int SupplierID { get; set; }
        public string Keterangan { get; set; }
        public DateTime? JthTempo { get; set; }
        public decimal PPn { get; set; }
        public decimal PPnpersen { get; set; }
        public decimal Brutto { get; set; }
        public decimal Netto { get; set; }
        public decimal Jumlah { get; set; }
        public decimal Hutang { get; set; }
        public decimal Unapplied { get; set; }
        public decimal Diskon { get; set; }
        public virtual ICollection<ApHutangD> HutangDetail { get; set; }
    }

    public class ApHutangD
    {
        [Key]
        public int ApDID { get; set; }
        public Guid ApDGd { get; set; }
        public int KodeNo { get; set; }
        public DateTime Tanggal { get; set; }
        public DateTime? Duedate { get; set; }
        [StringLength(20)]
        public string Bukti { get; set; }
        public int SupplierID { get; set; }
        public string Keterangan { get; set; }
        public Guid ApLPBGd { get; set; }
        public string Lpb { get; set; }
        public string DistribSet { get; set; }
        public int DistribID { get; set; }
        public decimal Jumlah { get; set; }
        public decimal Hutang { get; set; }
        public decimal Bayar { get; set; }
        public decimal Diskon { get; set; }
        public decimal Sisa { get; set; }
        public Guid ApHGd { get; set; }
        public int ApHID { get; set; }
        public virtual ApHutangH ApHutangH { get; set; }

    }

    //
    public class ApTransH
    {
        [Key]
        public int ApHID { get; set; }
        public Guid ApHGd { get; set; }
        public int KodeNo { get; set; }
        [StringLength(20)]
        public string Bukti { get; set; }
        public DateTime Tanggal { get; set; }
        [Display(Name ="Bank")]
        public int BankID { get; set; }
        [Display(Name ="Supplier")]
        public int SupplierID { get; set; }      
        public string Keterangan { get; set; }
        public DateTime? JthTempo { get; set; }
        public decimal PPn { get; set; }
        public decimal PPnpersen { get; set; }
        public decimal Brutto { get; set; }
        public decimal Netto { get; set; }
        public decimal Jumlah { get; set; }
        public decimal Hutang { get; set; }
        public decimal Unapplied { get; set; }
        public decimal Diskon { get; set; }
        public virtual ICollection<ApTransD> TransDetail { get; set; }
    }

    public class ApTransD
    {
        [Key]
        public int ApDID { get; set; }
        public Guid ApDGd { get; set; }
        public DateTime Tanggal { get; set; }
        public DateTime? Duedate { get; set; }
        public string Bukti { get; set; }
        public int SupplierID { get; set; }
        public string Keterangan { get; set; }
        public Guid ApLPBGd { get; set; }
        public string Lpb { get; set; }
        public decimal Jumlah { get; set; }
        public decimal Hutang { get; set; }
        public decimal Bayar { get; set; }
        public decimal Diskon { get; set; }
        public decimal Sisa { get; set; }
        public Guid ApHGd { get; set; }
        public int ApHID { get; set; }
        public virtual ApTransH ApTransH{ get; set; }

    }
}