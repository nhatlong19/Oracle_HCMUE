using SpaceTeam_Oracle.SpaceTeam.DanhMucNV;
using SpaceTeam_Oracle.UI;
using System;
using System.Windows.Forms;

namespace SpaceTeam_Oracle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());
        }
    }
}
