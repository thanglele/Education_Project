using System;
using System.Collections.Generic;

namespace Sinhvien.tlu.Subject_Information
{
    internal class Subject_Infor
    {
    }
}

namespace Sinhvien.tlu.Mainboard
{
    public class Register_Class
    {
        public string createDate { get; set; }
        public string createdBy { get; set; }
        public string modifyDate { get; set; }
        public string modifiedBy { get; set; }
        public int? id { get; set; }
        public bool? voided { get; set; } = false;
        public string code { get; set; }
        public string shortCode { get; set; }
        public int? subjectId { get; set; }
        public object subjectName { get; set; }
        public object subjectCode { get; set; }
        public object parent { get; set; }
        public object subCourseSubjects { get; set; }
        public bool? isUsingConfig { get; set; } = false;
        public bool? isFullClass { get; set; } = false;
        public object courseSubjectConfigs { get; set; }
        public List<Timetable> timetables { get; set; }
        public object semesterSubject { get; set; }
        public int? maxStudent { get; set; }
        public int? minStudent { get; set; }
        public int? numberStudent { get; set; }
        public object courseSubjectType { get; set; }
        public object learningSkillId { get; set; }
        public object learningSkillName { get; set; }
        public object learningSkillCode { get; set; }
        public bool? isSelected { get; set; } = false;
        public object children { get; set; }
        public Dictionary<string, object> hashCourseSubjects { get; set; }
        public bool? expanded { get; set; } = false;
        public bool? isGrantAll { get; set; } = false;
        public bool? isDeniedAll { get; set; } = false;
        public object trainingBase { get; set; }
        public bool? isOvelapTime { get; set; } = false;
        public List<string> overLapClasses { get; set; }
        public object courseYearId { get; set; }
        public object courseYearCode { get; set; }
        public object courseYearName { get; set; }
        public string displayName { get; set; }
        public int? numberOfCredit { get; set; }
        public object isFeeByCourseSubject { get; set; }
        public object feePerCredit { get; set; }
        public object tuitionCoefficient { get; set; }
        public object totalFee { get; set; }
        public object feePerStudent { get; set; }
        public object enrollmentClassId { get; set; }
        public object enrollmentClassCode { get; set; }
        public object numberHours { get; set; }
        public object teacher { get; set; }
        public object teacherName { get; set; }
        public object teacherCode { get; set; }
        public object startDate { get; set; }
        public object endDate { get; set; }
        public object learningMethod { get; set; }
        public int? status { get; set; }
        public object subjectExams { get; set; }
        public object semesterId { get; set; }
        public object semesterCode { get; set; }
        public object periodId { get; set; }
        public object periodName { get; set; }
        public object username { get; set; }
        public object actionTime { get; set; }
        public object logContent { get; set; }
        public int? numberLearningSkill { get; set; }
        public int? numberSubCourseSubject { get; set; }
        public bool? check { get; set; } = false;
    }
    public class Subject_Preview
    {
        public string isFullclass { get; set; }
        public string displayName { get; set; }
        public string IsOvelapTime { get; set; }
        public string Information { get; set; }
        public string numberstudent { get; set; }
        public string isSelected { get; set; }
    }

    public class RegisterPeriod
    {
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool? Voided { get; set; } = false;
        public int? StudentId { get; set; }
        public int? SemesterId { get; set; }
        public int? PeriodId { get; set; }
        public int? ClassId { get; set; }
        //public Student Student { get; set; }
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
        public bool? IsBoarder { get; set; } = false;
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
        public bool? UpdateStatus { get; set; } = false;
        public bool? IsStatusStudentExamRoom { get; set; } = false;
        public bool? IsHave { get; set; } = false;
        public bool? IsExempt { get; set; } = false;
        public int? CourseYear { get; set; }
        public string Department { get; set; }
        public string Speciality { get; set; }
        public string SpecialityEng { get; set; }
        public string SpecialityParent { get; set; }
        public string SpecialityParentEn { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public bool? IsAbleToGraduate { get; set; } = false;
        public bool? IsInGraduateList { get; set; } = false;
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
        public int? StudentType { get; set; }
        public decimal? PayedAdmissionFee { get; set; }
        public bool? UserActive { get; set; } = false;
    }

    public class address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public bool? isPrimary { get; set; } = false;
        public string addressType { get; set; } // Residential, Office, etc.
    }

    public class Profession
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool? Voided { get; set; } = false;
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DupName { get; set; }
        public string DupCode { get; set; }
        public bool? Duplicate { get; set; } = false;
    }

    public class EnrollmentClass
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool? Voided { get; set; } = false;
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public string SchoolYear { get; set; }
        public string Department { get; set; }
        public string Speciality { get; set; }
        public int? RetCode { get; set; }
        public int? CourseYear { get; set; }
        public int? NumberOfStudent { get; set; }
        public int? NumberOfFemale { get; set; }
        public int? NumberOfBoarding { get; set; }
        public object Teacher { get; set; }
        public object TrainingBase { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public int? NumberOfClasses { get; set; }
        public object Program { get; set; }
        public bool? DuplicateCode { get; set; } = false;
    }

    public class Program
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool? Voided { get; set; } = false;
        public string ProgramName { get; set; }
        public string ProgramCode { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; } = false;
    }

    public class CourseRegisterViewObject
    {
        //Được đăng kí môn
        public bool allowRegister { get; set; }
        //Được hủy đăng kí môn
        public bool IsAllowUnRegister { get; set; }
        public long? StartDate { get; set; }
        public long? EndDate { get; set; }
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
        //public int? RegisterPeriodId { get; set; }
        //public bool? HasParaSubject { get; set; }
        //public bool? IsForcedRegType { get; set; }
        //public object ParaSubjects { get; set; }
        //public object DependSubjectNames { get; set; }
        public List<CourseSubjectDto> CourseSubjectDtos { get; set; }
        public List<Timetable> Timetables { get; set; }
    }

    public class CourseSubjectDto
    {
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool? Voided { get; set; } = false;
        public string Code { get; set; }
        public string ShortCode { get; set; }
        public int? SubjectId { get; set; }
        public object SubjectName { get; set; }
        public object SubjectCode { get; set; }
        public object Parent { get; set; }
        public List<SubCourseSubjects> SubCourseSubjects { get; set; }
        public bool IsUsingConfig { get; set; }
        public bool IsFullClass { get; set; }
        public object CourseSubjectConfigs { get; set; }
        public List<Timetable> Timetables { get; set; }
        public object SemesterSubject { get; set; }
        public int? MaxStudent { get; set; }
        public int? MinStudent { get; set; }
        public int? NumberStudent { get; set; }
        public object CourseSubjectType { get; set; }
        public object LearningSkillId { get; set; }
        public object LearningSkillName { get; set; }
        public object LearningSkillCode { get; set; }
        public bool IsSelected { get; set; }
        public object Children { get; set; }
        public Dictionary<string, object> HashCourseSubjects { get; set; }
        public bool Expanded { get; set; } = false;
        public bool IsGrantAll { get; set; } = false;
        public bool IsDeniedAll { get; set; } = false;
        public object TrainingBase { get; set; }
        public bool IsOvelapTime { get; set; } = false;
        public List<string> OverLapClasses { get; set; }
        public object CourseYearId { get; set; }
        public object CourseYearCode { get; set; }
        public object CourseYearName { get; set; }
        public string DisplayName { get; set; }
        public int? NumberOfCredit { get; set; }
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
        public int? Status { get; set; }
        public object SubjectExams { get; set; }
        public object SemesterId { get; set; }
        public object SemesterCode { get; set; }
        public object PeriodId { get; set; }
        public object PeriodName { get; set; }
        public object Username { get; set; }
        public object ActionTime { get; set; }
        public object LogContent { get; set; }
        public bool Check { get; set; }
        public int? NumberSubCourseSubject { get; set; }
        public int? NumberLearningSkill { get; set; }
    }

    public class SubCourseSubjects
    {
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool? Voided { get; set; } = false;
        public string Code { get; set; }
        public string ShortCode { get; set; }
        public int? SubjectId { get; set; }
        public object SubjectName { get; set; }
        public object SubjectCode { get; set; }
        public object Parent { get; set; }
        //public object SubCourseSubjects { get; set; }
        public bool? IsUsingConfig { get; set; } = false;
        public bool IsFullClass { get; set; } = false;
        public object CourseSubjectConfigs { get; set; }
        public List<Timetable> Timetables { get; set; }
        public object SemesterSubject { get; set; }
        public int? MaxStudent { get; set; }
        public int? MinStudent { get; set; }
        public int? NumberStudent { get; set; }
        public object CourseSubjectType { get; set; }
        public object LearningSkillId { get; set; }
        public object LearningSkillName { get; set; }
        public object LearningSkillCode { get; set; }
        public bool IsSelected { get; set; } = false;
        public object Children { get; set; }
        public Dictionary<string, object> HashCourseSubjects { get; set; }
        public bool? Expanded { get; set; } = false;
        public bool IsGrantAll { get; set; } = false;
        public bool IsDeniedAll { get; set; } = false;
        public object TrainingBase { get; set; }
        public bool IsOvelapTime { get; set; } = false;
        public List<string> OverLapClasses { get; set; }
        public object CourseYearId { get; set; }
        public object CourseYearCode { get; set; }
        public object CourseYearName { get; set; }
        public string DisplayName { get; set; }
        public int? NumberOfCredit { get; set; }
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
        public int? Status { get; set; }
        public object SubjectExams { get; set; }
        public object SemesterId { get; set; }
        public object SemesterCode { get; set; }
        public object PeriodId { get; set; }
        public object PeriodName { get; set; }
        public object Username { get; set; }
        public object ActionTime { get; set; }
        public object LogContent { get; set; }
        public bool? Check { get; set; } = false;
        public int? NumberSubCourseSubject { get; set; }
        public int? NumberLearningSkill { get; set; }
    }

    public class Timetable
    {
        public int? id { get; set; }
        public hour endHour { get; set; }
        public hour startHour { get; set; }
        public Teacher teacher { get; set; }
        public Teacher assistantTeacher { get; set; }
        public room room { get; set; }
        public int? weekIndex { get; set; }
        public int? fromWeek { get; set; }
        public string FromWeekStr { get; set; }
        public int? toWeek { get; set; }
        public string ToWeekStr { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string teacherName { get; set; }
        public string roomName { get; set; }
        public string roomCode { get; set; }
        public string staffCode { get; set; }
        public string assistantStaffCode { get; set; }
        public int? courseHourseStartCode { get; set; }
        public int? courseHourseEndCode { get; set; }
        public int? numberHours { get; set; }
        public long? startDate { get; set; }
        public long? endDate { get; set; }
        public string subjectName { get; set; }
        public string courseSubjectCode { get; set; }
        public int? courseSubjectId { get; set; }
        public bool? group_by_key { get; set; } = false;
    }

    public class hour
    {
        public int? id { get; set; }
        public string name { get; set; }
        public object start { get; set; }
        public string startString { get; set; }
        public long? end { get; set; }
        public string endString { get; set; }
        public int? indexNumber { get; set; }
        public object type { get; set; }
    }

    public class Teacher
    {
        public DateTime? createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime? codifyDate { get; set; }
        public string modifiedBy { get; set; }
        public int? id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public DateTime? birthDate { get; set; }
        public string birthDateString { get; set; }
        public string birthPlace { get; set; }
        public string gender { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string phoneNumber { get; set; }
        public string idNumber { get; set; }
        public string idNumberIssueBy { get; set; }
        public DateTime? idNumberIssueDate { get; set; }
        public string idNumberIssueDateString { get; set; }
        public string email { get; set; }
        public string nationality { get; set; }
        public string nativeVillage { get; set; }
        public string ethnics { get; set; }
        public string religion { get; set; }
        public string photo { get; set; }
        public string photoCropped { get; set; }
        public List<address> address { get; set; }
        public int? userId { get; set; }
        public DateTime? communistYouthUnionJoinDate { get; set; }
        public string communistYouthUnionJoinDateString { get; set; }
        public DateTime? communistPartyJoinDate { get; set; }
        public string communistPartyJoinDateString { get; set; }
        public string carrer { get; set; }
        public string createIp { get; set; }
        public string modifyIp { get; set; }
        public string staffCode { get; set; }
        public List<position> positions { get; set; }
        public List<agreement> agreements { get; set; }
        public object user { get; set; }
        public object currentCell { get; set; }
    }

    public class room
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int? capacity { get; set; }
        public int? examCapacity { get; set; }
        public object building { get; set; }
        public string dupName { get; set; }
        public string dupCode { get; set; }
        public bool? duplicate { get; set; } = false;
    }

    public class position
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool? Voided { get; set; } = false;
        public string PositionName { get; set; }
        public string PositionCode { get; set; }
        public string Description { get; set; }
        public bool? IsPrimary { get; set; } = false;
    }

    public class agreement
    {
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? Id { get; set; }
        public bool? Voided { get; set; } = false;
        public string AgreementType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; } = false;
    }

}