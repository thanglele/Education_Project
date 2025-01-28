using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Sinhvien.tlu.Mainboard
{
    public partial class System_Main : Form
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response;

        private bool blockUI = false;
        private dynamic tokenData;
        private string schoolyearsId, SemesterID, registerPeriodId;
        private RegisterPeriod RegisterPeriod;
        private SubjectRegistrationDto selectedSubject;
        private CurrentUser_Root currentUser;
        private Studentbylogin_Root studentbylogin;
        private List<listStudentmarkBysemesterByloginUser_Root> listStudentmarkBysemesterByloginUser;
        Root100 myDeserializedClass;
        List<Regislist_Preview> regislist_Preview = new List<Regislist_Preview>();
        List<ListRoomExam_Preview> listroomexam_Preview = new List<ListRoomExam_Preview>();
        private string server, port;
        public string Work_path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Education\\";

        public void LoadJsonAndDisplayData(string jsonContent)
        {
            try
            {
                RegisterPeriod = JsonConvert.DeserializeObject<RegisterPeriod>(jsonContent);

                if (RegisterPeriod == null)
                {
                    MessageBox.Show("Dữ liệu kì học hiện đang trống, vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    StartDate_Reg.Text = "Ngày bắt đầu: ";
                    EndDate_Reg.Text = "Ngày kết thúc: ";
                }
                else
                {
                    try
                    {
                        StartDate_Reg.Text = "Ngày bắt đầu: " + RegisterPeriod.CourseRegisterViewObject.StartDateString;
                        EndDate_Reg.Text = "Ngày kết thúc: " + RegisterPeriod.CourseRegisterViewObject.EndDateString;

                        try
                        {
                            List_Subject.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            List_Subject_Choice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                            //List_Subject_Choice.Columns[0].Width = 50;
                            //List_Subject_Choice.Columns[1].Width = 500;
                            //List_Subject_Choice.Columns[2].Width = 75;
                            //List_Subject_Choice.Columns[3].Width = 50;
                            //List_Subject_Choice.Columns[4].Width = 100;
                            //List_Subject_Choice.Columns[5].Width = 200;
                            List_Subject.AllowUserToResizeColumns = false;
                            List_Subject.AllowUserToResizeRows = false;
                            List_Subject_Choice.AllowUserToResizeRows = false;
                            //List_Subject_Choice.AllowUserToResizeColumns = false;
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.ToString());
                            MessageBox.Show("Dữ liệu kì học hiện đang trống, vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }

                        List<SubjectRegistrationDto> subjects = RegisterPeriod.CourseRegisterViewObject.ListSubjectRegistrationDtos;
                        List_Subject.DataSource = subjects;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        MessageBox.Show("Có lỗi trong việc biên dịch dữ liệu, vui lòng cập nhật bản vá lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    if (Sub_Course.NumberSubCourseSubject != 0)
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

                        try
                        {
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
                        }
                        catch (Exception)
                        {
                            subject_preview.Add(new Subject_Preview()
                            {
                                isFullclass = "",
                                displayName = "Chưa có lịch học lớp này!",
                                IsOvelapTime = "",
                                Information = "",
                                numberstudent = "",
                                isSelected = ""
                            });
                        }
                    }
                    else
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

                        if (Sub_Course.Timetables == null)
                        {
                            subject_preview.Add(new Subject_Preview()
                            {
                                isFullclass = "",
                                displayName = "Chưa có lịch học lớp này!",
                                IsOvelapTime = "",
                                Information = "",
                                numberstudent = "",
                                isSelected = ""
                            });
                        }
                        else
                        {
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
                        }
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

            response = client.GetAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/users/getCurrentUser").Result;

            this.Cursor = System.Windows.Forms.Cursors.Default;

            if (response.IsSuccessStatusCode)
            {
                File.WriteAllText(Work_path + "Account\\getcurrentuser.txt", response.Content.ReadAsStringAsync().Result);
                currentUser = JsonConvert.DeserializeObject<CurrentUser_Root>(response.Content.ReadAsStringAsync().Result);
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

            response = client.GetAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/student/getstudentbylogin").Result;

            Static_loading.Text = "";
            this.Cursor = System.Windows.Forms.Cursors.Default;

            if (response.IsSuccessStatusCode)
            {
                File.WriteAllText(Work_path + "Account\\getstudentbylogin.txt", response.Content.ReadAsStringAsync().Result);
                studentbylogin = JsonConvert.DeserializeObject<Studentbylogin_Root>(response.Content.ReadAsStringAsync().Result);
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

            Main_Dashboard.SelectedIndex = 5;
        }

        private void đổiMậtKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Đổi mật khẩu";
            Main_Dashboard.SelectedIndex = 6;
        }

        private void displayOrder_Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_schoolyears(displayOrder_Picker.SelectedIndex + 1);
            get_findByPeriod();
            //textBox2.Text = File.ReadAllText("Semester\\registerPeriodId.txt");

            //semesterCode_Picker.Items.Add(textBox2.Text);
        }

        //Lệnh đăng kí môn
        private void new_reg(String register)
        {
            try
            {
                HttpContent content = new StringContent(register, Encoding.UTF8, "application/json");
                response = client.PostAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port +
                    "/education/api/cs_reg_mongo/add-register/" + currentUser.person.id + "/" + registerPeriodId
                    , content).Result;
                JObject respond = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                Static_loading.Text = (string)respond["message"] + ", Mã trạng thái: " + (string)respond["status"];

                get_findByPeriod();
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
                response = client.SendAsync(new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri("https://sinhvien" + server + ".tlu.edu.vn:" + port +
                    "/education/api/cs_reg_mongo/remove-register/" + currentUser.person.id + "/" + registerPeriodId),
                    Content = new StringContent(register, Encoding.UTF8, "application/json")
                }).Result;

                var respond = JObject.Parse(response.Content.ReadAsStringAsync().Result);

                if ((string)respond["status"] == "0")
                {
                    Static_loading.Text = "Môn học đã được hủy thành công!";
                }
                else
                {
                    Static_loading.Text = "Môn học hủy không thành công" + ", Mã trạng thái: " + (string)respond["status"];
                }

                get_findByPeriod();
            }
            catch (Exception)
            {
                Static_loading.Text = "Có lỗi xảy ra, hãy thực hiện lại thao tác!";
            }
        }

        //Lấy file thông tin môn học từ server
        private void get_findByPeriod()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                response = client.GetAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port +
                    "/education/api/cs_reg_mongo/findByPeriod/" + currentUser.person.id + "/" + registerPeriodId).Result;

                if (response.IsSuccessStatusCode)
                {
                    if (!Directory.Exists(Work_path + "Semester"))
                    {
                        System.IO.Directory.CreateDirectory(Work_path + "Semester");
                    }

                    File.WriteAllText(Work_path + "Semester\\registerPeriodId.txt", response.Content.ReadAsStringAsync().Result);

                    LoadJsonAndDisplayData(response.Content.ReadAsStringAsync().Result);
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
                if (e.Value != null && e.Value.ToString() == "Trùng tiết!")
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

            if (List_Subject_Choice.Columns[e.ColumnIndex].Name == "displayName")
            {
                if (e.Value.ToString() == "Chưa có lịch học lớp này!")
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
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
                    if (RegisterPeriod.CourseRegisterViewObject.allowRegister || RegisterPeriod.CourseRegisterViewObject.IsAllowUnRegister)
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
            getSemester();
            Static_loading.Text = "Đang lấy thông tin môn học...";
            displayOrder_Picker.StartIndex = 0;

            get_findByPeriod();

            this.Text = "Education | Đăng ký học mới | Đăng ký môn";
            Main_Dashboard.SelectedIndex = 0;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Change_Password_Button_Click(object sender, EventArgs e)
        {
            //Hàm kiểm tra mật khẩu cũ
            this.Text = "Education | Đổi mật khẩu";

            this.Cursor = Cursors.WaitCursor;
            if (New_Password.Text == RE_New_Password.Text && RE_New_Password.Text.Length >= 8)
            {
                response = client.PostAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/users/password/valid",
                    new StringContent("{\"password\":\"" + Old_Password.Text + "\"}", Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    if (bool.Parse(response.Content.ReadAsStringAsync().Result) == true)
                    {
                        using (HttpClient client_Change = new HttpClient())
                        {
                            client_Change.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            client_Change.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenData.access_token);

                            response = client_Change.PutAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port +
                                "/education/api/users/password/self",
                                new StringContent("{\"id\":" + currentUser.id + ",\"username\":\"" + currentUser.username + "\",\"password\":\"" + RE_New_Password.Text + "\"}",
                                Encoding.UTF8, "application/json")).Result;

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
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không khớp hoặc nhỏ hơn 8 ký tự!", "Cảnh báo");
            }
        }

        private void Ketquadangkyhoc_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Kết quả đăng ký học";
            Main_Dashboard.SelectedIndex = 1;

            this.Cursor = Cursors.WaitCursor;

            SemesterID_picker.Items.Clear();

            #region Lấy danh sách các kỳ học
            response = client.GetAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/schoolyear/1/100").Result;
            if (response.IsSuccessStatusCode)
            {
                File.WriteAllText(Work_path + "Semester\\Schoolyears100.txt", response.Content.ReadAsStringAsync().Result);
                myDeserializedClass = JsonConvert.DeserializeObject<Root100>(response.Content.ReadAsStringAsync().Result);
                int? semesterId = null;

                foreach (Content100 content in myDeserializedClass.content)
                {
                    foreach (Semester100 semesters in content.semesters)
                    {
                        if(semesters.isCurrent == true)
                        {
                            semesterId = semesters.id;
                        }    
                        SemesterID_picker.Items.Add(semesters.semesterCode);
                    }
                }
                SemesterID_picker.StartIndex = 0;
                #endregion
            }
            else
            {
                MessageBox.Show("Lỗi kết nối tới máy chủ, vui lòng thử lại sau...", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void Tracuudiemtonghop_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Tra cứu điểm tổng hợp";
            this.Cursor = Cursors.WaitCursor;

            response = client.GetAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/studentsubjectmark/getListStudentMarkBySemesterByLoginUser/0").Result;
            listStudentmarkBysemesterByloginUser = JsonConvert.DeserializeObject<List<listStudentmarkBysemesterByloginUser_Root>>(response.Content.ReadAsStringAsync().Result);

            List<viewListStudentMark> listsubjectmark = new List<viewListStudentMark>();
            for (int i = 0; i < listStudentmarkBysemesterByloginUser.Count; i++)
            {
                listsubjectmark.Add(new viewListStudentMark()
                {
                    STT = i + 1,
                    mahocphan = listStudentmarkBysemesterByloginUser[i].subject.subjectCode,
                    tenhocphan = listStudentmarkBysemesterByloginUser[i].subject.subjectName,
                    sotinchi = listStudentmarkBysemesterByloginUser[i].subject.numberOfCredit,
                    lanhoc = listStudentmarkBysemesterByloginUser[i].studyTime,
                    lanthi = listStudentmarkBysemesterByloginUser[i].examRound,
                    tinhdiem = (listStudentmarkBysemesterByloginUser[i].subject.isCalculateMark == true) ? true : false,
                    danhgia = (listStudentmarkBysemesterByloginUser[i].charMark == "F") ? "Không đạt" : "Đạt",
                    masinhvien = listStudentmarkBysemesterByloginUser[i].student.studentCode,
                    diemquatrinh = listStudentmarkBysemesterByloginUser[i].markQT,
                    diemthi = listStudentmarkBysemesterByloginUser[i].markTHI,
                    tongkethocphan = listStudentmarkBysemesterByloginUser[i].mark,
                    diemchu = listStudentmarkBysemesterByloginUser[i].charMark
                });
            }
            listStudentmark_table.DataSource = listsubjectmark;
            listStudentmark_table.Columns[0].HeaderText = "Số thứ tự";
            listStudentmark_table.Columns[1].HeaderText = "Mã học phần";
            listStudentmark_table.Columns[2].HeaderText = "Tên học phần";
            listStudentmark_table.Columns[3].HeaderText = "Số tín chỉ";
            listStudentmark_table.Columns[4].HeaderText = "Lần học";
            listStudentmark_table.Columns[5].HeaderText = "Lần thi";
            listStudentmark_table.Columns[6].HeaderText = "Là môn tính điểm";
            listStudentmark_table.Columns[7].HeaderText = "Đánh giá";
            listStudentmark_table.Columns[8].HeaderText = "Mã sinh viên";
            listStudentmark_table.Columns[9].HeaderText = "Quá trình";
            listStudentmark_table.Columns[10].HeaderText = "Thi";
            listStudentmark_table.Columns[11].HeaderText = "Tổng kết";
            listStudentmark_table.Columns[12].HeaderText = "Điểm chữ";
            listStudentmark_table.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.Cursor = Cursors.Default;
            Main_Dashboard.SelectedIndex = 2;
        }

        private void System_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Copyright_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Thanglele2884");
        }

        private void Xemlichthi_button_Click(object sender, EventArgs e)
        {
            this.Text = "Education | Xem lịch thi";
            Main_Dashboard.SelectedIndex = 3;

            this.Cursor = Cursors.WaitCursor;

            SemesterID_picker.Items.Clear();

            #region Lấy danh sách các kỳ học
            response = client.GetAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/schoolyear/1/100").Result;
            if (response.IsSuccessStatusCode)
            {
                File.WriteAllText(Work_path + "Semester\\Schoolyears100.txt", response.Content.ReadAsStringAsync().Result);
                myDeserializedClass = JsonConvert.DeserializeObject<Root100>(response.Content.ReadAsStringAsync().Result);

                ListSemester.Items.Clear();

                foreach (Content100 content in myDeserializedClass.content)
                {
                    foreach (Semester100 semesters in content.semesters)
                    {
                        if (semesters.isCurrent == true)
                        {
                            SemesterID = semesters.id.ToString();
                        }
                        ListSemester.Items.Add(semesters.semesterCode);
                    }
                }
                ListSemester.StartIndex = 0;
                #endregion
            }
            else
            {
                MessageBox.Show("Lỗi kết nối tới máy chủ, vui lòng thử lại sau...", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void ListSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                myDeserializedClass = JsonConvert.DeserializeObject<Root100>(File.ReadAllText(Work_path + "Semester\\Schoolyears100.txt"));
                foreach (Content100 content in myDeserializedClass.content)
                {
                    foreach (Semester100 semesters in content.semesters)
                    {
                        if(semesters.semesterCode == ListSemester.Text)
                        {
                            SemesterID = semesters.id.ToString();
                            if(DisplayOrderExam.StartIndex != 0)
                            {
                                DisplayOrderExam.StartIndex = 0;
                                break;
                            }
                            else
                            {
                                foreach (SemesterRegisterPeriod100 semesterRegisterPeriod100 in semesters.semesterRegisterPeriods)
                                {
                                    if (semesterRegisterPeriod100.displayOrder == displayOrder_Picker.SelectedIndex + 1)
                                    {
                                        if (TestNumber.StartIndex != 0)
                                        {
                                            registerPeriodId = semesterRegisterPeriod100.id.ToString();
                                            TestNumber.StartIndex = 0;
                                            break;
                                        }
                                        else
                                        {
                                            registerPeriodId = semesterRegisterPeriod100.id.ToString();
                                            getDataExamTimetable();
                                            break;
                                        }
                                    }
                                }
                            }
                        }    
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu, vui lòng thử lại sau...", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void DisplayOrderExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                myDeserializedClass = JsonConvert.DeserializeObject<Root100>(File.ReadAllText(Work_path + "Semester\\Schoolyears100.txt"));
                foreach (Content100 content in myDeserializedClass.content)
                {
                    foreach (Semester100 semesters in content.semesters)
                    {
                        if (semesters.id.ToString() == SemesterID)
                        {
                            foreach (SemesterRegisterPeriod100 semesterRegisterPeriod100 in semesters.semesterRegisterPeriods)
                            {
                                if (semesterRegisterPeriod100.displayOrder == displayOrder_Picker.SelectedIndex + 1)
                                {
                                    if(TestNumber.StartIndex != 0)
                                    {
                                        registerPeriodId = semesterRegisterPeriod100.id.ToString();
                                        TestNumber.StartIndex = 0;
                                        break;
                                    }   
                                    else
                                    {
                                        registerPeriodId = semesterRegisterPeriod100.id.ToString();
                                        getDataExamTimetable();
                                        break;
                                    }    
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu, vui lòng thử lại sau...", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void TestNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            getDataExamTimetable();
        }

        private void getDataExamTimetable()
        {
            try
            {
                ListRoomExam.DataSource = null;
                listroomexam_Preview.Clear();
                response = client.GetAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/semestersubjectexamroom/getListRoomByStudentByLoginUser/" + SemesterID + "/" + registerPeriodId + "/" + (TestNumber.SelectedIndex + 1).ToString()).Result;

                if (response.IsSuccessStatusCode)
                {
                    File.WriteAllText(Work_path + "Semester\\TimetableExam.txt", response.Content.ReadAsStringAsync().Result);
                    List<ListRoomExam_Root> listRoomExam_Root = JsonConvert.DeserializeObject<List<ListRoomExam_Root>>(response.Content.ReadAsStringAsync().Result);

                    if (listRoomExam_Root.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu dự thi.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        for (int i = 0; i < listRoomExam_Root.Count; i++)
                        {
                            if (i == 0)
                            {
                                listroomexam_Preview.Add(new ListRoomExam_Preview()
                                {
                                    examCode = "Số báo danh",
                                    examPeriodCode = "Mã kỳ thi",
                                    subjectName = "Tên môn học",
                                    name = "Phòng thi",
                                    examDateString = "Ngày thi",
                                    startString = "Giờ bắt đầu",
                                    endString = "Giờ kết thúc",
                                });
                            }
                            listroomexam_Preview.Add(new ListRoomExam_Preview()
                            {
                                examCode = listRoomExam_Root[i].examCode,
                                examPeriodCode = listRoomExam_Root[i].examPeriodCode,
                                subjectName = listRoomExam_Root[i].subjectName,
                                name = listRoomExam_Root[i].examRoom.room.name,
                                examDateString = listRoomExam_Root[i].examRoom.examDateString,
                                startString = listRoomExam_Root[i].examRoom.examHour.startString,
                                endString = listRoomExam_Root[i].examRoom.examHour.endString,
                            });
                        }

                        ListRoomExam.DataSource = listroomexam_Preview;
                        ListRoomExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi kết nối tới máy chủ, vui lòng thử lại sau...", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có vấn đề trong quá trình xử lý dữ liệu, vui lòng thử lại sau...", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void SemesterID_picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLearnTimeTable.DataSource = null;
            regislist_Preview = new List<Regislist_Preview>();
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (Content100 content in myDeserializedClass.content)
                {
                    foreach (Semester100 semesters in content.semesters)
                    {
                        if (SemesterID_picker.SelectedItem.ToString() == semesters.semesterCode)
                        {
                            response = client.GetAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/StudentCourseSubject/studentLoginUser/" + semesters.id).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                //List<StudentCourseSubject_Root> Root = JsonConvert.DeserializeObject<List<StudentCourseSubject_Root>>(response.Content.ReadAsStringAsync().Result);
                                File.WriteAllText(Work_path + "Semester\\" + semesters.id + ".txt", response.Content.ReadAsStringAsync().Result);
                                List<Regislist_Root> regislist_Root = JsonConvert.DeserializeObject<List<Regislist_Root>>(response.Content.ReadAsStringAsync().Result);

                                foreach (Regislist_Root Root in regislist_Root)
                                {
                                    Regislist_Preview preview = new Regislist_Preview();
                                    Regislist_CourseSubject courseSubject = Root.courseSubject;
                                    preview.numberStudent = courseSubject.numberStudent + "/" + courseSubject.maxStudent;
                                    preview.displayName = courseSubject.displayName;
                                    try
                                    {
                                        if (courseSubject.teacher == null)
                                        {
                                            preview.teacher_displayName = null;
                                        }
                                        else
                                        {
                                            preview.teacher_displayName = courseSubject.teacher.displayName;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        preview.teacher_displayName = null;
                                    }
                                    List<Regislist_Timetable> timetable = courseSubject.timetables;

                                    for (int i = 0; i < timetable.Count; i++)
                                    {
                                        if (i == 0)
                                        {
                                            preview.weekIndex = "Thứ " + timetable[i].weekIndex;
                                            preview.endString = timetable[i].endHour.endString;
                                            preview.startString = timetable[i].startHour.startString;
                                            preview.nameRoom = timetable[i].room.name;
                                            preview.startDate = ConvertJsonDateToString(timetable[i].startDate);
                                            preview.endDate = ConvertJsonDateToString(timetable[i].endDate);
                                            regislist_Preview.Add(preview);

                                        }
                                        else
                                        {
                                            regislist_Preview.Add(new Regislist_Preview()
                                            {
                                                weekIndex = "Thứ " + timetable[i].weekIndex,
                                                endString = timetable[i].endHour.endString,
                                                startString = timetable[i].startHour.startString,
                                                nameRoom = timetable[i].room.name,
                                                startDate = ConvertJsonDateToString(timetable[i].startDate),
                                                endDate = ConvertJsonDateToString(timetable[i].endDate)
                                            });
                                        }
                                    }
                                }

                                DataLearnTimeTable.DataSource = regislist_Preview;
                                DataLearnTimeTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                            }
                            else
                            {
                                MessageBox.Show("Lỗi kết nối tới máy chủ, vui lòng thử lại sau...", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu, vui lòng thử lại sau...", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void Calendar_Btn_Click(object sender, EventArgs e)
        {
            if(blockUI == false)
            {
                blockUI = true;
                DialogResult dialog = MessageBox.Show("Bạn sẽ phải đăng nhập tài khoản Google của bạn để lưu lịch, phần mềm không lấy bất kỳ thông tin đăng nhập của bạn. Nếu không đồng ý đăng nhập, vui lòng không sử dụng tính năng này.", "Lưu ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    if (regislist_Preview == null)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        MessageBox.Show("Dữ liệu môn học đã đăng ký không hợp lệ, vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.Cursor = Cursors.Default;
                        blockUI = false;
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Static_loading.Text = "Đang upload lịch lên Google Calendar, xin vui lòng không thao tác thêm!";
                        Calendar_services calendar_Services = new Calendar_services(currentUser.username, regislist_Preview);
                        calendar_Services.send_regislist();
                        await calendar_Services.GetTask();
                        blockUI = false;
                        Static_loading.Text = "Lịch đã được upload thành công.";
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private async void BtnCalendarTimeTable_Click(object sender, EventArgs e)
        {
            if (blockUI == false)
            {
                blockUI = true;
                DialogResult dialog = MessageBox.Show("Bạn sẽ phải đăng nhập tài khoản Google của bạn để lưu lịch, phần mềm không lấy bất kỳ thông tin đăng nhập của bạn. Nếu không đồng ý đăng nhập, vui lòng không sử dụng tính năng này.", "Lưu ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    if (listroomexam_Preview == null)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        MessageBox.Show("Dữ liệu lịch thi không hợp lệ, vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.Cursor = Cursors.Default;
                        blockUI = false;
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Static_loading.Text = "Đang upload lịch lên Google Calendar, xin vui lòng không thao tác thêm!";
                        Calendar_services calendar_Services = new Calendar_services(currentUser.username, listroomexam_Preview);
                        calendar_Services.send_examlist();
                        await calendar_Services.GetTask2();
                        blockUI = false;
                        Static_loading.Text = "Lịch đã được upload thành công.";
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        //Lấy thông tin semesterRegisterPrios từ displayOrder -> get dữ liệu từ pick các loại học kì khác nhau
        //Thông tin lấy offline từ tệp tin có sẵn
        private void get_schoolyears(int displayOrdercode)
        {
            Schoolyears_Root root_schoolyears = JsonConvert.DeserializeObject<Schoolyears_Root>(File.ReadAllText(Work_path + "Semester\\Schoolyears.txt"));

            foreach (Schoolyears_Content content in root_schoolyears.content)
            {
                if (content.current == true)
                {
                    schoolyearsId = content.id.ToString();

                    foreach (Schoolyears_Semester semesters in content.semesters)
                    {
                        if (semesters.isCurrent == true)
                        {
                            SemesterID = semesters.id.ToString();

                            foreach (Schoolyears_SemesterRegisterPeriod semesterRegisterPeriod in semesters.semesterRegisterPeriods)
                            {
                                if (semesterRegisterPeriod.displayOrder == displayOrdercode)
                                {
                                    registerPeriodId = semesterRegisterPeriod.id.ToString();
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

            response = client.GetAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port + "/education/api/schoolyear/1/10000").Result;
            if (response.IsSuccessStatusCode)
            {
                File.WriteAllText(Work_path + "Semester\\Schoolyears.txt", response.Content.ReadAsStringAsync().Result);

                get_schoolyears(1);

                response = client.GetAsync("https://sinhvien" + server + ".tlu.edu.vn:" + port +
                    "/education/api/student_semester_behavior_mark/student/" + schoolyearsId + "/" + SemesterID).Result;
                if (response.IsSuccessStatusCode)
                {
                    File.WriteAllText(Work_path + "Semester\\Student_semester_behavitor.txt", response.Content.ReadAsStringAsync().Result);
                }

                Static_loading.Text = "";
                this.Cursor = System.Windows.Forms.Cursors.Default;
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

            //Nhận token từ file khi form đang load và đẩy vào header
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenData.access_token);

            try
            {
                getCurrentUser_Task();
                getSemester();
                User_UI.Text = currentUser.person.displayName;

                Static_loading.Text = "Đang lấy thông tin môn học...";
                displayOrder_Picker.StartIndex = 0;

                get_findByPeriod();

                this.Text = "Education | Đăng ký học mới | Đăng ký môn";
                Main_Dashboard.SelectedIndex = 0;
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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