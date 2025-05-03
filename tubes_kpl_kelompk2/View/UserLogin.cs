using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Apotekku_API.Models;

public class UserLogin
{
    private readonly string jsonFilePath = "Data/User.json";

    public User Login()
    {
        Console.Write("Masukkan nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan password: ");
        string password = Console.ReadLine();

        var users = LoadUsers();

        var user = users.FirstOrDefault(u => u.Nama == nama && u.Password == password);
        if (user != null)
        {
            Console.WriteLine($"Login berhasil. Selamat datang, {user.Nama} dengan role {user.Role}.");
            return user;
        }
        else
        {
            Console.WriteLine("Nama atau password salah.");
            return null;
        }
    }

    private List<User> LoadUsers()
    {
        try
        {
            string json = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Gagal membaca file JSON: " + ex.Message);
            return new List<User>();
        }
    }
}
