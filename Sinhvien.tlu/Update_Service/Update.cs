using System;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Sinhvien.tlu.Login_form
{
    internal class Update
    {
        //Hàm kiểm tra kích hoạt phần mềm từ máy chủ
        //Điều kiện đảo: false là cho phép chạy, true là không cho chạy
        public bool activate()
        {
            string activateUrl = "https://education.thanglele08.id.vn/Active.txt";

            try
            {
                // Kiểm tra quyền kích hoạt phần mềm
                using (WebClient client = new WebClient())
                {
                    string Role = client.DownloadString(activateUrl).Trim();

                    if (Role == "True")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                MessageBox.Show("Mất kết nối tới máy chủ dữ liệu, yêu cầu kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        public bool checkversion()
        {
            string currentVersion = "v1.0.4/KB1002"; // Phiên bản hiện tại của ứng dụng
            string versionUrl = "https://education.thanglele08.id.vn/Current-Version.txt"; // URL chứa thông tin phiên bản mới

            try
            {
                // Kiểm tra phiên bản mới
                using (WebClient client = new WebClient())
                {
                    string newVersion = client.DownloadString(versionUrl).Trim();

                    if (newVersion != currentVersion)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
                MessageBox.Show("Mất kết nối tới máy chủ dữ liệu, yêu cầu kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
