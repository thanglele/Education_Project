using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinhvien.tlu.Mainboard
{
    public class Child100
    {
        public object id { get; set; }
        public object name { get; set; }
        public string code { get; set; }
        public object year { get; set; }
        public bool? current { get; set; }
        public object startDate { get; set; }
        public object endDate { get; set; }
        public object children { get; set; }
        public string displayName { get; set; }
        public int semesterId { get; set; }
        public int isSemester { get; set; }
        public object semesters { get; set; }
    }

    public class Content100
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int year { get; set; }
        public bool? current { get; set; }
        public object startDate { get; set; }
        public object endDate { get; set; }
        public List<Child100> children { get; set; }
        public string displayName { get; set; }
        public object semesterId { get; set; }
        public int isSemester { get; set; }
        public List<Semester100> semesters { get; set; }
    }

    public class Root100
    {
        public List<Content100> content { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public bool? last { get; set; }
        public int size { get; set; }
        public int number { get; set; }
        public int numberOfElements { get; set; }
        public object sort { get; set; }
        public bool? first { get; set; }
    }

    public class Semester100
    {
        public int id { get; set; }
        public string semesterCode { get; set; }
        public string semesterName { get; set; }
        public object description { get; set; }
        public object schoolYear { get; set; }
        public object year { get; set; }
        public object startDate { get; set; }
        public object endDate { get; set; }
        public bool? isCurrent { get; set; }
        public object parent { get; set; }
        public object children { get; set; }
        public object subSemesters { get; set; }
        public object tuitionFeePerCredit { get; set; }
        public object startRegisterDate { get; set; }
        public object startRegisterDateString { get; set; }
        public object endRegisterDate { get; set; }
        public object endRegisterDateString { get; set; }
        public object isLockRegister { get; set; }
        public object ordinalNumbers { get; set; }
        public long? behaviorMarkStart { get; set; }
        public long? behaviorMarkEnd { get; set; }
        public List<SemesterRegisterPeriod100> semesterRegisterPeriods { get; set; }
        public object examRegisterPeriods { get; set; }
        public object typeMarkRecognition { get; set; }
        public object educationStart { get; set; }
        public object educationEnd { get; set; }
        public object studentStart { get; set; }
        public object studentEnd { get; set; }
        public object trainingBaseId { get; set; }
    }

    public class SemesterRegisterPeriod100
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public int id { get; set; }
        public bool? voided { get; set; }
        public object semester { get; set; }
        public string name { get; set; }
        public int displayOrder { get; set; }
        public long? startRegisterTime { get; set; }
        public long? endRegisterTime { get; set; }
        public long? endUnRegisterTime { get; set; }
        public string startRegisterTimeString { get; set; }
        public string endRegisterTimeString { get; set; }
        public string endUnRegisterTimeString { get; set; }
        public object isLockRegister { get; set; }
        public object examPeriods { get; set; }
    }
}