using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Apotekku_API.Models;

namespace Apotekku_API.Models
{
    public class BacaResep
    {
        public static List<Obat> AmbilDataObat(string pathFileJson)
        {
            string jsonContent = File.ReadAllText(pathFileJson);
            return JsonSerializer.Deserialize<List<Obat>>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
