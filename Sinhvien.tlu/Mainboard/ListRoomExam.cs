using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinhvien.tlu.Mainboard
{
    public class ListRoomExam_ExamHour
    {
        public int id { get; set; }
        public object start { get; set; }
        public string startString { get; set; } //Giờ bắt đầu thi
        public object end { get; set; }
        public string endString { get; set; } //Giờ kết thúc thi
        public object type { get; set; }
        public string name { get; set; } //Tiết diễn ra ca thi
        public string code { get; set; } //Tiết diễn ra ca thi
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public object examDate { get; set; }
        public object viewIndex { get; set; }
        public bool duplicate { get; set; }
    }

    public class ListRoomExam_ExamRoom
    {
        public int id { get; set; }
        public string roomCode { get; set; }
        public object startHour { get; set; }
        public object endHour { get; set; }
        public object subjectExamHour { get; set; }
        public int duration { get; set; }
        public object examDate { get; set; }
        public string examDateString { get; set; } //Ngày thi
        public int numberExpectedStudent { get; set; }
        public int numberStudent { get; set; }
        public int numberStudentAddToBag { get; set; }
        public bool isAddedToTestBag { get; set; }
        public object resultCode { get; set; }
        public bool isAddedFullToTestBag { get; set; }
        public bool isAbleToCreateBag { get; set; }
        public object studentList { get; set; }
        public object subjectName { get; set; }
        public string semesterName { get; set; }
        public string courseYearName { get; set; }
        public string registerPeriodName { get; set; }
        public ListRoomExam_ExamHour examHour { get; set; }
        public object examSkill { get; set; }
        public ListRoomExam_Room room { get; set; }
        public object viewOrder { get; set; }
    }

    public class ListRoomExam_Room
    {
        public int id { get; set; }
        public string name { get; set; } //Phòng thi
        public string code { get; set; } //Mã phòng thi
        public object capacity { get; set; }
        public object examCapacity { get; set; }
        public object building { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public bool duplicate { get; set; }
    }

    public class ListRoomExam_Root
    {
        public int id { get; set; }
        public int status { get; set; }
        public string examCode { get; set; } //Số báo danh
        public int examCodeNumber { get; set; } //Số báo danh 2
        public object markingCode { get; set; }
        public object markingCodeNumber { get; set; }
        public string examPeriodCode { get; set; } //Mã kỳ thi
        public ListRoomExam_ExamRoom examRoom { get; set; }
        public object testBag { get; set; }
        public object isExempt { get; set; }
        public object className { get; set; }
        public object classCode { get; set; }
        public object specialPoint { get; set; }
        public int examRound { get; set; }
        public object subjectCredit { get; set; }
        public string subjectName { get; set; } //Tên môn học
        public string studentCode { get; set; } //Mã sinh viên
        public int studyTime { get; set; } //Lần học
        public object studentExamId { get; set; }
        public object examStatus { get; set; }
        public int courseSubjectId { get; set; }
        public object studentId { get; set; }
        public object typeExam { get; set; }
        public object delaySemesterSubjectId { get; set; }
    }

    public class ListRoomExam_Preview
    {
        public string examPeriodCode { get; set; } //Mã kỳ thi
        public string subjectName { get; set; } //Tên môn học
        public string examCode { get; set; } //Số báo danh
        public string name { get; set; } //Phòng thi
        public string examDateString { get; set; } //Ngày thi
        public string startString { get; set; } //Giờ bắt đầu thi
        public string endString { get; set; } //Giờ kết thúc thi
    }
}
