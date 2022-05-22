using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.BorrowBook
{
    public partial class BorrowBookView : Form, IBorrowBookView
    {
        BorrowBookView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            print.Click += delegate
            {
                Print?.Invoke(this, EventArgs.Empty);
            };

            txtSearch.KeyUp += delegate
            {
                Search?.Invoke(this, EventArgs.Empty);
            };
            close.Click += delegate
            {
                CloseForm?.Invoke(this, EventArgs.Empty);
            };
            editToolStripMenuItem.Click += delegate
            {
                Edit?.Invoke(this, EventArgs.Empty);
            };

            deleteToolStripMenuItem.Click += delegate
            {
                Delete?.Invoke(this, EventArgs.Empty);
            };
            previewToolStripMenuItem.Click += delegate
            {
                Preview?.Invoke(this, EventArgs.Empty);
            };
        }

        public DateTime FromDate { 
            get => fromdate.Value; 
            set => fromdate.Value = value; 
        }

        public DateTime ToDate { 
            get => todate.Value; 
            set => todate.Value = value; 
        }

        public event EventHandler Search;
        public event EventHandler Add;
        public event EventHandler Edit;
        public event EventHandler Delete;
        public event EventHandler CloseForm;
        public event EventHandler Preview;
        public event EventHandler Print;

        public void SetBindingSource(BindingSource bindingSource)
        {
            dataGridView1.DataSource = bindingSource;
        }

        private static BorrowBookView instance;
        public static BorrowBookView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BorrowBookView();
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

        private void activities_Click(object sender, EventArgs e)
        {
            cms_activities.Show((Control)sender, 0, -cms_activities.Height);
        }
    }
}
