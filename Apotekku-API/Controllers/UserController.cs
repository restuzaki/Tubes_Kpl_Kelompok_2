using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using Apotekku_API.Models;


namespace Apotekku_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string jsonFilePath = "Data/User.json";

        private List<User> BacaDataUser()
        {
            try
            {
                string jsonString = System.IO.File.ReadAllText(jsonFilePath);
                return JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
            }
            catch
            {
                return new List<User>();
            }
        }

        private void SimpanDataUser(List<User> data)
        {
            string updatedJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonFilePath, updatedJson);
        }

        
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = BacaDataUser();
            return Ok(users);
        }

        
        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            var users = BacaDataUser();

            if (users.Any(u => u.Nama == newUser.Nama))
                return BadRequest("User sudah ada");

            newUser.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            users.Add(newUser);
            SimpanDataUser(users);
            return Ok(newUser);
        }

        
        [HttpPost("login")]
        public IActionResult Login(User login)
        {
            var users = BacaDataUser();
            var user = users.FirstOrDefault(u => u.Nama == login.Nama && u.Password == login.Password);

            if (user == null)
                return Unauthorized("Nama atau password salah");

            return Ok(user);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, User updatedUser)
        {
            var users = BacaDataUser();
            var userIndex = users.FindIndex(u => u.Id == id);

            if (userIndex == -1)
                return NotFound("User tidak ditemukan");

            updatedUser.Id = id;
            users[userIndex] = updatedUser;
            SimpanDataUser(users);
            return Ok(updatedUser);
        }
    }
}