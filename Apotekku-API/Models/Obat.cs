using System;

namespace Apotekku_API.Models
{
    public class Obat
    {
        public string id { get; set; }
        public string nama { get; set; }
        public string status { get; set; }
        public int harga { get; set; }
        public DateTime? kadaluarsa { get; set; }

        public Obat(string id, string nama, string status, int harga, DateTime? kadaluarsa)
        {
            this.id = id;
            this.nama = nama;
            this.status = status;
            this.harga = harga;
            this.kadaluarsa = kadaluarsa;
        }

        public Obat() { }
    }
}
