using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tugas_2_Kelompok_3.Models;

namespace Tugas_2_Kelompok_3.Controllers;

public class TransaksiController : Controller
{
    private static List<Transaksi> transaksi = InitializeData();

    private static List<Transaksi> InitializeData()
    {
        List<Transaksi> initialData = new List<Transaksi>
    {
        new Transaksi
        {
            Id_trs = 1,
            ID_Peralatan = 2,
            Tanggal_Transaksi = DateTime.Now,
            Jenis_Transaksi = "Penjualan",
            Jumlah_Item = 5,
            Total_Harga = 215000,
            Nama_Pelanggan = "John Doe",
            Metode_Pembayaran = "Transfer Bank",
            Status_Pengiriman = "Dalam Pengiriman",
            Alamat_Pengiriman = "Jl. Pemuda Bersinar No. 123"
        },
        new Transaksi
        {
            Id_trs = 2,
            ID_Peralatan = 1,
            Tanggal_Transaksi = DateTime.Now,
            Jenis_Transaksi = "Penjualan",
            Jumlah_Item = 3,
            Total_Harga = 225000,
            Nama_Pelanggan = "Jane Smith",
            Metode_Pembayaran = "Kartu Kredit",
            Status_Pengiriman = "Diterima",
            Alamat_Pengiriman = "Jl. Pendidikan Maju No. 456"
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

            while (transaksi.Any(b => b.Id_trs == new_id))
            {
                new_id++;
            }

            trs.Id_trs = new_id;
            trs.status = 1;

            transaksi.Add(trs);
            TempData["SuccessMessage"] = "Data berhasil ditambahkan";
            return RedirectToAction("Index");
        }
        return View(trs);
    }
}