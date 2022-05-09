using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Login
{
    public partial class LoginView : Form, ILoginView
    {
        private bool success;

        public string Email {
            get { return email.Text; }
            set { email.Text = value; }
        }
        public string Password
        {
            get { return password.Text;  }
            set { password.Text = value; }
        }
        public string ErrorMeaage
        {
            get { return errorMeesage.Text; }
            set {
                errorMeesage.Text = value;
            }
        }

        public bool RememberMe
        {
            get { return remeberme.Checked; }
            set { remeberme.Checked = value; }
        }

        public bool LoginSuccess 
        {
            get { return success; }
            set{ success = value; }
        }

        LoginView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnlogin.Click += delegate
            {
                ClickLogin?.Invoke(this, EventArgs.Empty);
            };

            btncancel.Click += delegate
            {
                ClickExit?.Invoke(this, EventArgs.Empty);
            };
        }

        private static LoginView instance;
        public static LoginView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new LoginView();
            }
            return instance;
        }

        void ILoginView.ShowDialog(){}

        public event EventHandler ClickLogin;
        public event EventHandler ClickExit;
    }
}
