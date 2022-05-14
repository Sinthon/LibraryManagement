using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Librarian
{
    public partial class LibrarianView : Form, ILibrarianView
    {
        public LibrarianView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private static LibrarianView instance;
        public event EventHandler Search;
        public event EventHandler Add;
        public event EventHandler Edit;
        public event EventHandler Delete;
        public event EventHandler Load;
        private void AssociateAndRaiseViewEvents()
        {
            add.Click += delegate
            {
                Add?.Invoke(this, EventArgs.Empty);
            };
            txtSearch.KeyUp += delegate
            {
                Search?.Invoke(this, EventArgs.Empty);
            };
            load.Click += delegate
            {
                Load?.Invoke(this, EventArgs.Empty);
            };
        }

        public string sValue {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }


        public static LibrarianView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new LibrarianView();
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

        public void SetBindingSource(BindingSource bindingSource)
        {
            dataGridView1.DataSource = bindingSource;
        }
    }
}
