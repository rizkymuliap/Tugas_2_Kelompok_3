using System.ComponentModel.DataAnnotations;

namespace Tugas_2_Kelompok_3.Models
{
    public class Jenis_Peralatan
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama jenis peralaltan wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Nama jenis peralatan maksimal 30 karakter.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Nama jenis peralatan hanya boleh berisi huruf.")]
        public string nama_jenis_peralatan { get; set; }

        [Required(ErrorMessage = "Deskripsi jenis peralatan wajib diisi.")]
        [MaxLength(50, ErrorMessage = "Deskripsi jenis peralatan maksimal 50 karakter.")]
        public string deskripsi_jenis_peralatan { get; set; }

        [Range(0, 1, ErrorMessage = "Status tidak valid.")]
        public int status { get; set; }
    }
}
