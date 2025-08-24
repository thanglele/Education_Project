using System;
using System.Management;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Sinhvien.tlu.Login_form
{
    public partial class InputUser : Form
    {
        private string GetHardwareInfo(string wmiClass, string wmiProperty)
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

        public InputUser()
        {
            InitializeComponent();
        }

        private void Verify_Click(object sender, EventArgs e)
        {
            if (inp_userKey.Text != null)
            {
                HttpClient client = new HttpClient();

                HttpResponseMessage respond = client.PostAsync("https://api.thanglele.cloud/DigitalActive/updateKey", new StringContent(System.Text.Json.JsonSerializer.Serialize(new updateKey()
                {
                    username = inp_userKey.Text,
                    isActive = false,
                    keyDActive = GetHardwareInfo("Win32_BaseBoard", "SerialNumber") + "-" + GetHardwareInfo("Win32_BIOS", "SerialNumber"),
                    serialKey = GetHardwareInfo("Win32_Processor", "ProcessorId")
                }), Encoding.UTF8, "application/json")).Result;
                if(respond.IsSuccessStatusCode == true)
                {
                    respond_Key respond_Key = Newtonsoft.Json.JsonConvert.DeserializeObject<respond_Key>(respond.Content.ReadAsStringAsync().Result);
                    if (respond_Key.isActive == false)
                    {
                        MessageBox.Show("Phần mềm bị chặn khởi động từ máy chủ, cảm ơn bạn đã sử dụng phần mềm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                    else
                    {
                        InitializeComponent();
                        System_Login New_Login = new System_Login();
                        New_Login.Show();
                        this.Visible = false;
                        this.Hide();
                    }
                }    
                else
                {
                    MessageBox.Show("Phần mềm bị chặn khởi động từ máy chủ, cảm ơn bạn đã sử dụng phần mềm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }    
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
