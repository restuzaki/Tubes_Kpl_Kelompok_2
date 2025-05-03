using System;
using MySql.Data.MySqlClient;

namespace tubes_kpl_kelompk2
{
    

    public class UserLogin
    {
        private readonly string connectionString;

        public UserLogin(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User Login()
        {
            Console.Write("Masukkan nama: ");
            string nama = Console.ReadLine();

            Console.Write("Masukkan password: ");
            string password = Console.ReadLine();

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nama, password, role FROM users WHERE nama = @nama AND password = @password";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("Login berhasil.");
                                return new User
                                {
                                    Nama = reader.GetString("nama"),
                                    Password = reader.GetString("password"),
                                    Role = reader.GetString("role")
                                };
                            }
                            else
                            {
                                Console.WriteLine("Nama atau password salah.");
                                return null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Terjadi kesalahan koneksi: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
