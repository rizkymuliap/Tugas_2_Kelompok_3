using System.ComponentModel.DataAnnotations;

namespace Tugas_2_Kelompok_3.Models
{
    public class Peralatan
    {
        public int Id { get; set; }

        public int Id_jenis {  get; set; }

        [Required(ErrorMessage = "Nama peralatan wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Nama peralatan maksimal 30 karakter.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Nama peralatan hanya boleh berisi huruf.")]
        public string nama_peralatan { get; set; }

        [Required(ErrorMessage = "Deskripsi peralatan wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Deskripsi peralatan maksimal 50 karakter.")]
        public string deskripsi_peralatan { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Harga hanya boleh diisi dengan angka.")]
        public int Harga_Beli {  get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Stok hanya boleh diisi dengan angka.")]
        public int stok { get; set; }

        [Range(0, 1, ErrorMessage = "Status tidak valid.")]
        public int status { get; set; }
    }
}
