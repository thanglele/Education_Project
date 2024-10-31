namespace Sinhvien.tlu.Login_form
{
    class requestActive
    {
        public string keyDActive {  get; set; }
        public string serialKey { get; set; }
    }

    class updateKey
    {
        public string username { get; set; }
        public bool? isActive { get; set; }
        public string keyDActive { get; set; }
        public string serialKey { get; set; }
    }
    class respond_Key
    {
        public bool? isActive { get; set; }
    }
}
