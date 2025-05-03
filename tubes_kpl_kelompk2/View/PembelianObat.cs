using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class PembelianObat
{
    private List<Obat> daftarObatConfig;
    private List<Obat> pembelianUser;
    public PembelianObat()
    {
        daftarObatConfig = FetchMedicinesFromConfig();
        pembelianUser = new List<Obat>();
    }
    private List<Obat> FetchMedicinesFromConfig()
    {
        var json = File.ReadAllText("Obat.json");
        var medicines = JsonConvert.DeserializeObject<List<Obat>>(json);

        foreach (var medicine in medicines)
        {
            medicine.tanggalPembelian = DateTime.Now;
        }

        return medicines;
    }

    public async Task<bool> IsObatValidAsync(string namaObat)
    {
        return await Task.FromResult(daftarObatConfig.Any(o => o.namaObat.Equals(namaObat, StringComparison.OrdinalIgnoreCase)));
    }
    public void TambahObat(string nama, int jumlah, decimal harga, DateTime tanggal)
    {
        if (string.IsNullOrWhiteSpace(nama)) throw new ArgumentException("Nama obat tidak boleh kosong.");
        if (jumlah <= 0) throw new ArgumentException("Jumlah harus lebih dari 0.");
        if (harga <= 0) throw new ArgumentException("Harga harus lebih dari 0.");

        int countBefore = pembelianUser.Count;

        pembelianUser.Add(new Obat
        {
            namaObat = nama,
            jumlah = jumlah,
            hargaSatuan = harga,
            tanggalPembelian = tanggal
        });
    }
    public decimal? GetHargaObat(string namaObat)
    {
        var obat = daftarObatConfig.FirstOrDefault(o => o.namaObat.Equals(namaObat, StringComparison.OrdinalIgnoreCase));
        return obat?.hargaSatuan;
    }
    public IEnumerable<Obat> GetObats()
    {
        return pembelianUser;
    }
    public IEnumerable<Obat> GetObatsFromAPI()
    {
        return daftarObatConfig;
    }

}
