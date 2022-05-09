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
            Book.Click += delegate
            {
                ShowBooks?.Invoke(this, EventArgs.Empty);
            };
            Borrow.Click += delegate
            {
                ShowBorrow?.Invoke(this, EventArgs.Empty);
            };
            Return.Click += delegate
            {
                ShowReturn?.Invoke(this, EventArgs.Empty);
            };
            Author.Click += delegate
            {
                ShowAuthor?.Invoke(this, EventArgs.Empty);
            };
        }

        private static DashboardView instance;

        public event EventHandler ShowBooks;
        public event EventHandler ShowBorrow;
        public event EventHandler ShowReturn;
        public event EventHandler ShowAuthor;

        public static DashboardView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new DashboardView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
    }
}
