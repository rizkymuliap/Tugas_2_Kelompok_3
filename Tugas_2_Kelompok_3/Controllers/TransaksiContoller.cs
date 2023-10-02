using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tugas_2_Kelompok_3.Models;

namespace Tugas_2_Kelompok_3.Controllers

public class Transaksi : Controller
{
    private static List<Transaksi> transaksi = InitializeData();

    private static List<Transaksi> InitializeData()
    {
        List<Transaksi> initialData = new List<Transaksi>
    {
        new Transaksi
        {
            Id = 1,
            Id_peralatan = 1,
            Tanggal_trs = DateTime.Now,
            jumlah_item = 1,
            total_harga = 100000,
            nama_pelanggan = "Roni Prasetyo",
            metode_pembayaran = "via transfer",
            status_pengiriman = "J&T",
            alamat = "Boyolali"
        },
        new Transaksi
        {
            Id = 2,
            Id_peralatan = 2,
            Tanggal_trs = DateTime.Now,
            jumlah_item = 1,
            total_harga = 200000, 
            nama_pelanggan = "Roni Prasetyo",
            metode_pembayaran = "tunai",
            status_pengiriman = "EXPRESS",
            alamat = "Boyolali"
        }
    };
        return initialData;
    }
    public IActionResult Index()
    {
        List<Transaksi> Transaksi_List = transaksi.ToList();
        return View(Transaksi_List);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Transaksi trs)
    {
        if (ModelState.IsValid)
        {
            int new_id = 1;

            while (transaksi.Any(b => b.Id == new_id))
            {
                new_id++;
            }

            trs.Id = new_id;
            trs.status = 1;

            transaksi.Add(trs);
            TempData["SuccessMessage"] = "Data berhasil ditambahkan";
            return RedirectToAction("Index");
        }
        return View(trs);
    }
}
