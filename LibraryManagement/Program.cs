using LibraryManagement.Presenters;
using LibraryManagement.Views.Layout;
using LibraryManagement.Views.Login;
using LibraryManagement.Views.Main;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
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

            string connectionString = ConfigurationManager.ConnectionStrings["LibraryManagement"].ConnectionString;
            IMainView mainview = MainView.GetInstance();
            ISideBarMenu sidebar = SideBarMenu.GetInstance();
            new MainPresenter(mainview, sidebar, connectionString);

            Application.Run(mainview as Form);
        }
    }
}
