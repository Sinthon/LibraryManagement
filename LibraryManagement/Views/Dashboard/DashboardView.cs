using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Dashboard
{
    public partial class DashboardView : Form, IDashboardView
    {
        public DashboardView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btn_Book.Click += delegate
            {
                ShowBooks?.Invoke(this, EventArgs.Empty);
            };
            btn_BorrowBook.Click += delegate
            {
                ShowBorrowBook?.Invoke(this, EventArgs.Empty);
            };
            btn_ReturnBook.Click += delegate
            {
                ShowReturn?.Invoke(this, EventArgs.Empty);
            };
            btn_Borrower.Click += delegate
            {
                ShowBorrower?.Invoke(this, EventArgs.Empty);
            };

            if (Properties.Settings.Default.RememberMe)
            {
                checkBox2.Checked = Properties.Settings.Default.ShowLibraryInfo;
                panel5.Visible = Properties.Settings.Default.ShowLibraryInfo;
                panel6.Visible = Properties.Settings.Default.ShowLibraryInfo;
            }
        }

        private static DashboardView instance;

        public string Company_name { 
            get => campany_name.Text; 
            set => campany_name.Text = value.ToUpper(); 
        }
        public string Company_email { 
            get => company_email.Text; 
            set => company_email.Text = value; 
        }
        public string Company_phone { 
            get => company_phone.Text; 
            set => company_phone.Text = value; 
        }
        public string Company_address {
            get => company_address.Text; 
            set => company_address.Text = value; 
        }

        public string Company_website
        {
            get => comapany_website.Text;
            set => comapany_website.Text = value;
        }

        public event EventHandler ShowBooks;
        public event EventHandler ShowReturn;
        public event EventHandler ShowAuthor;
        public event EventHandler ShowBorrowBook;
        public event EventHandler ShowBorrower;

        public static DashboardView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new DashboardView();
                instance.MdiParent = parentContainer;
                //instance.FormBorderStyle = FormBorderStyle.None;
                //instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        public void SetPreference(LibraryModel model)
        {
            campany_name.Text = model.Name;
            company_email.Text = model.Email;
            company_phone.Text = model.Phone;
            comapany_website.Text = model.Website;
            company_address.Text = model.Address;
        }

        private void Hide_library_infor(object sender, EventArgs e)
        {
            panel6.Visible = (sender as CheckBox).Checked;
            panel5.Visible = (sender as CheckBox).Checked;
            Properties.Settings.Default.ShowLibraryInfo = (sender as CheckBox).Checked;
            Properties.Settings.Default.Save();
        }
    }
}
