using System;

namespace Apotekku_API.Models
{
    public class Obat
    {
        public string id { get; set; }
        public string nama { get; set; }
        public string status { get; set; }
        public int harga { get; set; }
        public string kadaluarsa { get; set; }
        public int stok { get; set; }
    }
}
