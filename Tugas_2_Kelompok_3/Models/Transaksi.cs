using System.ComponentModel.DataAnnotations;
namespace Tugas_2_Kelompok_3.Models
{
    using System;

    public class Transaksi
    {
        
        public int Id { get; set; }

        public int ID_Peralatan { get; set; }

        public DateTime Tanggal_Transaksi { get; set; }

        public string Jenis_Transaksi { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Jumlah Item hanya boleh diisi dengan angka.")]
        public int Jumlah_Item { get; set; }
   
        public int Total_Harga { get; set; }

        [Required(ErrorMessage = "Nama Pelanggan wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Nama Pelanggan maksimal 30 karakter.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Nama Pelanggan hanya boleh berisi huruf.")]
        public string Nama_Pelanggan { get; set; }

        [Required(ErrorMessage = "Metode Pembayaran wajib diisi.")]
        public string Metode_Pembayaran { get; set; }

        [Required(ErrorMessage = "Status Pengiriman wajib diisi.")]
        public string Status_Pengiriman { get; set; }

        [Required(ErrorMessage = "Alamat Pengiriman wajib diisi.")]
        public string Alamat_Pengiriman { get; set; }
    }
}
