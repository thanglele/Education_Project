using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinhvien.tlu.Mainboard
{
    internal class semester_infor
    {
        public int? id { set; get; }
        public string semesterCode { set; get; }
        public string semesterName { set; get; }
        public string description { set; get; }
        public schoolYear schoolYear { set; get; }
        public int? year { set; get; }
        public long? startDate { set; get; }
        public long? endDate { set; get; }
        public bool? isCurrent { set; get; }
        public object parent { set; get; }
        public object children { set; get; }

    }

    internal class schoolYear
    {
        public int id { set; get; }
        public string name { set; get; }
        public string code { set; get; }
        public int year { set; get; }
        public bool? current { set; get; }
        public long? startDate { set; get; }
        public long? endDate { set; get; }
        public object children { set; get; }
        public string displayName { set; get; }
        public int? semesterId { set; get; }
        public string isSemesters { set; get; }
        public string semesters {  set; get; }
    }
}
