using Microsoft.AspNetCore.Mvc;
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
                    nama_peralatan = "Boyolali",
                    deskripsi_peralatan = "Roni Prasetyo",
                    status = 1
                },
                new Peralatan
                {
                    Id = 2,
                    nama_peralatan = "Boyolali",
                    deskripsi_peralatan = "Roni Prasetyo",
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
                    response = new { success = true, message = "Jenis peralatan berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Jenis peralatan tidak ditemukan." };
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

                TempData["SuccessMessage"] = "Peralatan berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(peralatan);
        }

    }
}
