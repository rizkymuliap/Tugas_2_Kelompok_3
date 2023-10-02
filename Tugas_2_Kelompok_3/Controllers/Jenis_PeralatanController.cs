using Microsoft.AspNetCore.Mvc;
using Tugas_2_Kelompok_3.Models;

namespace Tugas_2_Kelompok_3.Controllers
{
    public class Jenis_PeralatanController : Controller
    {
        private static List<Jenis_Peralatan> jenis_Peralatans = InitializeData();

        private static List<Jenis_Peralatan> InitializeData()
        {
            List<Jenis_Peralatan> initialData = new List<Jenis_Peralatan>
            {
                new Jenis_Peralatan
                {
                    Id = 1,
                    nama_jenis_peralatan = "Boyolali",
                    deskripsi_jenis_peralatan = "Roni Prasetyo",
                    status = 1
                },
                new Jenis_Peralatan
                {
                    Id = 2,
                    nama_jenis_peralatan = "Boyolali",
                    deskripsi_jenis_peralatan = "Roni Prasetyo",
                    status = 1
                }
            };
            return initialData;
        }
        public IActionResult Index()
        {
            List<Jenis_Peralatan> jenis_Peralatanlist = jenis_Peralatans.ToList();
            return View(jenis_Peralatanlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Jenis_Peralatan jenis_peralatan)
        {
            if (ModelState.IsValid)
            {
                int new_id = 1;

                while (jenis_Peralatans.Any(b => b.Id == new_id))
                {
                    new_id++;
                }

                jenis_peralatan.Id = new_id;
                jenis_peralatan.status = 1;

                jenis_Peralatans.Add(jenis_peralatan);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }

            return View(jenis_peralatan);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus jenis peralatan." };

            try
            {
                var jenis_peralatan = jenis_Peralatans.FirstOrDefault(b => b.Id == id);
                if (jenis_peralatan != null)
                {
                    jenis_Peralatans.Remove(jenis_peralatan);
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
            Jenis_Peralatan jenis_Peralatan = jenis_Peralatans.FirstOrDefault(b => b.Id == id);

            if (jenis_Peralatan == null)
            {
                return NotFound();
            }

            return View(jenis_Peralatan);
        }

        [HttpPost]
        public IActionResult Edit(Jenis_Peralatan jenis_Peralatan)
        {
            if (ModelState.IsValid)
            {
                Jenis_Peralatan newJenis_Peralatan = jenis_Peralatans.FirstOrDefault(b => b.Id == jenis_Peralatan.Id);

                if (newJenis_Peralatan == null)
                {
                    return NotFound();
                }

                newJenis_Peralatan.nama_jenis_peralatan = jenis_Peralatan.nama_jenis_peralatan;
                newJenis_Peralatan.deskripsi_jenis_peralatan = jenis_Peralatan.deskripsi_jenis_peralatan;

                TempData["SuccessMessage"] = "Jenis peralatan berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(jenis_Peralatan);
        }


    }
}
