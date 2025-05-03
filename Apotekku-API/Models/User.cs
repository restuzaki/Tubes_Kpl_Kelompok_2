using System;
using System.ComponentModel.DataAnnotations;

namespace Apotekku_API.Models
{
    public class User
    {
        public int Id { get; set; }

        
        public string Nama { get; set; }

        
        public string Password { get; set; }

        
        public string Role { get; set; }

        public User(string nama, string password, string role)
        {
            Nama = nama;
            Password = password;
            Role = role;
        }
    }
}

