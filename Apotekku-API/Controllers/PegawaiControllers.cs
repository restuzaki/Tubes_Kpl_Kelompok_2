using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Apotekku_API.Models;

namespace Apotekku_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PegawaiController : Controller
    {
        private static string jsonFilePath = "Data/Pegawai.json";
        private static List<Pegawai> dataPegawai;

        [HttpGet]
        public ActionResult<List<Pegawai>> Get()
        {
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var result = JsonSerializer.Deserialize<List<Pegawai>>(jsonString);

            if (result == null)
            {
                result = new List<Pegawai>();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Pegawai> Get(string id)
        {
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var result = JsonSerializer.Deserialize<List<Pegawai>>(jsonString);

            if (result == null)
            {
                result = new List<Pegawai>();
            }

            Pegawai pegawai = null;

            foreach (var item in result)
            {
                if (item.id == id)
                {
                    pegawai = item;
                    break;
                }
            }

            if (pegawai == null)
            {
                return NotFound("Pegawai tidak ditemukan");
            }

            return Ok(pegawai);
        }

        [HttpPost]
        public ActionResult<Pegawai> Post([FromBody] Pegawai pegawai)
        {
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var result = JsonSerializer.Deserialize<List<Pegawai>>(jsonString);
            if (result == null)
            {
                result = new List<Pegawai>();
            }

            result.Add(pegawai);

            string updatedJson = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);

            return CreatedAtAction(nameof(Get), new { id = pegawai.id }, pegawai);
        }

        [HttpPut("{id}")]
        public ActionResult<Pegawai> Put(string id, [FromBody] Pegawai pegawai)
        {
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var result = JsonSerializer.Deserialize<List<Pegawai>>(jsonString);

            if (result == null)
            {
                result = new List<Pegawai>();
            }

            Pegawai existingPegawai = null;
            foreach (var item in result)
            {
                if (item.id == id)
                {
                    existingPegawai = item;
                    break;
                }
            }

            if (existingPegawai == null)
            {
                return NotFound("Pegawai tidak ditemukan");
            }

            existingPegawai.nama = pegawai.nama;
            existingPegawai.jabatan = pegawai.jabatan;
            existingPegawai.status = pegawai.status;

            string updatedJson = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);

            return Ok(existingPegawai);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var result = JsonSerializer.Deserialize<List<Pegawai>>(jsonString);

            if (result == null)
            {
                result = new List<Pegawai>();
            }

            Pegawai pegawaiToDelete = null;
            foreach (var item in result)
            {
                if (item.id == id)
                {
                    pegawaiToDelete = item;
                    break;
                }
            }

            if (pegawaiToDelete == null)
            {
                return NotFound("Pegawai tidak ditemukan");
            }

            result.Remove(pegawaiToDelete);

            string updatedJson = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);

            return NoContent();
        }
    }
}
