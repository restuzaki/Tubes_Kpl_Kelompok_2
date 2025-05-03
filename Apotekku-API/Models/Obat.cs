namespace Apotekku_API.Models
{
    public class Obat
    {
        public string id { get; set; }
        public string nama { get; set; }
        public string status { get; set; }

    
        public Obat(string id, string nama, string status)
        {
            this.id = id;
            this.nama = nama;
            this.status = status;
        }
    }
}