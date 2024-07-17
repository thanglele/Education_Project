using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using Sinhvien.tlu.Mainboard;
using System.Security.RightsManagement;
using System.Xml;

namespace Sinhvien.tlu.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // Giả sử jsonString chứa dữ liệu JSON của bạn
            string jsonString = System.IO.File.ReadAllText("Semester\\registerPeriodId.txt");
            var registerPeriod = JsonConvert.DeserializeObject<RegisterPeriod>(jsonString);

            // Hiển thị dữ liệu lên DataGridView
            DisplayData(registerPeriod);
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

        private void DisplayData(RegisterPeriod registerPeriod)
        {
            var subject_preview = new List<Subject_Preview>();

            foreach (var Subject_name in registerPeriod.CourseRegisterViewObject.ListSubjectRegistrationDtos)
            {
                foreach (var Sub_Course in Subject_name.CourseSubjectDtos)
                {
                    var Subject_Information = new Subject_Preview();
                    if(Sub_Course.IsFullClass)
                    {
                        Subject_Information.isFullclass = "Lớp đã đầy";
                    }
                    Subject_Information.displayName = Sub_Course.DisplayName;
                    if(Sub_Course.IsOvelapTime)
                    {
                        Subject_Information.IsOvelapTime = "Xuất hiện lớp khác cùng thời điểm học!";
                    }
                    Subject_Information.isSelected = Sub_Course.IsSelected;
                    Subject_Information.numberstudent = Sub_Course.NumberStudent + "/" + Sub_Course.MaxStudent;
                    subject_preview.Add(Subject_Information);

                    subject_preview.Add(new Subject_Preview()
                    {
                        isFullclass = "",
                        displayName = "Tuần",
                        IsOvelapTime = "Thời gian",
                        Information = "Phòng",
                        numberstudent = "Giáo viên"
                    });

                    foreach (var timetable in Sub_Course.Timetables)
                    {
                        subject_preview.Add(new Subject_Preview()
                        {
                            isFullclass = "",
                            displayName = "Thứ " + timetable.WeekIndex + ", " + ConvertJsonDateToString(timetable.StartDate) + " -> " + ConvertJsonDateToString(timetable.EndDate),
                            IsOvelapTime = timetable.Start + " -> " + timetable.End,
                            Information = timetable.RoomName,
                            numberstudent = timetable.TeacherName
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
                                Course_Subject_Information.IsOvelapTime = "Xuất hiện lớp khác cùng thời điểm học!";
                            }
                            Course_Subject_Information.isSelected = Course_sub_Course.IsSelected;
                            Course_Subject_Information.numberstudent = Course_sub_Course.NumberStudent + "/" + Course_sub_Course.MaxStudent;
                            subject_preview.Add(Course_Subject_Information);

                            subject_preview.Add(new Subject_Preview()
                            {
                                isFullclass = "",
                                displayName = "Tuần",
                                IsOvelapTime = "Thời gian",
                                Information = "Phòng",
                                numberstudent = "Giáo viên"
                            });

                            foreach (var Course_timetables in Course_sub_Course.Timetables)
                            {
                                subject_preview.Add(new Subject_Preview()
                                {
                                    isFullclass = "",
                                    displayName = "Thứ " + Course_timetables.WeekIndex + ", " + ConvertJsonDateToString(Course_timetables.StartDate) + " -> " + ConvertJsonDateToString(Course_timetables.EndDate),
                                    IsOvelapTime = Course_timetables.Start + " -> " + Course_timetables.End,
                                    Information = Course_timetables.RoomName,
                                    numberstudent = Course_timetables.TeacherName
                                });
                            }
                        }
                    }
                }
            }
            dataGridViewTimetables.DataSource = subject_preview;
        }
    }

}

public class Subject_Preview
{
    public string isFullclass { get; set; }
    public string displayName { get; set; }
    public string IsOvelapTime { get; set; }
    public string Information { get; set; }
    public string numberstudent { get; set; }
    public bool isSelected { get; set; }
}

public class RegisterPeriod
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool Voided { get; set; }
        public int StudentId { get; set; }
        public int? SemesterId { get; set; }
        public int PeriodId { get; set; }
        public int? ClassId { get; set; }
        public Student Student { get; set; }
        public CourseRegisterViewObject CourseRegisterViewObject { get; set; }
    }

public class Student
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string ShortName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthDateString { get; set; }
        public string BirthPlace { get; set; }
        public string Gender { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string IdNumberIssueBy { get; set; }
        public DateTime? IdNumberIssueDate { get; set; }
        public string IdNumberIssueDateString { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string NativeVillage { get; set; }
        public string Ethnics { get; set; }
        public string Religion { get; set; }
        public string Photo { get; set; }
        public string PhotoCropped { get; set; }
        public List<Address> Address { get; set; }
        public int? UserId { get; set; }
        public DateTime? CommunistYouthUnionJoinDate { get; set; }
        public string CommunistYouthUnionJoinDateString { get; set; }
        public DateTime? CommunistPartyJoinDate { get; set; }
        public string CommunistPartyJoinDateString { get; set; }
        public string Carrer { get; set; }
        public string CreateIp { get; set; }
        public string ModifyIp { get; set; }
        public string StudentCode { get; set; }
        public int? HighSchoolGraduationYear { get; set; }
        public int? YearOfAdmission { get; set; }
        public string FatherFullName { get; set; }
        public string MotherFullName { get; set; }
        public DateTime? FatherBirthDate { get; set; }
        public string FatherBirthDateString { get; set; }
        public DateTime? MotherBirthDate { get; set; }
        public string MotherBirthDateString { get; set; }
        public bool? IsBoarder { get; set; }
        public Profession FatherProfession { get; set; }
        public Profession MotherProfession { get; set; }
        public string FatherPhoneNumber { get; set; }
        public string MotherPhoneNumber { get; set; }
        public EnrollmentClass EnrollmentClass { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public object StudentObject { get; set; }
        public List<Program> Programs { get; set; }
        public object StudentObjectStudents { get; set; }
        public object StudentObjectStudentSemesters { get; set; }
        public object StudentStudentPrivateDocumentDtos { get; set; }
        public object StudentDecisions { get; set; }
        public object User { get; set; }
        public object CandidateProfile { get; set; }
        public object Status { get; set; }
        public bool UpdateStatus { get; set; }
        public bool IsStatusStudentExamRoom { get; set; }
        public bool IsHave { get; set; }
        public bool IsExempt { get; set; }
        public int? CourseYear { get; set; }
        public string Department { get; set; }
        public string Speciality { get; set; }
        public string SpecialityEng { get; set; }
        public string SpecialityParent { get; set; }
        public string SpecialityParentEn { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public bool? IsAbleToGraduate { get; set; }
        public bool? IsInGraduateList { get; set; }
        public object SubjectStatus { get; set; }
        public int? StudentCourseSubjectId { get; set; }
        public object ViewStudentVoucherReceivePayDto { get; set; }
        public object StudentTuitionFeeCalculateDto { get; set; }
        public string EducationLevel { get; set; }
        public string EducationLevelEn { get; set; }
        public string EducationType { get; set; }
        public string EducationTypeEng { get; set; }
        public object StudentStatusStudentSemesters { get; set; }
        public string StatusName { get; set; }
        public string StatusSemesterName { get; set; }
        public string Note { get; set; }
        public int StudentType { get; set; }
        public decimal? PayedAdmissionFee { get; set; }
        public bool? UserActive { get; set; }
    }

public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool IsPrimary { get; set; }
        public string AddressType { get; set; } // Residential, Office, etc.
    }

public class Profession
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool Voided { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DupName { get; set; }
        public string DupCode { get; set; }
        public bool Duplicate { get; set; }
    }

public class EnrollmentClass
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool Voided { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public string SchoolYear { get; set; }
        public string Department { get; set; }
        public string Speciality { get; set; }
        public int RetCode { get; set; }
        public int? CourseYear { get; set; }
        public int? NumberOfStudent { get; set; }
        public int? NumberOfFemale { get; set; }
        public int? NumberOfBoarding { get; set; }
        public object Teacher { get; set; }
        public object TrainingBase { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int NumberOfClasses { get; set; }
        public object Program { get; set; }
        public bool DuplicateCode { get; set; }
    }

public class Program
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool Voided { get; set; }
        public string ProgramName { get; set; }
        public string ProgramCode { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

public class CourseRegisterViewObject
    {
        public bool IsAllowUnRegister { get; set; }
        public long StartDate { get; set; }
        public long EndDate { get; set; }
        public string StartDateString { get; set; }
        public string EndDateString { get; set; }
        public object StartUnDate { get; set; }
        public object EndUnDate { get; set; }
        public object StartUnDateString { get; set; }
        public object EndUnDateString { get; set; }
        public List<SubjectRegistrationDto> ListSubjectRegistrationDtos { get; set; }
    }

public class SubjectRegistrationDto
    {
        public string SubjectName { get; set; }
        public int RegisterPeriodId { get; set; }
        public bool HasParaSubject { get; set; }
        public bool IsForcedRegType { get; set; }
        public object ParaSubjects { get; set; }
        public object DependSubjectNames { get; set; }
        public List<CourseSubjectDto> CourseSubjectDtos { get; set; }
        public List<Timetable> Timetables { get; set; }
    }

public class CourseSubjectDto
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int Id { get; set; }
        public bool Voided { get; set; }
        public string Code { get; set; }
        public string ShortCode { get; set; }
        public int SubjectId { get; set; }
        public object SubjectName { get; set; }
        public object SubjectCode { get; set; }
        public object Parent { get; set; }
        public List<SubCourseSubjects> SubCourseSubjects { get; set; }
        public bool IsUsingConfig { get; set; }
        public bool IsFullClass { get; set; }
        public object CourseSubjectConfigs { get; set; }
        public List<Timetable> Timetables { get; set; }
        public object SemesterSubject { get; set; }
        public int MaxStudent { get; set; }
        public int MinStudent { get; set; }
        public int NumberStudent { get; set; }
        public object CourseSubjectType { get; set; }
        public object LearningSkillId { get; set; }
        public object LearningSkillName { get; set; }
        public object LearningSkillCode { get; set; }
        public bool IsSelected { get; set; }
        public object Children { get; set; }
        public Dictionary<string, object> HashCourseSubjects { get; set; }
        public bool Expanded { get; set; }
        public bool IsGrantAll { get; set; }
        public bool IsDeniedAll { get; set; }
        public object TrainingBase { get; set; }
        public bool IsOvelapTime { get; set; }
        public List<string> OverLapClasses { get; set; }
        public object CourseYearId { get; set; }
        public object CourseYearCode { get; set; }
        public object CourseYearName { get; set; }
        public string DisplayName { get; set; }
        public int NumberOfCredit { get; set; }
        public object IsFeeByCourseSubject { get; set; }
        public object FeePerCredit { get; set; }
        public object TuitionCoefficient { get; set; }
        public object TotalFee { get; set; }
        public object FeePerStudent { get; set; }
        public object EnrollmentClassId { get; set; }
        public object EnrollmentClassCode { get; set; }
        public object NumberHours { get; set; }
        public object Teacher { get; set; }
        public object TeacherName { get; set; }
        public object TeacherCode { get; set; }
        public object StartDate { get; set; }
        public object EndDate { get; set; }
        public object LearningMethod { get; set; }
        public int Status { get; set; }
        public object SubjectExams { get; set; }
        public object SemesterId { get; set; }
        public object SemesterCode { get; set; }
        public object PeriodId { get; set; }
        public object PeriodName { get; set; }
        public object Username { get; set; }
        public object ActionTime { get; set; }
        public object LogContent { get; set; }
        public bool Check { get; set; }
        public int NumberSubCourseSubject { get; set; }
        public int NumberLearningSkill { get; set; }
    }

public class SubCourseSubjects
{
    public string Code { get; set; }
    public string ShortCode { get; set; }
    public bool IsFullClass { get; set; }
    public int MaxStudent { get; set; }
    public int MinStudent { get; set; }
    public int NumberStudent { get; set; }
    public bool IsOvelapTime { get; set; }
    public bool IsSelected { get; set; }
    public string DisplayName { get; set; }
    public List<Timetable> Timetables { get; set; }
}

public class Timetable
    {
        public int Id { get; set; }
        public Hour EndHour { get; set; }
        public Hour StartHour { get; set; }
        public Teacher Teacher { get; set; }
        public Teacher AssistantTeacher { get; set; }
        public Room Room { get; set; }
        public int WeekIndex { get; set; }
        public int FromWeek { get; set; }
        public string FromWeekStr { get; set; }
        public int ToWeek { get; set; }
        public string ToWeekStr { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string TeacherName { get; set; }
        public string RoomName { get; set; }
        public string RoomCode { get; set; }
        public string StaffCode { get; set; }
        public string AssistantStaffCode { get; set; }
        public int CourseHourseStartCode { get; set; }
        public int CourseHourseEndCode { get; set; }
        public int? NumberHours { get; set; }
        public long? StartDate { get; set; }
        public long? EndDate { get; set; }
        public string SubjectName { get; set; }
        public string CourseSubjectCode { get; set; }
        public int? CourseSubjectId { get; set; }
    }

public class Hour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Start { get; set; }
        public string StartString { get; set; }
        public long? End { get; set; }
        public string EndString { get; set; }
        public int IndexNumber { get; set; }
        public object Type { get; set; }
    }

public class Teacher
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string ShortName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthDateString { get; set; }
        public string BirthPlace { get; set; }
        public string Gender { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string IdNumberIssueBy { get; set; }
        public DateTime? IdNumberIssueDate { get; set; }
        public string IdNumberIssueDateString { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string NativeVillage { get; set; }
        public string Ethnics { get; set; }
        public string Religion { get; set; }
        public string Photo { get; set; }
        public string PhotoCropped { get; set; }
        public List<Address> Address { get; set; }
        public int? UserId { get; set; }
        public DateTime? CommunistYouthUnionJoinDate { get; set; }
        public string CommunistYouthUnionJoinDateString { get; set; }
        public DateTime? CommunistPartyJoinDate { get; set; }
        public string CommunistPartyJoinDateString { get; set; }
        public string Carrer { get; set; }
        public string CreateIp { get; set; }
        public string ModifyIp { get; set; }
        public string StaffCode { get; set; }
        public List<Position> Positions { get; set; }
        public List<Agreement> Agreements { get; set; }
        public object User { get; set; }
        public object CurrentCell { get; set; }
    }

public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Capacity { get; set; }
        public int? ExamCapacity { get; set; }
        public object Building { get; set; }
        public string DupName { get; set; }
        public string DupCode { get; set; }
        public bool Duplicate { get; set; }
    }

public class Position
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool Voided { get; set; }
        public string PositionName { get; set; }
        public string PositionCode { get; set; }
        public string Description { get; set; }
        public bool IsPrimary { get; set; }
    }

public class Agreement
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool Voided { get; set; }
        public string AgreementType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
