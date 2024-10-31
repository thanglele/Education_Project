using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using Sinhvien.tlu.Mainboard;
using System.Collections.Generic;
using System.Net;
using System.ComponentModel;

namespace Sinhvien.tlu.Login_form
{
    public partial class System_Login : Form
    {
        Update Update_task = new Update();
        private bool blockUI = false;
        public string server, port;
        public string Work_path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Education\\";
        private DateTime now = DateTime.Now.Date;

        public System_Login()
        {
            InitializeComponent();

            if (Update_task.checkversion())
            {
                MessageBox.Show("Đã có phiên bản cập nhật mới, phần mềm sẽ tiến hành cập nhật", "Education", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Update_Status.Enabled = true;
                Progress_Dowloader.Enabled = true;
                Update_Status.Visible = true;
                Progress_Dowloader.Visible = true;
                blockUI = true;

                string downloadUrl = "https://education.thanglele08.id.vn/Download/Education-Setup.msi"; // URL tải xuống phiên bản mới
                string tempFilePath = Path.Combine(Path.GetTempPath(), "Education-Setup.msi");

                try
                {
                    // Tải xuống phiên bản mới
                    using (WebClient client = new WebClient())
                    {
                        Update_Status.Text = "Đang tải xuống phiên bản mới...";

                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                        // Tải xuống phiên bản mới
                        client.DownloadFileAsync(new Uri(downloadUrl), tempFilePath);
                    }
                }
                catch (Exception)
                {
                    //Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
                    MessageBox.Show("Mất kết nối tới máy chủ dữ liệu, yêu cầu kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Update_Status.Enabled = false;
                Progress_Dowloader.Enabled = false;
                Update_Status.Visible = false;
                Progress_Dowloader.Visible = false;
            }
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void get_token()
        {
            this.Cursor = Cursors.WaitCursor;
            blockUI = true;

            try
            {
                string url = "https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/oauth/token";
                //MessageBox.Show(url);
                string clientId = "education_client";
                string clientSecret = "password";
                string username = USR_label.Text;
                string password = PASS_label.Text;
                File.WriteAllText(Work_path + "Account\\Login_Infor.txt", USR_label.Text + PASS_label.Text);

                using (HttpClient client = new HttpClient())
                {
                    var requestData = new
                    {
                        client_id = clientId,
                        grant_type = "password",
                        username = username,
                        password = password,
                        client_secret = clientSecret
                    };

                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("client_id", clientId),
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                        new KeyValuePair<string, string>("client_secret", clientSecret)
                    });

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        File.WriteAllText(Work_path + "Account\\Token_User.txt", responseBody);

                        //dynamic tokenData = JsonConvert.DeserializeObject(responseBody);
                        open_main();
                    }
                    else
                    {
                        if (Convert.ToString(response.StatusCode) == "BadRequest")
                        {
                            //MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Login_action.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
                        }
                        else
                        {
                            //MessageBox.Show("Mất kết nối với internet, yêu cầu kiểm tra lại!", "Cảnh báo Token", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show("Có lỗi trong việc lấy dữ liệu từ máy chủ, hãy đăng nhập lại!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Mất kết nối với internet, yêu cầu kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Login_action.Text = "Mất kết nối với internet, yêu cầu kiểm tra lại!";
                //MessageBox.Show(Convert.ToString(ex));
            }
            finally
            {
                this.Cursor = Cursors.Default;
                blockUI = false;
            }
        }

        private void open_main()
        {
            System_Main new_main = new System_Main(server, port);
            new_main.Show();
            this.Hide();
        }

        private void login()
        {
            Login_action.Text = "Đang xác thực thông tin đăng nhập...";

            if (!Directory.Exists(Work_path + "Account"))
            {
                System.IO.Directory.CreateDirectory(Work_path + "Account");
            }

            //Get Token -> file JSON

            switch (Server_pick.SelectedIndex)
            {
                case 1:
                    server = "2";
                    port = "9923";
                    break;
                case 2:
                    server = "3";
                    port = "8098";
                    break;
                case 3:
                    server = "4";
                    port = "8098";
                    break;
                default:
                    server = "1";
                    port = "8098";
                    break;
            }

            try
            {
                long Masinhvien_inp = Convert.ToInt64(USR_label.Text);
                if (PASS_label.Text == "" || USR_label.Text == "")
                {
                    Login_action.Text = "Các trường đăng nhập không được bỏ trống!";
                }
                else
                {
                    if (File.Exists(Work_path + "Account\\getcurrentuser.txt") && (DateTime.Now - File.GetLastWriteTime(Work_path + "Account\\getcurrentuser.txt")).TotalHours < 12)
                    {
                        string checking = USR_label.Text + PASS_label.Text;
                        if (checking == File.ReadAllText(Work_path + "Account\\Login_Infor.txt"))
                        {
                            Login_action.Text = "Tiến hành đăng nhập nhanh...";
                            Login_action.Text = "Đang lấy dữ liệu từ Server, xin vui lòng chờ...";
                            open_main();
                        }
                        else
                        {
                            Login_action.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
                            File.Delete(Work_path + "Account\\Login_Infor.txt");
                            File.Delete(Work_path + "Account\\getcurrentuser.txt");
                        }
                    }
                    else
                    {
                        Login_action.Text = "Đang xác thực từ Server, xin vui lòng chờ...";
                        get_token();
                    }
                }
            }
            catch (FormatException)
            {
                Login_action.Text = "Mã số sinh viên không có xuất hiện chữ hay ký hiệu!";
            }
        }

        private void Exit_label_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_label_Click(object sender, EventArgs e)
        {
            if (blockUI == false)
            {
                login();
            }
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            if (blockUI == false)
            {
                login();
            }
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && blockUI == false)
            {
                login();
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Progress_Dowloader.Value = e.ProgressPercentage;
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //MessageBox.Show("Có lỗi xảy ra trong quá trình tải xuống: " + e.Error.Message);
                MessageBox.Show("Kết nối đường truyền không ổn định, không thể tải xuống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Update_Status.Enabled = false;
                Progress_Dowloader.Enabled = false;
                Update_Status.Visible = false;
                Progress_Dowloader.Visible = false;
            }
            else
            {
                MessageBox.Show("Tải xuống hoàn tất, phần mềm sẽ đóng để tiến hành cài đặt", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Thực thi tệp cài đặt phiên bản mới
                System.Diagnostics.Process.Start(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Education-Setup.msi"));
                // Thoát ứng dụng hiện tại để cài đặt phiên bản mới
                Application.Exit();
            }
        }

        private void System_Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}