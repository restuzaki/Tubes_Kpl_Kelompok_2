using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Apotekku_API.Models;

public class UserRegister
{
    private readonly string jsonFilePath = "Data/User.json";

    public void Register()
    {
        Console.Write("Masukkan nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan password: ");
        string password = Console.ReadLine();

        var users = LoadUsers();

        if (users.Any(u => u.Nama == nama))
        {
            Console.WriteLine("Username sudah digunakan.");
            return;
        }

        var newUser = new User(nama, password, "buyer")
        {
            Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1,
            Nama = nama,
            Password = password,
            Role = "buyer"
        };

        users.Add(newUser);
        SaveUsers(users);

        Console.WriteLine("Registrasi berhasil sebagai buyer.");
    }

    private List<User> LoadUsers()
    {
        try
        {
            string json = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        catch
        {
            return new List<User>();
        }
    }

    private void SaveUsers(List<User> users)
    {
        string updatedJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(jsonFilePath, updatedJson);
    }
}
