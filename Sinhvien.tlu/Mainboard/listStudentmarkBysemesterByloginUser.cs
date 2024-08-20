using System.Collections.Generic;

namespace Sinhvien.tlu.Mainboard
{
    public class viewListStudentMark
    {
        public int STT { get; set; }
        public string mahocphan {  get; set; }
        public string tenhocphan { get; set; }
        public int? sotinchi { get; set; }
        public int? lanhoc {  get; set; }
        public int? lanthi { get; set; }
        public bool tinhdiem { get; set; }
        public string danhgia { get; set; }
        public string masinhvien {  get; set; }
        public double? diemquatrinh {  get; set; }
        public double? diemthi { get; set; }
        public double? tongkethocphan { get; set; }
        public string diemchu {  get; set; }
    }
    public class listStudentmarkBysemesterByloginUser_Detail
    {
        public listStudentmarkBysemesterByloginUser_Student student { get; set; }
        public object originalMark { get; set; }
        public double? mark { get; set; }
        public listStudentmarkBysemesterByloginUser_Subject subject { get; set; }
        public object isLock { get; set; }
        public listStudentmarkBysemesterByloginUser_StudentCourseSubject studentCourseSubject { get; set; }
        public object markType { get; set; }
        public int? examRound { get; set; }
        public double? coeffiecient { get; set; }
        public listStudentmarkBysemesterByloginUser_SubjectExam subjectExam { get; set; }
        public object isSelected { get; set; }
        public object markingCode { get; set; }
        public object studyTime { get; set; }
        public listStudentmarkBysemesterByloginUser_StudentExamRoom studentExamRoom { get; set; }
        public listStudentmarkBysemesterByloginUser_SemesterSubject semesterSubject { get; set; }
        public object oldMark { get; set; }
        public object updateType { get; set; }
        public object specialPoint { get; set; }
        public string displaySemester { get; set; }
        public object markingCodeNumber { get; set; }
        public object examCodeNumber { get; set; }
        public object subjectStatus { get; set; }
        public object note { get; set; }
        public object examStatus { get; set; }
        public object studentSubjectMarkId { get; set; }
        public object studentSubjectMark { get; set; }
        public object historyModifi { get; set; }
        public int? id { get; set; }
        public bool? old { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_EnrollmentClass
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public object id { get; set; }
        public bool? voided { get; set; }
        public object className { get; set; }
        public object classCode { get; set; }
        public object schoolYear { get; set; }
        public object department { get; set; }
        public object speciality { get; set; }
        public int? retCode { get; set; }
        public object courseyear { get; set; }
        public object numberOfStudent { get; set; }
        public object numberOfFemale { get; set; }
        public object numberOfBoarding { get; set; }
        public object teacher { get; set; }
        public object trainingBase { get; set; }
        public int? pageIndex { get; set; }
        public int? pageSize { get; set; }
        public int? numberOfClasses { get; set; }
        public object program { get; set; }
        public bool? duplicateCode { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_ExamStatus
    {
        public int? id { get; set; }
        public string note { get; set; }
        public string penalties { get; set; }
        public double? mark { get; set; }
        public bool? suspend { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_FatherProfession
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public object id { get; set; }
        public bool? voided { get; set; }
        public object name { get; set; }
        public object code { get; set; }
        public object description { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public bool? duplicate { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_MotherProfession
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public object id { get; set; }
        public bool? voided { get; set; }
        public object name { get; set; }
        public object code { get; set; }
        public object description { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public bool? duplicate { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_Root
    {
        public int? id { get; set; }
        public listStudentmarkBysemesterByloginUser_Student student { get; set; }
        public listStudentmarkBysemesterByloginUser_Subject subject { get; set; }
        public listStudentmarkBysemesterByloginUser_Semester semester { get; set; }
        public object studentId { get; set; }
        public object subjectId { get; set; }
        public object semesterId { get; set; }
        public double? mark { get; set; }
        public int? examRound { get; set; }
        public int? studyTime { get; set; }
        public List<listStudentmarkBysemesterByloginUser_Detail> details { get; set; }
        public object status { get; set; }
        public double? mark4 { get; set; }
        public string charMark { get; set; }
        public bool? isAccepted { get; set; }
        public string note { get; set; }
        public bool? isCounted { get; set; }
        public int? result { get; set; }
        public object equivalentSubjectId { get; set; }
        public object equivalentSubjectCode { get; set; }
        public object equivalentSubjectName { get; set; }
        public object isInProgram { get; set; }
        public int? examStatus { get; set; }
        public object examStatusCode { get; set; }
        public bool? isPublished { get; set; }
        public bool? saveStatus { get; set; }
        public double? markQT { get; set; }
        public double? markTHI { get; set; }
        public object isMarkEquivalent { get; set; }
        public bool? isConditionalMark { get; set; }
        public string markFormula { get; set; }
        public object calculator { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_Semester
    {
        public int? id { get; set; }
        public string semesterCode { get; set; }
        public string semesterName { get; set; }
        public object description { get; set; }
        public object schoolYear { get; set; }
        public object year { get; set; }
        public object startDate { get; set; }
        public object endDate { get; set; }
        public object isCurrent { get; set; }
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
        public object behaviorMarkStart { get; set; }
        public object behaviorMarkEnd { get; set; }
        public object semesterRegisterPeriods { get; set; }
        public object examRegisterPeriods { get; set; }
        public object typeMarkRecognition { get; set; }
        public object educationStart { get; set; }
        public object educationEnd { get; set; }
        public object studentStart { get; set; }
        public object studentEnd { get; set; }
        public object trainingBaseId { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_SemesterSubject
    {
        public List<int> createDate { get; set; }
        public string createdBy { get; set; }
        public List<int> modifyDate { get; set; }
        public string modifiedBy { get; set; }
        public int? id { get; set; }
        public bool? voided { get; set; }
        public object semester { get; set; }
        public object subSemester { get; set; }
        public object subject { get; set; }
        public int? numberCourse { get; set; }
        public double? tuitionFeeCoefficient { get; set; }
        public double? tuitionFee { get; set; }
        public double? remunerationCoefficient { get; set; }
        public double? remunerationFee { get; set; }
        public object courseSubjects { get; set; }
        public object trainingBaseSemesterSubjects { get; set; }
        public object semesterName { get; set; }
        public object subjectName { get; set; }
        public object totalSubjectName { get; set; }
        public int? numberCurrentCourseSubject { get; set; }
        public object generateCourseSubject { get; set; }
        public object maxNumberStudentPerParentCourse { get; set; }
        public object minNumberStudentPerParentCourse { get; set; }
        public object maxNumberStudentPerChildCourse { get; set; }
        public object minNumberStudentPerChildCourse { get; set; }
        public int? defaultParentCourseType { get; set; }
        public int? defaultChildCourseType { get; set; }
        public int? numberChildCourse { get; set; }
        public object subjectExams { get; set; }
        public object courseYearDto { get; set; }
        public object mainLearningSkill { get; set; }
        public object learningSkills { get; set; }
        public object numberMainSkillHours { get; set; }
        public object totalNumberHours { get; set; }
        public object isFeeBySubject { get; set; }
        public object useByCourseYear { get; set; }
        public int? retCode { get; set; }
        public object semesterId { get; set; }
        public object subjectId { get; set; }
        public object registerPeriod { get; set; }
        public object registerPeriodName { get; set; }
        public object courseYearId { get; set; }
        public object registerPeriodId { get; set; }
        public bool? isUsingLearningSkill { get; set; }
        public object name { get; set; }
        public object formular { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_Student
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public int? id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string displayName { get; set; }
        public object shortName { get; set; }
        public object birthDate { get; set; }
        public object birthDateString { get; set; }
        public object birthPlace { get; set; }
        public string gender { get; set; }
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
        public string studentCode { get; set; }
        public object highSchoolGraduationYear { get; set; }
        public object yearOfAdmission { get; set; }
        public object fatherFullName { get; set; }
        public object motherFullName { get; set; }
        public object fatherBirthDate { get; set; }
        public object fatherBirthDateString { get; set; }
        public object motherBirthDate { get; set; }
        public object motherBirthDateString { get; set; }
        public object isBoarder { get; set; }
        public listStudentmarkBysemesterByloginUser_FatherProfession fatherProfession { get; set; }
        public listStudentmarkBysemesterByloginUser_MotherProfession motherProfession { get; set; }
        public object fatherPhoneNumber { get; set; }
        public object motherPhoneNumber { get; set; }
        public listStudentmarkBysemesterByloginUser_EnrollmentClass enrollmentClass { get; set; }
        public object bankAccount { get; set; }
        public object bankName { get; set; }
        public object studentObject { get; set; }
        public List<object> programs { get; set; }
        public object studentObjectStudents { get; set; }
        public object studentObjectStudentSemesters { get; set; }
        public object studentStudentPrivateDocumentDtos { get; set; }
        public object studentDecisions { get; set; }
        public object user { get; set; }
        public object candidateProfile { get; set; }
        public object status { get; set; }
        public bool? updateStatus { get; set; }
        public bool? isStatusStudentExamRoom { get; set; }
        public bool? isHave { get; set; }
        public bool? isExempt { get; set; }
        public object courseYear { get; set; }
        public object department { get; set; }
        public object speciality { get; set; }
        public object specialityEng { get; set; }
        public object specialityParent { get; set; }
        public object specialityParentEn { get; set; }
        public string className { get; set; }
        public string classCode { get; set; }
        public object isAbleToGraduate { get; set; }
        public object isInGraduateList { get; set; }
        public object subjectStatus { get; set; }
        public object studentCourseSubjectId { get; set; }
        public object viewStudentVoucherReceivePayDto { get; set; }
        public object studentTuitionFeeCalculateDto { get; set; }
        public object educationLevel { get; set; }
        public object educationLevelEn { get; set; }
        public object educationType { get; set; }
        public object educationTypeEng { get; set; }
        public object studentStatusStudentSemesters { get; set; }
        public object statusName { get; set; }
        public object statusSemesterName { get; set; }
        public object note { get; set; }
        public object studentStatus { get; set; }
        public int? studentType { get; set; }
        public object payedAdmissionFee { get; set; }
        public object userActive { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_StudentCourseSubject
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public int? id { get; set; }
        public bool? voided { get; set; }
        public object studentId { get; set; }
        public object studentName { get; set; }
        public object studentCode { get; set; }
        public object subjectName { get; set; }
        public object subjectCode { get; set; }
        public object subjectId { get; set; }
        public object courseSubject { get; set; }
        public object courseSubjectId { get; set; }
        public object courseSubjectName { get; set; }
        public object student { get; set; }
        public object message { get; set; }
        public int? status { get; set; }
        public object totalCredit { get; set; }
        public object totalFee { get; set; }
        public object tuitionFeePerCredit { get; set; }
        public object basicTuitionFee { get; set; }
        public object subjectStatus { get; set; }
        public object examStatus { get; set; }
        public object tuitionFee { get; set; }
        public object studentBirthDate { get; set; }
        public object discountPercent { get; set; }
        public object discountValue { get; set; }
        public int? numberOfCredit { get; set; }
        public object courseRegister { get; set; }
        public int? typeRegister { get; set; }
        public object isMainSpec { get; set; }
        public object studyTime { get; set; }
        public int? regType { get; set; }
        public double? cancelFeePercent { get; set; }
        public object isSelected { get; set; }
        public object traniningBaseCourseSubject { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_StudentExamRoom
    {
        public int? id { get; set; }
        public int? status { get; set; }
        public string examCode { get; set; }
        public int? examCodeNumber { get; set; }
        public object markingCode { get; set; }
        public object markingCodeNumber { get; set; }
        public object studentCourseSubject { get; set; }
        public object examPeriodCode { get; set; }
        public object examRoom { get; set; }
        public object testBag { get; set; }
        public object student { get; set; }
        public object isExempt { get; set; }
        public object className { get; set; }
        public object classCode { get; set; }
        public object specialPoint { get; set; }
        public object examRound { get; set; }
        public object subjectCredit { get; set; }
        public object subjectName { get; set; }
        public object studentCode { get; set; }
        public object studyTime { get; set; }
        public object studentExamId { get; set; }
        public listStudentmarkBysemesterByloginUser_ExamStatus examStatus { get; set; }
        public object courseSubjectId { get; set; }
        public object studentId { get; set; }
        public object typeExam { get; set; }
        public object delaySemesterSubjectId { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_Subject
    {
        public int? id { get; set; }
        public string subjectCode { get; set; }
        public object defineCode { get; set; }
        public string subjectName { get; set; }
        public string subjectNameEng { get; set; }
        public int? numberOfCredit { get; set; }
        public object departmentId { get; set; }
        public object departmentName { get; set; }
        public object departmentCode { get; set; }
        public object departmentParentName { get; set; }
        public int? retCode { get; set; }
        public object isCurrentlyUsing { get; set; }
        public object prerequisiteSubjects { get; set; }
        public object exams { get; set; }
        public object department { get; set; }
        public object subjectLearningSkillDtos { get; set; }
        public object totalSubjectName { get; set; }
        public bool? isCalculateMark { get; set; }
        public int? subjectType { get; set; }
        public object textSearch { get; set; }
        public object subjectLevelTypes { get; set; }
        public object voided { get; set; }
        public object examSkill { get; set; }
        public object examTime { get; set; }
        public object @checked { get; set; }
        public object feeType { get; set; }
        public object specilityId { get; set; }
        public object enrollmentClassId { get; set; }
        public object courseYearId { get; set; }
        public object isCollapse { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_SubjectExam
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public object subject { get; set; }
        public double coefficient { get; set; }
        public int? inputMarkType { get; set; }
        public object examType { get; set; }
        public object semesterSubject { get; set; }
        public object subjectExamName { get; set; }
        public object type { get; set; }
        public object semesterName { get; set; }
        public listStudentmarkBysemesterByloginUser_SubjectExamType subjectExamType { get; set; }
        public object coffi { get; set; }
        public object courseSubject { get; set; }
        public object voided { get; set; }
        public object nodeId { get; set; }
        public object nodeType { get; set; }
    }

    public class listStudentmarkBysemesterByloginUser_SubjectExamType
    {
        public object name { get; set; }
        public object code { get; set; }
        public object note { get; set; }
        public object type { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public int? id { get; set; }
        public bool? duplicate { get; set; }
    }
}
