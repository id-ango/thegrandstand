﻿using System;
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
         public int BankID { get; set; }

    }

    public class CbTransD
    {
        [Key]
        public int CbTransdID { get; set; }
        public int CbTranshID { get; set; }
        [StringLength(20)]
        public string NoRef { get; set; }
        public DateTime Tanggal { get; set; }
        public decimal Jumlah { get; set; }

        [StringLength(10)]
        public string KodeAkun { get; set; }
        [StringLength(100)]
        public string Label { get; set; }
       

    }

    public class CbTrans
    {
        [Key]
        public int TransID { get; set; }    // sama dengan no kodetrans ArPiutang

        [StringLength(20)]
        [Display(Name = "No Ref")]
        public string NoRef { get; set; }    //sama dengan no Dokumen di AptSPesanan

        [Display(Name = "Tanggal")]
        public DateTime Tanggal { get; set; }       // Tanggal Transaksi


        public int UnitID { get; set; }         // Unit No 
        public virtual AptUnit AptUnit { get; set; }

        public int PersonID { get; set; }         //customer atau Supplier


        public int MarketingID { get; set; }
        public virtual AptMarketing AptMarketing { get; set; }

        [StringLength(250)]
        public string Keterangan { get; set; }

        [Display(Name = "Jumlah Bayar")]
        public decimal Payment { get; set; }            // Jumlah Pembayaran

        [Display(Name = "Cara Bayar")]
        public int PaymentID { get; set; }                // jenis pembayaran Tunai,Debet
        public virtual AptPayment AptPayment { get; set; }

        public int BankID { get; set; }

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

        public static implicit operator CbTrans(ArCustomer v)
        {
            throw new NotImplementedException();
        }
    }
}