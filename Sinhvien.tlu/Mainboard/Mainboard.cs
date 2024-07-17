using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace Sinhvien.tlu.Mainboard
{
    public partial class System_Main : Form
    {
        private bool blockUI = false;
        private dynamic tokenData;
        private string getCurrentUser_raw, getstudentbylogin_raw;
        private JObject getCurrentUser, getstudentbylogin, person, address;
        private string id, personId, username, firstName, lastName, displayName, birthDateString, birthPlace, gender, phoneNumber, idNumber, idNumberIssueBy,
            idNumberIssueDateString, email, address_mini;
        private string schoolyearsId, SemesterID, registerPeriodId;
        private RegisterPeriod rootObject;
        private SubjectRegistrationDto selectedSubject;
        private string server, port;
        public string Work_path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Education\\";

        public void LoadJsonAndDisplayData(string jsonContent)
        {
            try
            {
                rootObject = JsonConvert.DeserializeObject<RegisterPeriod>(jsonContent);

                StartDate_Reg.Text = "Ngày bắt đầu: " + rootObject.CourseRegisterViewObject.StartDateString;
                EndDate_Reg.Text = "Ngày kết thúc: " + rootObject.CourseRegisterViewObject.EndDateString;

                List<SubjectRegistrationDto> subjects = rootObject.CourseRegisterViewObject.ListSubjectRegistrationDtos;
                List_Subject.DataSource = subjects;

                List_Subject.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                List_Subject_Choice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi trong việc biên dịch dữ liệu, vui lòng cập nhật bản vá lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ConvertJsonDateToString(long? jsonDate)
        {
            if (long.TryParse(Convert.ToString(jsonDate), out long milliseconds))
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(milliseconds);
                return dateTimeOffset.ToString("dd-MM-yyyy");
            }
            return string.Empty;
        }

        public void List_Subject_SelectionChanged(object sender, EventArgs e)
        {
            if (List_Subject.CurrentRow != null)
            {
                selectedSubject = (SubjectRegistrationDto)List_Subject.CurrentRow.DataBoundItem;
                var subject_preview = new List<Subject_Preview>();

                foreach (var Sub_Course in selectedSubject.CourseSubjectDtos)
                {
                    var Subject_Information = new Subject_Preview();
                    if (Sub_Course.IsFullClass)
                    {
                        Subject_Information.isFullclass = "Lớp đã đầy";
                    }
                    Subject_Information.displayName = Sub_Course.DisplayName;
                    if (Sub_Course.IsOvelapTime)
                    {
                        Subject_Information.IsOvelapTime = "Trùng tiết!";
                    }
                    if (Sub_Course.IsSelected)
                    {
                        Subject_Information.isSelected = "Đã đăng ký";
                    }
                    else
                    {
                        Subject_Information.isSelected = "Bấm đúp chuột để đăng ký";
                    }
                    Subject_Information.numberstudent = "Sĩ số " + Sub_Course.NumberStudent + "/" + Sub_Course.MaxStudent;
                    subject_preview.Add(Subject_Information);

                    subject_preview.Add(new Subject_Preview()
                    {
                        isFullclass = "",
                        displayName = "Tuần",
                        IsOvelapTime = "Thời gian",
                        Information = "Phòng",
                        numberstudent = "Giáo viên",
                        isSelected = ""
                    });

                    foreach (var timetable in Sub_Course.Timetables)
                    {
                        subject_preview.Add(new Subject_Preview()
                        {
                            isFullclass = "",
                            displayName = "Thứ " + timetable.weekIndex + ", " + ConvertJsonDateToString(timetable.startDate) + " -> " + ConvertJsonDateToString(timetable.endDate),
                            IsOvelapTime = timetable.start + " -> " + timetable.end,
                            Information = timetable.roomName,
                            numberstudent = timetable.teacherName,
                            isSelected = ""
                        });
                    }

                    if (Sub_Course.NumberSubCourseSubject != 0)
                    {
                        subject_preview.Add(new Subject_Preview()
                        {
                            isFullclass = "",
                            displayName = "Các lớp thành phần:",
                            IsOvelapTime = "",
                            Information = "",
                            numberstudent = ""
                        });
                        foreach (var Course_sub_Course in Sub_Course.SubCourseSubjects)
                        {
                            var Course_Subject_Information = new Subject_Preview();
                            if (Course_sub_Course.IsFullClass)
                            {
                                Course_Subject_Information.isFullclass = "Lớp đã đầy";
                            }
                            Course_Subject_Information.displayName = Course_sub_Course.DisplayName;
                            if (Course_sub_Course.IsOvelapTime)
                            {
                                Course_Subject_Information.IsOvelapTime = "Trùng tiết!";
                            }
                            if (Course_sub_Course.IsSelected)
                            {
                                Course_Subject_Information.isSelected = "Đã đăng ký";
                            }
                            else
                            {
                                Course_Subject_Information.isSelected = "Bấm đúp chuột để đăng ký";
                            }
                            Course_Subject_Information.numberstudent = "Sĩ số " + Course_sub_Course.NumberStudent + "/" + Course_sub_Course.MaxStudent;
                            subject_preview.Add(Course_Subject_Information);

                            subject_preview.Add(new Subject_Preview()
                            {
                                isFullclass = "",
                                displayName = "Tuần",
                                IsOvelapTime = "Thời gian",
                                Information = "Phòng",
                                numberstudent = "Giáo viên",
                                isSelected = ""
                            });

                            foreach (var Course_timetables in Course_sub_Course.Timetables)
                            {
                                subject_preview.Add(new Subject_Preview()
                                {
                                    isFullclass = "",
                                    displayName = "Thứ " + Course_timetables.weekIndex + ", " + ConvertJsonDateToString(Course_timetables.startDate) + " -> " + ConvertJsonDateToString(Course_timetables.endDate),
                                    IsOvelapTime = Course_timetables.start + " -> " + Course_timetables.end,
                                    Information = Course_timetables.roomName,
                                    numberstudent = Course_timetables.teacherName,
                                    isSelected = ""
                                });
                            }
                        }
                    }
                }
                List_Subject_Choice.DataSource = subject_preview;
            }
        }

        private void getCurrentUser_Task()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            HttpClient client = new HttpClient();
            string url = "https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/users/getCurrentUser";
            string bearerToken = tokenData.access_token;

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            HttpResponseMessage response = client.GetAsync(url).Result;

            this.Cursor = System.Windows.Forms.Cursors.Default;

            if (response.IsSuccessStatusCode)
            {
                getCurrentUser_raw = response.Content.ReadAsStringAsync().Result;
                File.WriteAllText(Work_path + "Account\\getcurrentuser.txt", getCurrentUser_raw);

                getCurrentUser = JObject.Parse(getCurrentUser_raw);
                person = (JObject)getCurrentUser["person"];

                id = (string)getCurrentUser["id"];
                personId = (string)person["id"];
                username = (string)getCurrentUser["username"];
                firstName = (string)person["firstName"];
                lastName = (string)person["lastName"];
                displayName = (string)person["displayName"];
                birthDateString = (string)person["birthDateString"];
                birthPlace = (string)person["birthPlace"];
                gender = (string)person["gender"];
                phoneNumber = (string)person["phoneNumber"];
                idNumber = (string)person["idNumber"];
                idNumberIssueBy = (string)person["idNumberIssueBy"];
                idNumberIssueDateString = (string)person["idNumberIssueDateString"];
                email = (string)person["email"];
                address_mini = (string)person["address_mini"];
            }
            else
            {
                MessageBox.Show("Lỗi kết nối tới máy chủ, vui lòng thử lại sau...");
            }
        }

        private void getStudentbylogin_task()
        {
            Static_loading.Text = "Đang lấy thông tin tài khoản...";
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            HttpClient client = new HttpClient();
            string url = "https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/student/getstudentbylogin";
            string bearerToken = tokenData.access_token;

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            HttpResponseMessage response = client.GetAsync(url).Result;

            Static_loading.Text = "";
            this.Cursor = System.Windows.Forms.Cursors.Default;

            if (response.IsSuccessStatusCode)
            {
                getstudentbylogin_raw = response.Content.ReadAsStringAsync().Result;
                getstudentbylogin = JObject.Parse(getstudentbylogin_raw);
                File.WriteAllText(Work_path + "Account\\getstudentbylogin.txt", getstudentbylogin_raw);
                textBox1.Text = getstudentbylogin_raw;
            }
            else
            {
                MessageBox.Show("Lỗi kết nối tới máy chủ, vui lòng thử lại sau...");
            }
        }

        public System_Main(string server_login, string port_login)
        {
            server = server_login;
            port = port_login;
            tokenData = JsonConvert.DeserializeObject(File.ReadAllText(Work_path + "Account\\Token_User.txt"));

            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Đăng xuất";

            File.Delete(Work_path + "Account\\Login_Infor.txt");
            File.Delete(Work_path + "Account\\getstudentbylogin.txt");
            File.Delete(Work_path + "Account\\getcurrentuser.txt");
            File.Delete(Work_path + "Account\\Token_User.txt");

            Application.Restart();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getStudentbylogin_task();
            this.Text = "Education | Thông tin tài khoản";

            Main_Dashboard.SelectedIndex = 13;
        }

        private void đổiMậtKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Đổi mật khẩu";
            Main_Dashboard.SelectedIndex = 14;
        }

        private void displayOrder_Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_schoolyears(displayOrder_Picker.SelectedIndex + 1);
            get_findByPeriod();
            //textBox2.Text = File.ReadAllText("Semester\\registerPeriodId.txt");

            //semesterCode_Picker.Items.Add(textBox2.Text);
        }

        private void Trangchu_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Trang chủ";
            Main_Dashboard.SelectedIndex = 0;
        }

        //Lệnh đăng kí môn
        private void new_reg(String register)
        {
            try
            {
                string url = "https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/cs_reg_mongo/add-register/" + personId + "/" + registerPeriodId;
                string bearerToken = tokenData.access_token;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");

                    HttpContent content = new StringContent(register, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(url, content).Result;
                    var respond = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    get_findByPeriod();
                    Static_loading.Text = (string)respond["message"] + ", Mã trạng thái: " + (string)respond["status"];
                }
            }
            catch (Exception)
            {
                Static_loading.Text = "Có lỗi xảy ra, vui lòng thực hiện lại thao tác!";
            }
        }

        //Lệnh hủy đăng ký môn
        private void remove_reg(String register)
        {
            try
            {
                string url = "https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/cs_reg_mongo/remove-register/" + personId + "/" + registerPeriodId;
                string bearerToken = tokenData.access_token;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");

                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri(url),
                        Content = new StringContent(register, Encoding.UTF8, "application/json")
                    };

                    HttpResponseMessage response = client.SendAsync(request).Result;
                    var respond = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    //MessageBox.Show(Convert.ToString(respond), url);
                    get_findByPeriod();
                    if ((string)respond["status"] == "0")
                    {
                        Static_loading.Text = "Môn học đã được hủy thành công!";
                    }
                    else
                    {
                        Static_loading.Text = "Môn học hủy không thành công" + ", Mã trạng thái: " + (string)respond["status"];
                    }
                }
            }
            catch(Exception)
            {
                Static_loading.Text = "Có lỗi xảy ra, hãy thực hiện lại thao tác!";
            }
        }

        //Lấy file thông tin môn học từ server
        private void get_findByPeriod()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            HttpClient client = new HttpClient();
            string url = "https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/cs_reg_mongo/findByPeriod/" + personId + "/" + registerPeriodId;
            string bearerToken = tokenData.access_token;

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string registerPeriodId_raw = response.Content.ReadAsStringAsync().Result;

                    if (!Directory.Exists(Work_path + "Semester"))
                    {
                        System.IO.Directory.CreateDirectory(Work_path + "Semester");
                    }

                    File.WriteAllText(Work_path + "Semester\\registerPeriodId.txt", registerPeriodId_raw);

                    LoadJsonAndDisplayData(registerPeriodId_raw);
                }
                else
                {
                    Static_loading.Text = "Lấy thông tin thất bại";
                    MessageBox.Show("Lỗi kết nối tới máy chủ, vui lòng thử lại sau...");
                }
            }
            catch (Exception)
            {
                Static_loading.Text = "Lấy thông tin thất bại";
                MessageBox.Show("Lỗi kết nối tới máy chủ, vui lòng thử lại sau...");
            }
            finally
            {
                Static_loading.Text = "";
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        //Làm mới list
        private void refresh_button_Click(object sender, EventArgs e)
        {
            get_findByPeriod();
        }

        //Hàm đổ màu cho ô
        private void List_Subject_Choice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (List_Subject_Choice.Columns[e.ColumnIndex].Name == "isFullclass")
            {
                if (e.Value != null && e.Value.ToString() == "Lớp đã đầy")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }

            if (List_Subject_Choice.Columns[e.ColumnIndex].Name == "IsOvelapTime")
            {
                if(e.Value != null && e.Value.ToString() == "Trùng tiết!")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }    
            }

            if (List_Subject_Choice.Columns[e.ColumnIndex].Name == "isSelected")
            {
                if (e.Value != null && e.Value.ToString() == "Đã đăng ký")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }    
            }
        }

        private void List_Subject_Choice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Loading và đóng băng toàn bộ khu vực chọn môn, tránh bị spam đăng kí
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            List_Subject_Choice.Enabled = false;
            List_Subject.Enabled = false;
            if (List_Subject_Choice.CurrentRow != null && blockUI == false)
            {
                blockUI = true;
                // Lấy đối tượng Subject_Preview từ hàng hiện tại
                Subject_Preview selectedSubject1 = (Subject_Preview)List_Subject_Choice.CurrentRow.DataBoundItem;
                if (selectedSubject1.isSelected != "")
                {
                    if (rootObject.CourseRegisterViewObject.allowRegister || rootObject.CourseRegisterViewObject.IsAllowUnRegister)
                    {

                        //if (selectedSubject1.isFullclass == "Lớp đã đầy" && selectedSubject1.isSelected != "Đã đăng ký")
                        //{
                        //    MessageBox.Show("Lớp đã đủ người, vui lòng chọn lớp khác!", "Thông báo");
                        //}
                        //else
                        //{
                            if (selectedSubject1.IsOvelapTime == "Trùng tiết!")
                            {
                                MessageBox.Show("Xuất hiện môn học khác trùng với thời gian của môn đang đăng kí, yêu cầu kiểm tra lại!", "Cảnh báo");
                            }
                            else
                            {
                                Register_Class foundCourseSubject = null;
                                bool static_search = false;
                                foreach (var Sub_Course in selectedSubject.CourseSubjectDtos)
                                {
                                    if (Sub_Course.DisplayName == selectedSubject1.displayName)
                                    {
                                        foundCourseSubject = new Register_Class
                                        {
                                            createDate = Sub_Course.CreateDate ?? null,
                                            createdBy = Sub_Course.CreatedBy ?? null,
                                            modifyDate = Sub_Course.ModifyDate ?? null,
                                            modifiedBy = Sub_Course.ModifiedBy ?? null,
                                            id = Sub_Course.Id,
                                            voided = Sub_Course.Voided,
                                            code = Sub_Course.Code ?? null,
                                            shortCode = Sub_Course.ShortCode ?? null,
                                            subjectId = Sub_Course.SubjectId,
                                            subjectName = Sub_Course.SubjectName ?? null,
                                            subjectCode = Sub_Course.SubjectCode ?? null,
                                            parent = Sub_Course.Parent ?? null,
                                            subCourseSubjects = Sub_Course.SubCourseSubjects,
                                            isUsingConfig = Sub_Course.IsUsingConfig,
                                            isFullClass = Sub_Course.IsFullClass,
                                            courseSubjectConfigs = Sub_Course.CourseSubjectConfigs ?? null,
                                            timetables = Sub_Course.Timetables ?? null,
                                            semesterSubject = Sub_Course.SemesterSubject ?? null,
                                            maxStudent = Sub_Course.MaxStudent,
                                            minStudent = Sub_Course.MinStudent,
                                            numberStudent = Sub_Course.NumberStudent,
                                            courseSubjectType = Sub_Course.CourseSubjectType ?? null,
                                            learningSkillId = Sub_Course.LearningSkillId ?? null,
                                            learningSkillName = Sub_Course.LearningSkillName ?? null,
                                            learningSkillCode = Sub_Course.LearningSkillCode ?? null,
                                            isSelected = Sub_Course.IsSelected,
                                            children = Sub_Course.Children ?? null,
                                            hashCourseSubjects = Sub_Course.HashCourseSubjects,
                                            expanded = Sub_Course.Expanded,
                                            isGrantAll = Sub_Course.IsGrantAll,
                                            isDeniedAll = Sub_Course.IsDeniedAll,
                                            trainingBase = Sub_Course.TrainingBase ?? null,
                                            isOvelapTime = Sub_Course.IsOvelapTime,
                                            overLapClasses = Sub_Course.OverLapClasses,
                                            courseYearId = Sub_Course.CourseYearId ?? null,
                                            courseYearCode = Sub_Course.CourseYearCode ?? null,
                                            courseYearName = Sub_Course.CourseYearName ?? null,
                                            displayName = Sub_Course.DisplayName ?? null,
                                            numberOfCredit = Sub_Course.NumberOfCredit,
                                            isFeeByCourseSubject = Sub_Course.IsFeeByCourseSubject,
                                            feePerCredit = Sub_Course.FeePerCredit ?? null,
                                            tuitionCoefficient = Sub_Course.TuitionCoefficient ?? null,
                                            totalFee = Sub_Course.TotalFee ?? null,
                                            feePerStudent = Sub_Course.FeePerStudent ?? null,
                                            enrollmentClassId = Sub_Course.EnrollmentClassId ?? null,
                                            enrollmentClassCode = Sub_Course.EnrollmentClassCode ?? null,
                                            numberHours = Sub_Course.NumberHours ?? null,
                                            teacher = Sub_Course.Teacher ?? null,
                                            teacherName = Sub_Course.TeacherName ?? null,
                                            teacherCode = Sub_Course.TeacherCode ?? null,
                                            startDate = Sub_Course.StartDate ?? null,
                                            endDate = Sub_Course.EndDate ?? null,
                                            learningMethod = Sub_Course.LearningMethod ?? null,
                                            status = Sub_Course.Status,
                                            subjectExams = Sub_Course.SubjectExams ?? null,
                                            semesterId = Sub_Course.SemesterId ?? null,
                                            semesterCode = Sub_Course.SemesterCode ?? null,
                                            periodId = Sub_Course.PeriodId ?? null,
                                            periodName = Sub_Course.PeriodName ?? null,
                                            username = Sub_Course.Username ?? null,
                                            actionTime = Sub_Course.ActionTime ?? null,
                                            logContent = Sub_Course.LogContent ?? null,
                                            numberLearningSkill = Sub_Course.NumberLearningSkill,
                                            numberSubCourseSubject = Sub_Course.NumberSubCourseSubject,
                                            check = Sub_Course.Check
                                        };
                                        break;
                                    }
                                }
                                foreach (var Sub_Course in selectedSubject.CourseSubjectDtos)
                                {
                                    if (Sub_Course.NumberSubCourseSubject != 0)
                                    {
                                        foreach (var Course_sub_Course in Sub_Course.SubCourseSubjects)
                                        {
                                            if (Course_sub_Course.DisplayName == selectedSubject1.displayName)
                                            {
                                                if (Sub_Course.IsSelected)
                                                {
                                                    foundCourseSubject = new Register_Class
                                                    {
                                                        createDate = Course_sub_Course.CreateDate ?? null,
                                                        createdBy = Course_sub_Course.CreatedBy ?? null,
                                                        modifyDate = Course_sub_Course.ModifyDate ?? null,
                                                        modifiedBy = Course_sub_Course.ModifiedBy ?? null,
                                                        id = Course_sub_Course.Id,
                                                        voided = Course_sub_Course.Voided,
                                                        code = Course_sub_Course.Code ?? null,
                                                        shortCode = Course_sub_Course.ShortCode ?? null,
                                                        subjectId = Course_sub_Course.SubjectId,
                                                        subjectName = Course_sub_Course.SubjectName ?? null,
                                                        subjectCode = Course_sub_Course.SubjectCode ?? null,
                                                        parent = Course_sub_Course.Parent ?? null,
                                                        subCourseSubjects = null,
                                                        isUsingConfig = Course_sub_Course.IsUsingConfig,
                                                        isFullClass = Course_sub_Course.IsFullClass,
                                                        courseSubjectConfigs = Course_sub_Course.CourseSubjectConfigs ?? null,
                                                        timetables = Course_sub_Course.Timetables ?? null,
                                                        semesterSubject = Course_sub_Course.SemesterSubject ?? null,
                                                        maxStudent = Course_sub_Course.MaxStudent,
                                                        minStudent = Course_sub_Course.MinStudent,
                                                        numberStudent = Course_sub_Course.NumberStudent,
                                                        courseSubjectType = Course_sub_Course.CourseSubjectType ?? null,
                                                        learningSkillId = Course_sub_Course.LearningSkillId ?? null,
                                                        learningSkillName = Course_sub_Course.LearningSkillName ?? null,
                                                        learningSkillCode = Course_sub_Course.LearningSkillCode ?? null,
                                                        isSelected = Course_sub_Course.IsSelected,
                                                        children = Course_sub_Course.Children ?? null,
                                                        hashCourseSubjects = Course_sub_Course.HashCourseSubjects,
                                                        expanded = Course_sub_Course.Expanded,
                                                        isGrantAll = Course_sub_Course.IsGrantAll,
                                                        isDeniedAll = Course_sub_Course.IsDeniedAll,
                                                        trainingBase = Course_sub_Course.TrainingBase ?? null,
                                                        isOvelapTime = Course_sub_Course.IsOvelapTime,
                                                        overLapClasses = Course_sub_Course.OverLapClasses,
                                                        courseYearId = Course_sub_Course.CourseYearId ?? null,
                                                        courseYearCode = Course_sub_Course.CourseYearCode ?? null,
                                                        courseYearName = Course_sub_Course.CourseYearName ?? null,
                                                        displayName = Course_sub_Course.DisplayName ?? null,
                                                        numberOfCredit = Course_sub_Course.NumberOfCredit,
                                                        isFeeByCourseSubject = Course_sub_Course.IsFeeByCourseSubject,
                                                        feePerCredit = Course_sub_Course.FeePerCredit ?? null,
                                                        tuitionCoefficient = Course_sub_Course.TuitionCoefficient ?? null,
                                                        totalFee = Course_sub_Course.TotalFee ?? null,
                                                        feePerStudent = Course_sub_Course.FeePerStudent ?? null,
                                                        enrollmentClassId = Course_sub_Course.EnrollmentClassId ?? null,
                                                        enrollmentClassCode = Course_sub_Course.EnrollmentClassCode ?? null,
                                                        numberHours = Course_sub_Course.NumberHours ?? null,
                                                        teacher = Course_sub_Course.Teacher ?? null,
                                                        teacherName = Course_sub_Course.TeacherName ?? null,
                                                        teacherCode = Course_sub_Course.TeacherCode ?? null,
                                                        startDate = Course_sub_Course.StartDate ?? null,
                                                        endDate = Course_sub_Course.EndDate ?? null,
                                                        learningMethod = Course_sub_Course.LearningMethod ?? null,
                                                        status = Course_sub_Course.Status,
                                                        subjectExams = Course_sub_Course.SubjectExams ?? null,
                                                        semesterId = Course_sub_Course.SemesterId ?? null,
                                                        semesterCode = Course_sub_Course.SemesterCode ?? null,
                                                        periodId = Course_sub_Course.PeriodId ?? null,
                                                        periodName = Course_sub_Course.PeriodName ?? null,
                                                        username = Course_sub_Course.Username ?? null,
                                                        actionTime = Course_sub_Course.ActionTime ?? null,
                                                        logContent = Course_sub_Course.LogContent ?? null,
                                                        numberLearningSkill = Course_sub_Course.NumberLearningSkill,
                                                        numberSubCourseSubject = Course_sub_Course.NumberSubCourseSubject,
                                                        check = Course_sub_Course.Check
                                                    };
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Yêu cầu đăng ký lớp chính THÀNH CÔNG để có thể thực hiện thao tác này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                    static_search = true;
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (static_search == false)
                                {
                                    if (foundCourseSubject != null)
                                    {
                                        // Chuyển đổi đối tượng thành chuỗi JSON để hiển thị
                                        string json = JsonConvert.SerializeObject(foundCourseSubject, Formatting.None);

                                        string filePath = Work_path + "Semester\\reg_preview.txt";
                                        File.WriteAllText(filePath, json);
                                        //MessageBox.Show(json);
                                        if (selectedSubject1.isSelected == "Đã đăng ký")
                                        {
                                            DialogResult dlr = MessageBox.Show("Xác nhận hủy môn này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                            if (dlr == DialogResult.Yes)
                                            {
                                                //Hủy môn
                                                remove_reg(json);
                                            }
                                        }
                                        else
                                        {
                                            //Đăng kí môn
                                            new_reg(json);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Không tìm thấy thông tin chi tiết của môn học, Chú ý bấm đúp chuột vào tên môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Không trong thời gian đăng kí môn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                blockUI = false;
            }
            List_Subject.Enabled = true;
            List_Subject_Choice.Enabled = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void Dangkyhocmoi_button_Click(object sender, EventArgs e)
        {
            Static_loading.Text = "Đang lấy thông tin môn học...";
            displayOrder_Picker.StartIndex = 0;

            get_findByPeriod();

            this.Text = "Education | Đăng ký học mới | Đăng ký môn";
            Main_Dashboard.SelectedIndex = 1;
            this.WindowState = FormWindowState.Maximized;

            List_Subject_Choice.Columns[0].Width = 50;
            //List_Subject_Choice.Columns[1].Width = 500;
            List_Subject_Choice.Columns[2].Width = 75;
            List_Subject_Choice.Columns[3].Width = 50;
            List_Subject_Choice.Columns[4].Width = 100;
            List_Subject_Choice.Columns[5].Width = 200;
            List_Subject.AllowUserToResizeColumns = false;
            List_Subject.AllowUserToResizeRows = false;
            List_Subject_Choice.AllowUserToResizeRows = false;
            List_Subject_Choice.AllowUserToResizeColumns = false;
        }

        private void Change_Password_Button_Click(object sender, EventArgs e)
        {
            //Hàm kiểm tra mật khẩu cũ
            this.Text = "Education | Đổi mật khẩu";

            this.Cursor = Cursors.WaitCursor;
            if (New_Password.Text == RE_New_Password.Text && RE_New_Password.Text.Length >= 8)
            {
                string url = "https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/users/password/valid";
                string bearerToken = tokenData.access_token;
                string jsonContent = "{\"password\":\"" + Old_Password.Text + "\"}";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");

                    HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(url, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        bool isValid = bool.Parse(responseBody);
                        if (isValid)
                        {
                            url = "https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/users/password/self";
                            string jsonContent_Change = "{\"id\":" + id + ",\"username\":\"" + username + "\",\"password\":\"" + RE_New_Password.Text + "\"}";
                            //MessageBox.Show(jsonContent_Change);

                            using (HttpClient client_Change = new HttpClient())
                            {
                                client_Change.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                client_Change.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");

                                HttpContent content_Change = new StringContent(jsonContent_Change, Encoding.UTF8, "application/json");
                                HttpResponseMessage response_Change = client_Change.PutAsync(url, content_Change).Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    //string responseBody_Change = response_Change.Content.ReadAsStringAsync().Result;
                                    //MessageBox.Show(responseBody_Change);

                                    this.Text = "Education | Đăng xuất";
                                    MessageBox.Show("Đổi mật khẩu thành công, hãy đăng nhập lại!", "Chú ý");

                                    File.Delete(Work_path + "Account\\Login_Infor.txt");
                                    File.Delete(Work_path + "Account\\getstudentbylogin.txt");
                                    File.Delete(Work_path + "Account\\getcurrentuser.txt");
                                    File.Delete(Work_path + "Account\\Token_User.txt");

                                    Application.Restart();
                                }
                                else
                                {
                                    //string responseBody_Change = response_Change.Content.ReadAsStringAsync().Result;
                                    //MessageBox.Show(responseBody_Change);
                                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau!", "Chú ý");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu cũ nhập vào không hợp lệ!", "Cảnh báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi kết nối tới máy chủ, vui lòng thử lại sau...");
                    }
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không khớp hoặc nhỏ hơn 8 ký tự!", "Cảnh báo");
            }
        }

        private void Logo_FCCID_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.tlu.edu.vn/");
        }

        private void Ketquadangkyhoc_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Kết quả đăng ký học";
            Main_Dashboard.SelectedIndex = 2;
        }

        private void Dangkynguyenvonghoc_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Đăng ký nguyện vọng học";
            Main_Dashboard.SelectedIndex = 3;
        }

        private void Tracuudiemtonghop_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Tra cứu điểm tổng hợp";
            Main_Dashboard.SelectedIndex = 4;
        }

        private void System_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Copyright_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Thanglele2884");
        }

        private void Diemrenluyen_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Điểm rèn luyện";
            Main_Dashboard.SelectedIndex = 5;
        }

        private void Tracuudiemrenluyen_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Tra cứu điểm rèn luyện";
            Main_Dashboard.SelectedIndex = 15;
        }

        private void Chuongtrinhdaotao_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Chương trình đào tạo";
            Main_Dashboard.SelectedIndex = 6;
        }

        private void Xemlichthi_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Xem lịch thi";
            Main_Dashboard.SelectedIndex = 7;
        }

        private void Tracuuhocphi_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Tra cứu học phí";
            Main_Dashboard.SelectedIndex = 8;
        }

        private void Khenthuong_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Khen thưởng";
            Main_Dashboard.SelectedIndex = 9;
        }

        private void Kyluat_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Kỷ luật";
            Main_Dashboard.SelectedIndex = 10;
        }

        private void Nghiencuukhoahoc_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Nghiên cứu khoa học";
            Main_Dashboard.SelectedIndex = 11;
        }

        private void FCCID_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Thông tin bản dựng";
            Main_Dashboard.SelectedIndex = 12;
        }

        //Lấy thông tin semesterRegisterPrios từ displayOrder -> get dữ liệu từ pick các loại học kì khác nhau
        //Thông tin lấy offline từ tệp tin có sẵn
        private void get_schoolyears(int displayOrdercode)
        {
            // Lấy các giá trị id từ content khi current = true
            JArray contentArray = (JArray)JObject.Parse(File.ReadAllText(Work_path + "Semester\\Schoolyears.txt"))["content"];
            foreach (JObject contentItem in contentArray)
            {
                if ((bool)contentItem["current"])
                {
                    schoolyearsId = contentItem["id"].ToString();

                    // Lặp qua semesters
                    JArray semestersArray = (JArray)contentItem["semesters"];
                    foreach (JObject semesterItem in semestersArray)
                    {
                        if ((bool)semesterItem["isCurrent"])
                        {
                            SemesterID = semesterItem["id"].ToString();

                            // Lặp qua semesterRegisterPeriods
                            JArray semesterRegisterPeriodsArray = (JArray)semesterItem["semesterRegisterPeriods"];
                            foreach (JObject semesterRegisterPeriodItem in semesterRegisterPeriodsArray)
                            {
                                if ((int)semesterRegisterPeriodItem["displayOrder"] == displayOrdercode)
                                {
                                    registerPeriodId = semesterRegisterPeriodItem["id"].ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        //Lấy file 10000, lấy mã kì, mã năm học từ máy chủ
        private void getSemester()
        {
            Static_loading.Text = "Đang lấy thông tin năm học...";
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            HttpClient client = new HttpClient();
            string url = "https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/schoolyear/1/10000";
            string bearerToken = tokenData.access_token;

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string Schoolyears_raw = response.Content.ReadAsStringAsync().Result;
                File.WriteAllText(Work_path + "Semester\\Schoolyears.txt", Schoolyears_raw);

                get_schoolyears(1);

                url = $"https://sinhvien" + server + $".tlu.edu.vn:" + port + "/education/api/student_semester_behavior_mark/student/{schoolyearsId}/{SemesterID}";
                response = client.GetAsync(url).Result;

                Static_loading.Text = "";
                this.Cursor = System.Windows.Forms.Cursors.Default;

                if (response.IsSuccessStatusCode)
                {
                    string student_semester_behavitor_raw = response.Content.ReadAsStringAsync().Result;
                    File.WriteAllText(Work_path + "Semester\\Student_semester_behavitor.txt", student_semester_behavitor_raw);
                }
            }
            else
            {
                MessageBox.Show("Lỗi kết nối tới máy chủ, vui lòng thử lại sau...");
            }
        }

        private void System_Main_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Work_path + "Semester"))
            {
                Directory.CreateDirectory(Work_path + "Semester");
            }

            this.Main_Dashboard.Location = new System.Drawing.Point(-7, -20);

            try
            {
                getCurrentUser_Task();
                getSemester();
                User_UI.Text = displayName;

                Static_loading.Text = "Đang lấy thông tin môn học...";
                displayOrder_Picker.StartIndex = 0;

                get_findByPeriod();

                this.Text = "Education | Đăng ký học mới | Đăng ký môn";
                Main_Dashboard.SelectedIndex = 1;
                this.WindowState = FormWindowState.Maximized;

                List_Subject_Choice.Columns[0].Width = 50;
                //List_Subject_Choice.Columns[1].Width = 500;
                List_Subject_Choice.Columns[2].Width = 75;
                List_Subject_Choice.Columns[3].Width = 50;
                List_Subject_Choice.Columns[4].Width = 100;
                List_Subject_Choice.Columns[5].Width = 200;
                List_Subject.AllowUserToResizeColumns = false;
                List_Subject.AllowUserToResizeRows = false;
                List_Subject_Choice.AllowUserToResizeRows = false;
                List_Subject_Choice.AllowUserToResizeColumns = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Hết hiệu lực phiên đăng nhập, phần mềm sẽ khởi động lại.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Text = "Education | Đăng xuất";

                File.Delete(Work_path + "Account\\Login_Infor.txt");
                File.Delete(Work_path + "Account\\getstudentbylogin.txt");
                File.Delete(Work_path + "Account\\getcurrentuser.txt");
                File.Delete(Work_path + "Account\\Token_User.txt");

                Application.Restart();
            }
        }
    }
}