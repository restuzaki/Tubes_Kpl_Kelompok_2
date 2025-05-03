using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



    

    public class UserRegister
    {
        private readonly string connectionString;

        public UserRegister(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Register()
        {
            Console.Write("Masukkan nama: ");
            string nama = Console.ReadLine();

            Console.Write("Masukkan password: ");
            string password = Console.ReadLine();

            
            string role = "buyer";

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE nama = @nama";
                    using (var cmd = new MySqlCommand(checkQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);

                        var count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            Console.WriteLine("Username sudah digunakan.");
                            return;
                        }
                    }

                    
                    string query = "INSERT INTO users (nama, password, role) VALUES (@nama, @password, @role)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@password", password);  
                        cmd.Parameters.AddWithValue("@role", role);

                        cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine("Registrasi berhasil sebagai buyer.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                }
            }
        }
    }

