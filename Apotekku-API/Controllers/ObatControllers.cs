using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Apotekku_API.Models;

namespace Apotekku_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObatController : Controller
    {
        private static readonly string jsonFilePath = "Data/Obat.json";

        private List<Obat> BacaDataObat()
        {
            try
            {
                string jsonString = System.IO.File.ReadAllText(jsonFilePath);
                return JsonSerializer.Deserialize<List<Obat>>(jsonString) ?? new List<Obat>();
            }
            catch
            {
                return new List<Obat>();
            }
        }

        private void SimpanDataObat(List<Obat> data)
        {
            string updatedJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);
        }

        [HttpGet]
        public ActionResult<List<Obat>> Get()
        {
            var result = BacaDataObat();
            return Ok(result);
        }

        [HttpGet("{kode}")]
        public ActionResult<Obat> Get(string kode)
        {
            var result = BacaDataObat();
            var obat = result.FirstOrDefault(o => o.id == kode);
            if (obat == null) return NotFound("Obat tidak ditemukan");
            return Ok(obat);
        }

        [HttpPost]
        public ActionResult<Obat> Post([FromBody] Obat obat)
        {
            var result = BacaDataObat();
            if (result.Any(o => o.id == obat.id))
                return Conflict("Obat dengan ID tersebut sudah ada.");

            result.Add(obat);
            SimpanDataObat(result);
            return CreatedAtAction(nameof(Get), new { kode = obat.id }, obat);
        }

        [HttpPut("{kode}")]
        public ActionResult<Obat> Put(string kode, [FromBody] Obat obat)
        {
            var result = BacaDataObat();
            var existingObat = result.FirstOrDefault(o => o.id == kode);
            if (existingObat == null) return NotFound("Obat tidak ditemukan");

            existingObat.nama = obat.nama;
            existingObat.status = obat.status;
            existingObat.harga = obat.harga;
            existingObat.kadaluarsa = obat.kadaluarsa;

            SimpanDataObat(result);
            return Ok(existingObat);
        }

        [HttpDelete("{kode}")]
        public ActionResult Delete(string kode)
        {
            var result = BacaDataObat();
            var obatToDelete = result.FirstOrDefault(o => o.id == kode);
            if (obatToDelete == null) return NotFound("Obat tidak ditemukan");

            result.Remove(obatToDelete);
            SimpanDataObat(result);
            return NoContent();
        }
    }
}
