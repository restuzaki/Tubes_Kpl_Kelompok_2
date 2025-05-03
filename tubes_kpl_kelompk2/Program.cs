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
                    Console.WriteLine($"\nSelamat datang, {user.Nama}!");

                    if (user.Role == "admin")
                    {
                        while (true)
                        {
                            Console.WriteLine("\n=== Menu Admin ===");
                            Console.WriteLine("1. Lihat Stok Obat");
                            Console.WriteLine("2. Management Member Apotek");
                            Console.WriteLine("3. Management Pemasukan");
                            Console.WriteLine("4. Pengeluaran Apotek");
                            Console.WriteLine("5. Analisis Penyakit Bulanan");
                            Console.WriteLine("6. Pengecekan Izin Obat");
                            Console.WriteLine("7. Management Pegawai");
                            Console.WriteLine("8. Sistem Riwayat Pembelian");
                            Console.WriteLine("9. Logout");
                            Console.Write("Pilih opsi: ");
                            string adminChoice = Console.ReadLine();

                            switch (adminChoice)
                            {
                                case "1":
                                    Console.WriteLine("Fitur Lihat Stok Obat belum diimplementasikan.");
                                    break;
                                case "2":
                                    Console.WriteLine("Fitur Management Member Apotek belum diimplementasikan.");
                                    break;
                                case "3":
                                    Console.WriteLine("Fitur Management Pemasukan belum diimplementasikan.");
                                    break;
                                case "4":
                                    Console.WriteLine("Fitur Pengeluaran Apotek belum diimplementasikan.");
                                    break;
                                case "5":
                                    Console.WriteLine("Fitur Analisis Penyakit Bulanan belum diimplementasikan.");
                                    break;
                                case "6":
                                    Console.WriteLine("Fitur Pengecekan Izin Obat belum diimplementasikan.");
                                    break;
                                case "7":
                                    Console.WriteLine("Fitur Management Pegawai belum diimplementasikan.");
                                    break;
                                case "8":
                                    Console.WriteLine("Fitur Sistem Riwayat Pembelian belum diimplementasikan.");
                                    break;
                                case "9":
                                    Console.WriteLine("Logout berhasil.\n");
                                    break;
                                default:
                                    Console.WriteLine("Pilihan tidak valid, coba lagi.");
                                    break;
                            }

                            if (adminChoice == "9")
                                break;
                        }
                    }
                    else if (user.Role == "buyer")
                    {
                        while (true)
                        {
                            Console.WriteLine("\n=== Menu Buyer ===");
                            Console.WriteLine("1. Lihat Produk");
                            Console.WriteLine("2. Beli Obat");
                            Console.WriteLine("3. ChatBot");
                            Console.WriteLine("4. Sistem Baca Resep");
                            Console.WriteLine("5. Logout");
                            Console.Write("Pilih opsi: ");
                            string buyerChoice = Console.ReadLine();

                            switch (buyerChoice)
                            {
                                case "1":
                                    Console.WriteLine("Fitur Lihat Produk belum diimplementasikan.");
                                    break;
                                case "2":
                                    Console.WriteLine("Fitur Beli Obat belum diimplementasikan.");
                                    break;
                                case "3":
                                    Console.WriteLine("Fitur ChatBot belum diimplementasikan.");
                                    break;
                                case "4":
                                    Console.WriteLine("Fitur Sistem Baca Resep belum diimplementasikan.");
                                    break;
                                case "5":
                                    Console.WriteLine("Logout berhasil.\n");
                                    break;
                                default:
                                    Console.WriteLine("Pilihan tidak valid, coba lagi.");
                                    break;
                            }

                            if (buyerChoice == "5")
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Role tidak dikenali.");
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
