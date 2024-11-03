using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinhvien.tlu.Mainboard
{
    public class Regislist_Preview
    {
        public string displayName { get; set; }
        public string teacher_displayName { get; set; }
        public string numberStudent { get; set; }
        public string weekIndex { get; set; }
        public string startString { get; set; }
        public object endString { get; set; }
        public string nameRoom { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }
    public class Regislist_CourseSubject
    {
        public string code { get; set; }
        public string shortCode { get; set; }
        public List<Regislist_Timetable> timetables { get; set; }
        public int maxStudent { get; set; }
        public int minStudent { get; set; }
        public int numberStudent { get; set; }
        public int courseSubjectType { get; set; }
        public object learningSkillId { get; set; }
        public object learningSkillName { get; set; }
        public object isSelected { get; set; }
        public bool expanded { get; set; }
        public bool isGrantAll { get; set; }
        public bool isDeniedAll { get; set; }
        public object isOvelapTime { get; set; }
        public string courseYearCode { get; set; }
        public string displayName { get; set; }
        public object enrollmentClassId { get; set; }
        public object enrollmentClassCode { get; set; }
        public object numberHours { get; set; }
        public Regislist_Teacher teacher { get; set; }
        public Regislist_SemesterSubject semesterSubject { get; set; }
        public int status { get; set; }
        public int numberOfCredit { get; set; }
        public int id { get; set; }
        public object subjectId { get; set; }
    }

    public class Regislist_EndHour
    {
        public int id { get; set; }
        public string name { get; set; }
        public object start { get; set; }
        public object startString { get; set; }
        public object end { get; set; }
        public string endString { get; set; }
        public int indexNumber { get; set; }
        public object type { get; set; }
    }

    public class Regislist_Room
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public object capacity { get; set; }
        public object examCapacity { get; set; }
        public object building { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public bool duplicate { get; set; }
    }

    public class Regislist_Root
    {
        public int id { get; set; }
        public object studentName { get; set; }
        public string subjectName { get; set; }
        public string subjectCode { get; set; }
        public int subjectId { get; set; }
        public object message { get; set; }
        public int status { get; set; }
        public object totalCredit { get; set; }
        public object totalFee { get; set; }
        public object tuitionFeePerCredit { get; set; }
        public object basicTuitionFee { get; set; }
        public object subjectStatus { get; set; }
        public object examStatus { get; set; }
        public object tuitionFee { get; set; }
        public object discountPercent { get; set; }
        public object discountValue { get; set; }
        public int numberOfCredit { get; set; }
        public Regislist_CourseSubject courseSubject { get; set; }
        public bool isParent { get; set; }
        public int typeRegister { get; set; }
        public object isMainSpec { get; set; }
        public object studyTime { get; set; }
        public int regType { get; set; }
        public string createDate { get; set; }
        public object semesterSubjectId { get; set; }
        public object studentId { get; set; }
    }

    public class Regislist_Semester
    {
        public int id { get; set; }
        public string semesterCode { get; set; }
        public string semesterName { get; set; }
        public object description { get; set; }
        public object year { get; set; }
        public object startDate { get; set; }
        public object endDate { get; set; }
        public bool isCurrent { get; set; }
        public object tuitionFeePerCredit { get; set; }
        public object startRegisterDate { get; set; }
        public object endRegisterDate { get; set; }
        public object isLockRegister { get; set; }
        public int ordinalNumbers { get; set; }
    }

    public class Regislist_SemesterSubject
    {
        public int id { get; set; }
        public object semesterName { get; set; }
        public object subjectName { get; set; }
        public Regislist_Subject subject { get; set; }
        public Regislist_Semester semester { get; set; }
    }

    public class Regislist_StartHour
    {
        public int id { get; set; }
        public string name { get; set; }
        public object start { get; set; }
        public string startString { get; set; }
        public object end { get; set; }
        public object endString { get; set; }
        public int indexNumber { get; set; }
        public object type { get; set; }
    }

    public class Regislist_Subject
    {
        public int id { get; set; }
        public string subjectCode { get; set; }
        public string subjectName { get; set; }
        public string subjectNameEng { get; set; }
        public int numberOfCredit { get; set; }
    }

    public class Regislist_Teacher
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public int id { get; set; }
        public object firstName { get; set; }
        public object lastName { get; set; }
        public string displayName { get; set; } = null;
        public object shortName { get; set; }
        public object birthDate { get; set; }
        public object birthDateString { get; set; }
        public object birthPlace { get; set; }
        public object gender { get; set; }
        public object startDate { get; set; }
        public object endDate { get; set; }
        public object phoneNumber { get; set; }
        public object idNumber { get; set; }
        public object idNumberIssueBy { get; set; }
        public object idNumberIssueDate { get; set; }
        public object idNumberIssueDateString { get; set; }
        public object email { get; set; }
        public object nationality { get; set; }
        public object nativeVillage { get; set; }
        public object ethnics { get; set; }
        public object religion { get; set; }
        public object photo { get; set; }
        public object photoCropped { get; set; }
        public List<object> address { get; set; }
        public object userId { get; set; }
        public object communistYouthUnionJoinDate { get; set; }
        public object communistYouthUnionJoinDateString { get; set; }
        public object communistPartyJoinDate { get; set; }
        public object communistPartyJoinDateString { get; set; }
        public object carrer { get; set; }
        public object createIp { get; set; }
        public object modifyIp { get; set; }
        public string staffCode { get; set; }
        public List<object> positions { get; set; }
        public List<object> agreements { get; set; }
        public object user { get; set; }
        public object currentCell { get; set; }
    }

    public class Regislist_Timetable
    {
        public int id { get; set; }
        public Regislist_EndHour endHour { get; set; }
        public Regislist_StartHour startHour { get; set; }
        public Regislist_Teacher teacher { get; set; }
        public object assistantTeacher { get; set; }
        public Regislist_Room room { get; set; }
        public int weekIndex { get; set; }
        public int fromWeek { get; set; }
        public int toWeek { get; set; }
        public object start { get; set; }
        public object end { get; set; }
        public object teacherName { get; set; }
        public string roomName { get; set; }
        public object roomCode { get; set; }
        public object staffCode { get; set; }
        public object assistantStaffCode { get; set; }
        public object courseHourseStartCode { get; set; }
        public object courseHourseEndCode { get; set; }
        public object numberHours { get; set; }
        public long? startDate { get; set; }
        public long? endDate { get; set; }
        public int courseSubjectId { get; set; }
    }
}
