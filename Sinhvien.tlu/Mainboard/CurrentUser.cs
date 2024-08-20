using System.Collections.Generic;

namespace Sinhvien.tlu.Mainboard
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CurrentUser_Address
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

    public class CurrentUser_Person
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
        public long? birthDate { get; set; }
        public string birthDateString { get; set; }
        public string birthPlace { get; set; }
        public string gender { get; set; }
        public object startDate { get; set; }
        public object endDate { get; set; }
        public string phoneNumber { get; set; }
        public string idNumber { get; set; }
        public string idNumberIssueBy { get; set; }
        public long? idNumberIssueDate { get; set; }
        public string idNumberIssueDateString { get; set; }
        public string email { get; set; }
        public object nationality { get; set; }
        public object nativeVillage { get; set; }
        public object ethnics { get; set; }
        public object religion { get; set; }
        public object photo { get; set; }
        public object photoCropped { get; set; }
        public List<CurrentUser_Address> address { get; set; }
        public object userId { get; set; }
        public object communistYouthUnionJoinDate { get; set; }
        public object communistYouthUnionJoinDateString { get; set; }
        public object communistPartyJoinDate { get; set; }
        public object communistPartyJoinDateString { get; set; }
        public object carrer { get; set; }
        public object createIp { get; set; }
        public object modifyIp { get; set; }
    }

    public class CurrentUser_Role
    {
        public int? id { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public string authority { get; set; }
    }

    public class CurrentUser_Root
    {
        public object createDate { get; set; }
        public object createdBy { get; set; }
        public object modifyDate { get; set; }
        public object modifiedBy { get; set; }
        public int? id { get; set; }
        public string displayName { get; set; }
        public string username { get; set; }
        public object password { get; set; }
        public object confirmPassword { get; set; }
        public bool? changePass { get; set; }
        public bool? active { get; set; }
        public object lastName { get; set; }
        public object firstName { get; set; }
        public long? dob { get; set; }
        public string birthPlace { get; set; }
        public string email { get; set; }
        public CurrentUser_Person person { get; set; }
        public bool? hasPhoto { get; set; }
        public List<CurrentUser_Role> roles { get; set; }
        public List<object> groups { get; set; }
        public bool? setPassword { get; set; }
    }


}
