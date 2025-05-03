using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Apotekku_API.Models;

namespace Apotekku_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BacaResepController : ControllerBase
    {
        private static readonly string filePath = "Data/Obat.json";

        [HttpGet]
        public ActionResult<List<Obat>> GetAllObat()
        {
            var data = BacaResep.AmbilDataObat(filePath);
            if (data == null || data.Count == 0)
            {
                return NotFound("Data obat tidak ditemukan atau kosong.");
            }

            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<Obat> GetObatById(string id)
        {
            var data = BacaResep.AmbilDataObat(filePath);
            var obat = data?.Find(o => o.id == id);

            if (obat == null)
            {
                return NotFound($"Obat dengan ID '{id}' tidak ditemukan.");
            }

            return Ok(obat);
        }
    }
}
