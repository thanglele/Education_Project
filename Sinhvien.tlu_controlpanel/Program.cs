//SERVER PROGRAM

using System.Runtime.CompilerServices;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Data.SqlClient;

namespace Sinhvien.tlu_controlpanel
{
    internal class Program
    {
        private static string sql_server = "Server=localhost\\THANGLELE_SQL;Database=sinhvien_tlu;Trusted_Connection=True;";
        //private static string sql_server = "Data Source=172.188.28.154;Database=sinhvien_tlu;User ID=tluedu_application;Password=LeTh@ng2884;Connect Timeout=30;";

        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 49153;
        //private const string IP_NUMBER = "10.0.0.5";
        private const string IP_NUMBER = "127.0.0.1";
        const int MAXCONNECTION = 10;
        static int MEMCONNECTION = 0;

        static ASCIIEncoding encoding = new ASCIIEncoding();

        static IPAddress address = IPAddress.Parse(IP_NUMBER);
        static TcpListener listener = new TcpListener(address, PORT_NUMBER);

        static bool status_connect_database()
        {
            using (SqlConnection connection = new SqlConnection(sql_server))
            {
                try
                {
                    connection.Open();

                    return true;
                }

                catch (Exception)
                {
                    return false;
                }
            }
        }
        static void database_connect_task()
        {
            while (!status_connect_database())
            {
                Console.WriteLine("Ket noi co so du lieu that bai! Dang tien hanh ket noi lai...");
                Thread.Sleep(10000);
                status_connect_database();
            }

            Console.WriteLine("Ket noi co so du lieu thanh cong!");
        }

        static private string login(string USR_inp, string PASS_inp)
        {
            using (SqlConnection connection = new SqlConnection(sql_server))
            {
                try
                {
                    // Mở kết nối đến cơ sở dữ liệu
                    connection.Open();

                    // Tạo câu lệnh SQL để truy vấn thông tin đăng nhập
                    string query = "SELECT MID FROM login_information WHERE ID = @Username AND Password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu lệnh SQL để tránh các vấn đề an toàn dữ liệu
                        command.Parameters.AddWithValue("@Username", USR_inp);
                        command.Parameters.AddWithValue("@Password", PASS_inp);

                        // Thực thi truy vấn và trả về số lượng hàng phù hợp
                        string MID = Convert.ToString((int)command.ExecuteScalar());

                        Console.WriteLine("MID: " + MID);

                        return MID;
                    }
                }
                catch (Exception)
                {
                    return "0";
                }
            }
        }

        static void process()
        {
            Socket socket = listener.AcceptSocket();
            string IP_client = Convert.ToString(socket.RemoteEndPoint);

            Console.WriteLine("Ket noi tu Client-IP: " + IP_client);
            MEMCONNECTION--;

            var stream = new NetworkStream(socket);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            try
            {
                while (true)
                {
                    //receive
                    string status = reader.ReadLine();

                    if (status == "LOGIN")
                    {
                        Console.WriteLine(IP_client + ": Dang thuc hien thao tac dang nhap!");
                        string USR_inp = reader.ReadLine();
                        string PASS_inp = reader.ReadLine();

                        Console.WriteLine("USR:" + USR_inp);
                        Console.WriteLine("PASS:" + PASS_inp);

                        string MID = login(USR_inp, PASS_inp);
                        if (MID == "5" || MID == "0")
                        {
                            Console.WriteLine(IP_client + ": Dang nhap that bai, yeu cau dang nhap lai...");
                        }
                        else
                        {
                            Console.WriteLine(IP_client + ": Dang nhap thanh cong, bat dau truy xuat thong tin cho Client...");
                            Console.WriteLine("ID dang nhap: " + USR_inp);
                        }

                        //send
                        writer.WriteLine(MID);
                    }

                    if (status == "MAINBOARD")
                    {
                        Console.WriteLine(IP_client + ": Dang thuc hien thao tac nhan thong tin tai khoan");
                    }

                    if (status == "EXIT")
                    {
                        Console.WriteLine(IP_client + ": Client thuc hien thao tac thoat hoac dang xuat!");
                        Console.WriteLine(IP_client + ": Server thuc hien thao tac dong ket noi...");
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Loi ket noi den Client. Thoat ket noi...");
            }
            finally
            {
                //close
                //stream.Close();
                socket.Close();
                //listener.Stop();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Chuong trinh quan ly server Sinhvien.tlu.edu.vn");
            Console.WriteLine("===============================================");

            Console.WriteLine("Dang ket noi den co so du lieu...");
            database_connect_task();

            Console.WriteLine("Dang thiet lap cong ket noi den Client...");

            //IPAddress address = IPAddress.Parse(IP_NUMBER);
            //TcpListener listener = new TcpListener(address, PORT_NUMBER);

            //Listen
            listener.Start();

            Console.WriteLine("Dia chi ip ket noi: " + listener.LocalEndpoint);
            Console.WriteLine("Dang doi tin hieu tu Client...");

            bool check_done = false;
            while (true) //Check around
            {
                if (MEMCONNECTION < MAXCONNECTION)
                {
                    Thread t = new Thread(() => process());
                    t.Start();
                    MEMCONNECTION++;

                    Console.WriteLine("SLOT MEM: " + MEMCONNECTION);

                    if (check_done)
                    {
                        Thread.Sleep(10000);
                    }
                }
                else
                {
                    Thread.Sleep(10000);
                    check_done = true;
                }
            }
        }
    }
}