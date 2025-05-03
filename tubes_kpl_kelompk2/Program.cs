using System;
using tubes_kpl_kelompk2;

class Program
{
    static void Main()
    {
        string connStr = "Server=localhost;Database=apotik;Uid=root;Pwd=;";
        UserLogin userlogin = new UserLogin(connStr);
        UserRegister userregister = new UserRegister(connStr);

        while (true)
        {
            Console.WriteLine("=== Aplikasi Apotek ===");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Pilih opsi (1/2/3): ");
            string pilihan = Console.ReadLine();

            if (pilihan == "1")
            {
                
                tubes_kpl_kelompk2.User user = userlogin.Login();
                if (user != null)
                {
                    if (user.Role == "admin")
                    {
                        Console.WriteLine("Selamat datang, Admin! Anda dapat mengelola apotek.");
                    }
                    else if (user.Role == "buyer")
                    {
                        Console.WriteLine("Selamat datang, Buyer! Anda dapat melihat produk.");
                    }
                }
            }
            else if (pilihan == "2")
            {
                userregister.Register();
            }
            else if (pilihan == "3")
            {
                Console.WriteLine("Terima kasih telah menggunakan aplikasi apotek.");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid, coba lagi.");
            }

            Console.WriteLine();
        }
    }
}
