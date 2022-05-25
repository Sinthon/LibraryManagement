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

namespace LibraryManagement.Views.Books
{
    public partial class BookView : Form, IBookView
    {
        public BookView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private static BookView instance;
        public event EventHandler Search;
        public event EventHandler Add;
        public event EventHandler Edit;
        public event EventHandler Delete;
        public event EventHandler Load;
        public event EventHandler CloseForm;

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
        }

        public string sValue {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public int category_id
        {
            get => Convert.ToInt32(Filter.SelectedValue);
            set => Filter.SelectedValue = value;
        }

        public static BookView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BookView();
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

        public void SetBookListBindingSource(BindingSource bindingSource)
        {
            dataGridView1.DataSource = bindingSource;
        }

        private void activities_Click(object sender, EventArgs e)
        {
            cms_activities.Show((Control)sender, 0, -cms_activities.Height);
        }

        private void Mouse_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cms_activities.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgv.Rows[e.RowIndex].Selected = true;
                    dgv.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void CategoryBindingSource(BindingSource bindingSource)
        {
            var model = new CategoryModel();
            model.Name = "All";
            model.Id = 0;
            model.Description = "";
            bindingSource.Add(model);

            Filter.DataSource = bindingSource.DataSource;
            Filter.DisplayMember = "Name";
            Filter.ValueMember = "Id";
            Filter.SelectedValue = 0;
        }
    }
}
