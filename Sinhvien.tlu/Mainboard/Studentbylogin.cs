using System.Collections.Generic;

namespace Sinhvien.tlu.Mainboard
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Studentbylogin_Address
    {
        public int? id { get; set; }
        public string address { get; set; }
        public object address1 { get; set; }
        public object city { get; set; }
        public object province { get; set; }
        public object country { get; set; }
        public object postalCode { get; set; }
        public object latitude { get; set; }
        public object longitude { get; set; }
        public int? personId { get; set; }
        public object type { get; set; }
        public object provinceId { get; set; }
        public object cityId { get; set; }
        public object villageId { get; set; }
    }

    public class Studentbylogin_CandidateProfile
    {
        public int? id { get; set; }
        public string candidateCode { get; set; }
        public Studentbylogin_Student student { get; set; }
        public object studentObjectCode { get; set; }
        public object studentObject { get; set; }
        public int? admissionsYear { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string displayName { get; set; }
        public bool? isEnroll { get; set; }
        public bool? isSpecialtyCNTT { get; set; }
        public object wishToEnroll1 { get; set; }
        public object wishToEnroll2 { get; set; }
        public object wishToEnroll3 { get; set; }
        public object wishToEnroll4 { get; set; }
        public object country { get; set; }
        public string studentCode { get; set; }
        public object trainingBaseId { get; set; }
        public double firstSubjectScore { get; set; }
        public object firstSubjectName { get; set; }
        public object firstNameSubject { get; set; }
        public double secondSubjectScore { get; set; }
        public object secondSubjectName { get; set; }
        public object secondNameSubject { get; set; }
        public double thirdSubjectScore { get; set; }
        public object thirdSubjectName { get; set; }
        public object thirdNameSubject { get; set; }
        public double totalScore { get; set; }
        public object dtc0 { get; set; }
        public object reason { get; set; }
        public object firstSpecialityDetailCode { get; set; }
        public string firstSpecialityCode { get; set; }
        public object secondSpecialityCode { get; set; }
        public string gender { get; set; }
        public int? highSchoolGraduationYear { get; set; }
        public object highSchoolGraduation { get; set; }
        public object highSchoolGraduationPlace { get; set; }
        public object highSchoolGrade { get; set; }
        public object highSchoolConduct { get; set; }
        public long birthDate { get; set; }
        public string birthDateString { get; set; }
        public object gradeTen { get; set; }
        public object gradeEleven { get; set; }
        public object gradeTwelve { get; set; }
        public object note { get; set; }
        public string areaCode { get; set; }
        public string idNumber { get; set; }
        public string phoneNumber { get; set; }
        public object priorityGroup { get; set; }
        public string contactAddress { get; set; }
        public string publicAddress { get; set; }
        public string provinceCode { get; set; }
        public string provinceName { get; set; }
        public string districtCode { get; set; }
        public string districtName { get; set; }
        public object wardCode { get; set; }
        public string wardName { get; set; }
        public object examRoom { get; set; }
        public Studentbylogin_Province province { get; set; }
        public Studentbylogin_District district { get; set; }
        public Studentbylogin_Ward ward { get; set; }
        public object trainingUnits { get; set; }
        public object firstSchool { get; set; }
        public object secondSchool { get; set; }
        public object stage { get; set; }
        public object admissionCommittee { get; set; }
        public object firstGroup { get; set; }
        public object secondGroup { get; set; }
        public object admission { get; set; }
        public string email { get; set; }
        public object officialEmail { get; set; }
        public string fatherName { get; set; }
        public string motherName { get; set; }
        public string fatherPhoneNumber { get; set; }
        public string motherPhoneNumber { get; set; }
        public string fatherAddress { get; set; }
        public string motherAddress { get; set; }
        public long idNumberDateOfIssue { get; set; }
        public string idNumberPlaceOfIssue { get; set; }
        public string placeOfBirth { get; set; }
        public string nativeVillage { get; set; }
        public string ethnic { get; set; }
        public string religion { get; set; }
        public Studentbylogin_Ethnics ethnics { get; set; }
        public Studentbylogin_ReligionObject religionObject { get; set; }
        public string placeOfPermanentResidenceRegistration { get; set; }
        public string currentWhereabouts { get; set; }
        public string admissionCombination { get; set; }
        public object checkAdmissionFee { get; set; }
        public object specialityDto { get; set; }
        public Studentbylogin_CourseYearDto courseYearDto { get; set; }
        public Studentbylogin_EnrollmentClassDto enrollmentClassDto { get; set; }
        public bool? isRecruitedDirectly { get; set; }
        public bool? isConfirmAdmission { get; set; }
        public bool? isConfirm { get; set; }
        public string insuranceCardCode { get; set; }
        public string militaryServiceRegCode { get; set; }
        public long militaryServiceRegDate { get; set; }
        public string militaryServiceRegDateString { get; set; }
        public object motherDob { get; set; }
        public object fatherDob { get; set; }
        public int? motherYob { get; set; }
        public int? fatherYob { get; set; }
        public string motherJob { get; set; }
        public string fatherJob { get; set; }
        public long groupAdmissionDate { get; set; }
        public string groupAdmissionPlace { get; set; }
        public object communistAdmissionDate { get; set; }
        public object communistAdmissionPlace { get; set; }
        public string nameOldBrother1 { get; set; }
        public int? yearOldBrother1 { get; set; }
        public string addressOldBrother1 { get; set; }
        public string nameOldBrother2 { get; set; }
        public object yearOldBrother2 { get; set; }
        public string addressOldBrother2 { get; set; }
        public object nameOldBrother3 { get; set; }
        public object yearOldBrother3 { get; set; }
        public object addressOldBrother3 { get; set; }
        public object nameOldSister1 { get; set; }
        public object yearOldSister1 { get; set; }
        public object addressOldSister1 { get; set; }
        public object nameOldSister2 { get; set; }
        public object yearOldSister2 { get; set; }
        public object addressOldSister2 { get; set; }
        public object nameOldSister3 { get; set; }
        public object yearOldSister3 { get; set; }
        public object addressOldSister3 { get; set; }
        public object nameLittleBrother1 { get; set; }
        public object yearLittleBrother1 { get; set; }
        public object addressLittleBrother1 { get; set; }
        public object nameLittleBrother2 { get; set; }
        public object yearLittleBrother2 { get; set; }
        public object addressLittleBrother2 { get; set; }
        public object nameLittleBrother3 { get; set; }
        public object yearLittleBrother3 { get; set; }
        public object addressLittleBrother3 { get; set; }
        public object linkFb { get; set; }
        public object user { get; set; }
        public object countryCode { get; set; }
        public bool? payedAdmissionFee { get; set; }
        public object firstRecordsBookScore { get; set; }
        public object secondRecordsBookScore { get; set; }
        public object thirdRecordsBookScore { get; set; }
        public object totalRecordsBookScore { get; set; }
        public object firstRecordsBookName { get; set; }
        public object secondRecordsBookName { get; set; }
        public object thirdRecordsBookName { get; set; }
        public object admissionCombinationRecordsBook { get; set; }
        public object isSchoolProfile { get; set; }
        public bool? boarder { get; set; }
    }

    public class Studentbylogin_Child
    {
        public int? id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int? departmentType { get; set; }
        public object parentId { get; set; }
        public object parent { get; set; }
        public List<object> subDepartments { get; set; }
        public List<object> children { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public string displayOrder { get; set; }
        public int? level { get; set; }
        public string linePath { get; set; }
        public object shortName { get; set; }
        public bool? duplicate { get; set; }
    }

    public class Studentbylogin_Courseyear
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int? year { get; set; }
        public Studentbylogin_EducationType educationType { get; set; }
        public Studentbylogin_EducationLevel educationLevel { get; set; }
        public object textSearch { get; set; }
    }

    public class Studentbylogin_CourseYear2
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public object year { get; set; }
        public object educationType { get; set; }
        public object educationLevel { get; set; }
        public object textSearch { get; set; }
    }

    public class Studentbylogin_CourseYearDto
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public object year { get; set; }
        public object educationType { get; set; }
        public object educationLevel { get; set; }
        public object textSearch { get; set; }
    }

    public class Studentbylogin_Department
    {
        public int? id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int? departmentType { get; set; }
        public object parentId { get; set; }
        public Studentbylogin_Parent parent { get; set; }
        public List<Studentbylogin_SubDepartment> subDepartments { get; set; }
        public List<Studentbylogin_Child> children { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public string displayOrder { get; set; }
        public int? level { get; set; }
        public string linePath { get; set; }
        public object shortName { get; set; }
        public bool? duplicate { get; set; }
    }

    public class Studentbylogin_District
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int? level { get; set; }
        public Studentbylogin_Parent parent { get; set; }
        public object subAdministrativeUnits { get; set; }
        public List<object> children { get; set; }
    }

    public class Studentbylogin_EducationLevel
    {
        public object id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string numbericCode { get; set; }
    }

    public class Studentbylogin_EducationType
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string nameEng { get; set; }
    }

    public class Studentbylogin_EnrollmentClass
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public int? id { get; set; }
        public bool? voided { get; set; }
        public string className { get; set; }
        public string classCode { get; set; }
        public int? schoolYear { get; set; }
        public Studentbylogin_Department department { get; set; }
        public Studentbylogin_Speciality speciality { get; set; }
        public int? retCode { get; set; }
        public Studentbylogin_Courseyear courseyear { get; set; }
        public object numberOfStudent { get; set; }
        public object numberOfFemale { get; set; }
        public object numberOfBoarding { get; set; }
        public object teacher { get; set; }
        public Studentbylogin_TrainingBase trainingBase { get; set; }
        public int? pageIndex { get; set; }
        public int? pageSize { get; set; }
        public int? numberOfClasses { get; set; }
        public Studentbylogin_Program program { get; set; }
        public bool? duplicateCode { get; set; }
    }

    public class Studentbylogin_EnrollmentClassDto
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public int? id { get; set; }
        public bool? voided { get; set; }
        public string className { get; set; }
        public string classCode { get; set; }
        public object schoolYear { get; set; }
        public object department { get; set; }
        public Studentbylogin_Speciality speciality { get; set; }
        public int? retCode { get; set; }
        public Studentbylogin_Courseyear courseyear { get; set; }
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

    public class Studentbylogin_Ethnics
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public object description { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public bool? duplicate { get; set; }
    }

    public class Studentbylogin_FatherProfession
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

    public class Studentbylogin_MotherProfession
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

    public class Studentbylogin_Parent
    {
        public int? id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int? departmentType { get; set; }
        public object parentId { get; set; }
        public object parent { get; set; }
        public object subDepartments { get; set; }
        public object children { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public object displayOrder { get; set; }
        public object level { get; set; }
        public object linePath { get; set; }
        public object shortName { get; set; }
        public bool? duplicate { get; set; }
        public object subAdministrativeUnits { get; set; }
    }

    public class Studentbylogin_Person
    {
        public List<int> createDate { get; set; }
        public string createdBy { get; set; }
        public List<int> modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public int? id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string displayName { get; set; }
        public object shortName { get; set; }
        public long birthDate { get; set; }
        public string birthDateString { get; set; }
        public string birthPlace { get; set; }
        public string gender { get; set; }
        public object startDate { get; set; }
        public object endDate { get; set; }
        public string phoneNumber { get; set; }
        public string idNumber { get; set; }
        public string idNumberIssueBy { get; set; }
        public long idNumberIssueDate { get; set; }
        public string idNumberIssueDateString { get; set; }
        public string email { get; set; }
        public object nationality { get; set; }
        public object nativeVillage { get; set; }
        public object ethnics { get; set; }
        public object religion { get; set; }
        public object photo { get; set; }
        public object photoCropped { get; set; }
        public List<Studentbylogin_Address> address { get; set; }
        public int? userId { get; set; }
        public long communistYouthUnionJoinDate { get; set; }
        public string communistYouthUnionJoinDateString { get; set; }
        public object communistPartyJoinDate { get; set; }
        public object communistPartyJoinDateString { get; set; }
        public object carrer { get; set; }
        public object createIp { get; set; }
        public object modifyIp { get; set; }
    }

    public class Studentbylogin_Program
    {
        public int? id { get; set; }
        public object educationType { get; set; }
        public object educationLevel { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public object speciality { get; set; }
        public Studentbylogin_Courseyear courseYear { get; set; }
        public object subjects { get; set; }
        public object pageIndex { get; set; }
        public object totalSubject { get; set; }
        public object groups { get; set; }
        public object inheritEducationProgram { get; set; }
        public object inheritCourseYear { get; set; }
        public object type { get; set; }
        public object trainingTime { get; set; }
    }

    public class Studentbylogin_Program2
    {
        public int? id { get; set; }
        public object student { get; set; }
        public Studentbylogin_Program program { get; set; }
        public bool? isMain { get; set; }
        public object status { get; set; }
        public object isInListGraduation { get; set; }
    }

    public class Studentbylogin_Province
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int? level { get; set; }
        public Studentbylogin_Parent parent { get; set; }
        public object subAdministrativeUnits { get; set; }
        public List<object> children { get; set; }
    }

    public class Studentbylogin_ReligionObject
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public object description { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public bool? duplicate { get; set; }
    }

    public class Studentbylogin_Role
    {
        public int? id { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public string authority { get; set; }
    }

    public class Studentbylogin_Root
    {
        public List<int> createDate { get; set; }
        public string createdBy { get; set; }
        public List<int> modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public int? id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string displayName { get; set; }
        public object shortName { get; set; }
        public long birthDate { get; set; }
        public string birthDateString { get; set; }
        public string birthPlace { get; set; }
        public string gender { get; set; }
        public object startDate { get; set; }
        public object endDate { get; set; }
        public string phoneNumber { get; set; }
        public string idNumber { get; set; }
        public string idNumberIssueBy { get; set; }
        public long idNumberIssueDate { get; set; }
        public string idNumberIssueDateString { get; set; }
        public string email { get; set; }
        public object nationality { get; set; }
        public object nativeVillage { get; set; }
        public object ethnics { get; set; }
        public object religion { get; set; }
        public object photo { get; set; }
        public object photoCropped { get; set; }
        public List<Studentbylogin_Address> address { get; set; }
        public int? userId { get; set; }
        public long communistYouthUnionJoinDate { get; set; }
        public string communistYouthUnionJoinDateString { get; set; }
        public object communistPartyJoinDate { get; set; }
        public object communistPartyJoinDateString { get; set; }
        public object carrer { get; set; }
        public object createIp { get; set; }
        public object modifyIp { get; set; }
        public string studentCode { get; set; }
        public object highSchoolGraduationYear { get; set; }
        public int? yearOfAdmission { get; set; }
        public string fatherFullName { get; set; }
        public string motherFullName { get; set; }
        public object fatherBirthDate { get; set; }
        public object fatherBirthDateString { get; set; }
        public object motherBirthDate { get; set; }
        public object motherBirthDateString { get; set; }
        public bool? isBoarder { get; set; }
        public object fatherProfession { get; set; }
        public object motherProfession { get; set; }
        public string fatherPhoneNumber { get; set; }
        public string motherPhoneNumber { get; set; }
        public Studentbylogin_EnrollmentClass enrollmentClass { get; set; }
        public string bankAccount { get; set; }
        public object bankName { get; set; }
        public object studentObject { get; set; }
        public List<Studentbylogin_Program> programs { get; set; }
        public List<object> studentObjectStudents { get; set; }
        public List<object> studentObjectStudentSemesters { get; set; }
        public object studentStudentPrivateDocumentDtos { get; set; }
        public object studentDecisions { get; set; }
        public Studentbylogin_User user { get; set; }
        public Studentbylogin_CandidateProfile candidateProfile { get; set; }
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
        public object className { get; set; }
        public object classCode { get; set; }
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
        public List<object> studentStatusStudentSemesters { get; set; }
        public string statusName { get; set; }
        public object statusSemesterName { get; set; }
        public object note { get; set; }
        public object studentStatus { get; set; }
        public int? studentType { get; set; }
        public bool? payedAdmissionFee { get; set; }
        public object userActive { get; set; }
    }

    public class Studentbylogin_Speciality
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string numbericCode { get; set; }
        public object parent { get; set; }
        public Studentbylogin_Department department { get; set; }
        public List<object> programs { get; set; }
        public object isGroup { get; set; }
        public int? retCode { get; set; }
        public List<object> children { get; set; }
        public string nameEng { get; set; }
    }

    public class Studentbylogin_Student
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public int? id { get; set; }
        public object firstName { get; set; }
        public object lastName { get; set; }
        public object displayName { get; set; }
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
        public Studentbylogin_FatherProfession fatherProfession { get; set; }
        public Studentbylogin_MotherProfession motherProfession { get; set; }
        public object fatherPhoneNumber { get; set; }
        public object motherPhoneNumber { get; set; }
        public Studentbylogin_EnrollmentClass enrollmentClass { get; set; }
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
        public object className { get; set; }
        public object classCode { get; set; }
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

    public class Studentbylogin_SubDepartment
    {
        public int? id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int? departmentType { get; set; }
        public object parentId { get; set; }
        public object parent { get; set; }
        public List<object> subDepartments { get; set; }
        public List<object> children { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public string displayOrder { get; set; }
        public int? level { get; set; }
        public string linePath { get; set; }
        public object shortName { get; set; }
        public bool? duplicate { get; set; }
    }

    public class Studentbylogin_Subject
    {
        public int? id { get; set; }
        public object program { get; set; }
        public Studentbylogin_Subject subject { get; set; }
        public object mark { get; set; }
        public object semester { get; set; }
        public object prerequiteSubjects { get; set; }
        public object group { get; set; }
        public object displaySubjectName { get; set; }
        public object children { get; set; }
        public object knowledgeProgram { get; set; }
        public object subjectType { get; set; }
        public object semesterIndex { get; set; }
        public object equivalentSubjects { get; set; }
        public object tuitionCoefficient { get; set; }
        public object feePerCredit { get; set; }
        public object hasMark { get; set; }
        public object passed { get; set; }
        public object mark4 { get; set; }
        public object charMark { get; set; }
        public object subjectMark { get; set; }
        public object result { get; set; }
        public object programId { get; set; }
        public object subjectId { get; set; }
        public object knowledgeProgramId { get; set; }
        public object subjectCode { get; set; }
        public object @checked { get; set; }
        public bool? root { get; set; }
    }

    public class Studentbylogin_Subject2
    {
        public int? id { get; set; }
        public string subjectCode { get; set; }
        public object defineCode { get; set; }
        public string subjectName { get; set; }
        public object subjectNameEng { get; set; }
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
        public object isCalculateMark { get; set; }
        public object subjectType { get; set; }
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

    public class Studentbylogin_TrainingBase
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public int? id { get; set; }
        public bool? voided { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public object address { get; set; }
        public object dupName { get; set; }
        public object dupCode { get; set; }
        public bool? duplicate { get; set; }
    }

    public class Studentbylogin_User
    {
        public List<int> createDate { get; set; }
        public string createdBy { get; set; }
        public List<int> modifyDate { get; set; }
        public string modifiedBy { get; set; }
        public int? id { get; set; }
        public string displayName { get; set; }
        public string username { get; set; }
        public object password { get; set; }
        public object confirmPassword { get; set; }
        public bool? changePass { get; set; }
        public bool? active { get; set; }
        public object lastName { get; set; }
        public object firstName { get; set; }
        public long dob { get; set; }
        public string birthPlace { get; set; }
        public string email { get; set; }
        public Studentbylogin_Person person { get; set; }
        public bool? hasPhoto { get; set; }
        public List<Studentbylogin_Role> roles { get; set; }
        public List<object> groups { get; set; }
        public bool? setPassword { get; set; }
    }

    public class Studentbylogin_Ward
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int? level { get; set; }
        public Studentbylogin_Parent parent { get; set; }
        public object subAdministrativeUnits { get; set; }
        public List<object> children { get; set; }
    }


}
