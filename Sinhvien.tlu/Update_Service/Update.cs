﻿using Newtonsoft.Json;
using System;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Windows.Forms;

namespace Sinhvien.tlu.Login_form
{
    internal class Update
    {
        public bool checkversion()
        {
            string currentVersion = "v1.0.6/KB1016";
            /*Update tính năng xem kết quả đăng kí môn*/
            string versionUrl = "https://education.thanglele08.id.vn/Current-Version.txt";

            if (System.Diagnostics.Debugger.IsAttached == false)
            {
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
                catch (Exception ex)
                {
                    //Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
                    MessageBox.Show("Mất kết nối tới máy chủ dữ liệu, yêu cầu kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
