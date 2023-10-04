using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tugas_2_Kelompok_3.Models;

namespace Tugas_2_Kelompok_3.Controllers
{
    public class PeralatanController : Controller
    {
        private static List<Peralatan> peralatans = InitializeData();
        private static List<Peralatan> InitializeData()
        {
            List<Peralatan> initialData = new List<Peralatan>
            {
                new Peralatan
                {
                    Id = 1,
                    nama_peralatan = "Bola Karet",
                    Id_jenis = 2,
                    deskripsi_peralatan = "Bola karet Mainan motorik hewan",
                    Harga_Beli = 75000,
                    stok = 50,
                    status = 1
                },
                new Peralatan
                {
                    Id = 2,
                    nama_peralatan = "Pet Bowl 26cm",
                    Id_jenis = 1,
                    deskripsi_peralatan = "Tempat Makan Mangkuk Besi",
                    Harga_Beli = 43000,
                    stok = 20,
                    status = 1
                }
            };
            return initialData;
        }

        public IActionResult Index()
        {
            List<Peralatan> peralatanlist = peralatans.ToList();
            return View(peralatanlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            // Buat instansiasi dari Jenis_PeralatanController
            var jenisPeralatanController = new Jenis_PeralatanController();

            // Panggil metode GetJenisPeralatan pada instansiasi tersebut
            List<Jenis_Peralatan> jenisPeralatanList = jenisPeralatanController.GetJenisPeralatan();

            if (jenisPeralatanList != null && jenisPeralatanList.Count > 0)
            {
                // Konversi daftar jenis peralatan menjadi SelectList
                SelectList jenisList = new SelectList(jenisPeralatanList, "Id", "nama_jenis_peralatan");

                // Simpan SelectList dalam ViewBag untuk digunakan di dalam view
                ViewBag.JenisList = jenisList;
            }
            else
            {
                // Handle jika daftar jenis peralatan kosong atau null
                ViewBag.JenisList = new SelectList(new List<SelectListItem>());
                TempData["ErrorMessage"] = "Tidak ada jenis peralatan yang tersedia.";
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(Peralatan peralatan)
        {
            if (ModelState.IsValid)
            {
                int new_id = 1;

                while (peralatans.Any(b => b.Id == new_id))
                {
                    new_id++;
                }

                peralatan.Id = new_id;
                peralatan.status = 1;

                peralatans.Add(peralatan);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }

            return View(peralatan);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus jenis peralatan." };

            try
            {
                var jenis_peralatan = peralatans.FirstOrDefault(b => b.Id == id);
                if (jenis_peralatan != null)
                {
                    peralatans.Remove(jenis_peralatan);
                    response = new { success = true, message = "Peralatan berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Peralatan tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }

            return Json(response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Peralatan peralatan = peralatans.FirstOrDefault(b => b.Id == id);

            if (peralatan == null)
            {
                return NotFound();
            }

            return View(peralatan);
        }

        [HttpPost]
        public IActionResult Edit(Peralatan peralatan)
        {
            if (ModelState.IsValid)
            {
                Peralatan new_Peralatan = peralatans.FirstOrDefault(b => b.Id == peralatan.Id);

                if (new_Peralatan == null)
                {
                    return NotFound();
                }

                new_Peralatan.nama_peralatan = peralatan.nama_peralatan;
                new_Peralatan.deskripsi_peralatan = peralatan.deskripsi_peralatan;
                new_Peralatan.Harga_Beli = peralatan.Harga_Beli;
                new_Peralatan.Id_jenis = peralatan.Id_jenis;
                new_Peralatan.stok = peralatan.stok;

                TempData["SuccessMessage"] = "Peralatan berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(peralatan);
        }

    }
}
