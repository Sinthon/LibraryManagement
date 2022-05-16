using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Category
{
    public partial class CategoryView : Form, ICategoryView
    {
        public CategoryView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private static CategoryView instance;
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
            editToolStripMenuItem.Click += delegate
            {
                Edit?.Invoke(this, EventArgs.Empty);
            };
            toolStripMenuItem1.Click += delegate
            {
                Delete?.Invoke(this, EventArgs.Empty);
            };
        }

        public string sValue {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }


        public static CategoryView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CategoryView();
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

        private void Cell_MouseDown(object sender, DataGridViewCellMouseEventArgs e)
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
    }
}
