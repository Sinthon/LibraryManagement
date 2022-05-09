using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Login
{
    public interface ILoginView
    {
        string Email { get; set; }
        string Password { get; set; }
        string ErrorMeaage { get; set; }
        bool RememberMe { get; set; }
        bool LoginSuccess { get; set; }

        event EventHandler ClickLogin;
        event EventHandler ClickExit;

        void ShowDialog();
        void Hide();
    }
}
