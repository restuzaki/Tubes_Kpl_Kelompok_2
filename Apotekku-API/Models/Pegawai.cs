namespace Apotekku_API.Models
{
    public class Pegawai
    {
        public string id { get; set; }
        public string nama { get; set; }
        public string jabatan { get; set; }
        public string status { get; set; }

       
        public Pegawai(string id, string nama, string jabatan, string status)
        {
            this.id = id;
            this.nama = nama;
            this.jabatan = jabatan;
            this.status = status;
        }
    }
}