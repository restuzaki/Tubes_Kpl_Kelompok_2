using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Apotekku_API.Models;

namespace Apotekku_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObatController : Controller
    {
        private static string jsonFilePath = "Data/Obat.json";
        private static List<Obat> dataObat;

        [HttpGet]
        public ActionResult<List<Obat>> Get()
        {
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var result = JsonSerializer.Deserialize<List<Obat>>(jsonString);

            if (result == null)
            {
                result = new List<Obat>();
            }

            return Ok(result);
        }

        [HttpGet("{kode}")]
        public ActionResult<Obat> Get(string kode)
        {
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var result = JsonSerializer.Deserialize<List<Obat>>(jsonString);

            if (result == null)
            {
                result = new List<Obat>();
            }

            Obat obat = null;

            
            foreach (var item in result)
            {
                if (item.id == kode)
                {
                    obat = item;
                    break; 
                }
            }

            if (obat == null)
            {
                return NotFound("Obat tidak ditemukan");
            }

            return Ok(obat);
        }

        [HttpPost]
        public ActionResult<Obat> Post([FromBody] Obat obat)
        {
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var result = JsonSerializer.Deserialize<List<Obat>>(jsonString);
            if (result == null)
            {
                result = new List<Obat>();
            }

            result.Add(obat);

            string updatedJson = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);

            return CreatedAtAction(nameof(Get), new { kode = obat.id }, obat);
        }

        [HttpPut("{kode}")]
        public ActionResult<Obat> Put(string kode, [FromBody] Obat obat)
        {
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var result = JsonSerializer.Deserialize<List<Obat>>(jsonString);

            if (result == null)
            {
                result = new List<Obat>();
            }

            Obat existingObat = null;
            foreach (var item in result)
            {
                if (item.id == kode)
                {
                    existingObat = item;
                    break;
                }
            }

            if (existingObat == null)
            {
                return NotFound("Obat tidak ditemukan");
            }

            existingObat.nama = obat.nama;
            existingObat.status = obat.status;

            string updatedJson = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);

            return Ok(existingObat);
        }

        [HttpDelete("{kode}")]
        public ActionResult Delete(string kode)
        {
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var result = JsonSerializer.Deserialize<List<Obat>>(jsonString);

            if (result == null)
            {
                result = new List<Obat>();
            }

            Obat obatToDelete = null;
            foreach (var item in result)
            {
                if (item.id == kode)
                {
                    obatToDelete = item;
                    break;
                }
            }

            if (obatToDelete == null)
            {
                return NotFound("Obat tidak ditemukan");
            }

            result.Remove(obatToDelete);

            string updatedJson = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);

            return NoContent();
        }
    }
}
