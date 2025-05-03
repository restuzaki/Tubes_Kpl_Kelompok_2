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

        public class PenyakitAnalisisController : Controller
        {
            [HttpGet]
            public ActionResult<List<PenyakitAnalisis>> Get()
            {
                string jsonString = System.IO.File.ReadAllText("Data/PenyakitAnalisis.json");
                var result = JsonSerializer.Deserialize<List<PenyakitAnalisis>>(jsonString);
                if (result == null)
                {
                    result = new List<PenyakitAnalisis>();
                }
                return Ok(result);
            }
            

        }
    }