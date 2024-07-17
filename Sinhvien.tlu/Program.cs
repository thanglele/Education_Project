using System;
using System.Windows.Forms;
using Sinhvien.tlu.Login_form;

namespace Sinhvien.tlu
{
    internal static class Program
    {
        [STAThread]
        static public void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System_Login New_Login = new System_Login();
            //Subject_Form listing = new Subject_Form();
            //Form1 new_form = new Form1();

            Application.Run(New_Login);
        }
    }
}