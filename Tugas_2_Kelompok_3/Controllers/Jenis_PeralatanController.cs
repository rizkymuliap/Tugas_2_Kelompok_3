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


    }
}
