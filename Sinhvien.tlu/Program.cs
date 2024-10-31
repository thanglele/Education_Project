using System;
using System.Management;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Sinhvien.tlu.Login_form;

namespace Sinhvien.tlu
{
    internal static class Program
    {
        static private string GetHardwareInfo(string wmiClass, string wmiProperty)
        {
            string info = "";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {wmiClass}");
                foreach (ManagementObject obj in searcher.Get())
                {
                    info += $"{obj[wmiProperty]}";
                }
            }
            catch (Exception)
            {
                info += null;
            }
            return info;
        }
        [STAThread]
        static public void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Kiểm tra quyền kích hoạt phần mềm
                HttpClient client = new HttpClient();

                HttpResponseMessage response = client.PostAsync("https://api.thanglele08.id.vn/DigitalActive/getActive", new StringContent(System.Text.Json.JsonSerializer.Serialize(new requestActive()
                {
                    keyDActive = GetHardwareInfo("Win32_BaseBoard", "SerialNumber") + "-" + GetHardwareInfo("Win32_BIOS", "SerialNumber"),
                    serialKey = GetHardwareInfo("Win32_Processor", "ProcessorId")
                }), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    respond_Key respond_Key = Newtonsoft.Json.JsonConvert.DeserializeObject<respond_Key>(response.Content.ReadAsStringAsync().Result);
                    if (respond_Key.isActive == false)
                    {
                        MessageBox.Show("Phần mềm bị chặn khởi động từ máy chủ, cảm ơn bạn đã sử dụng phần mềm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                    else
                    {
                        System_Login New_Login = new System_Login();
                        Application.Run(New_Login);
                    }
                }
                else
                {
                    InputUser inputUser = new InputUser();
                    Application.Run(inputUser);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                MessageBox.Show("Mất kết nối tới máy chủ dữ liệu, yêu cầu kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            //System_Login New_Login = new System_Login();
            //Subject_Form listing = new Subject_Form();
            //Form1 new_form = new Form1();
            
            //Application.Exit();
        }
    }
}