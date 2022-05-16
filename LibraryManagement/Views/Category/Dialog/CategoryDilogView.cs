using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Category.Dialog
{
    public partial class CategoryDilogView : Form, ICategoryDialog
    {
        private bool isedit;
        public CategoryDilogView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            cancel.Click += delegate
            {
                Cancel?.Invoke(this, EventArgs.Empty);
            };

            save.Click += delegate
            {
                Save?.Invoke(this, EventArgs.Empty);
            };
        }

        public string ErrorMessages { 
            get => ErrorMessage.Text; 
            set => ErrorMessage.Text = value; 
        }
        public bool IsEdit { 
            get => isedit;
            set => isedit = value;
        }
        public string DialogTitle { 
            get => dialogtitle.Text; 
            set => dialogtitle.Text = value; 
        }
        public string Cat_Name
        { 
            get => name.Text; 
            set => name.Text = value;
        }

        public string Description { 
            get => description.Text; 
            set => description.Text = value; 
        }

        public int Id {
            get
            {
                if (string.IsNullOrEmpty(id.Text))
                    return 0;

                return Convert.ToInt32(id.Text);
            }
            set => id.Text = value.ToString();
        }

        private static CategoryDilogView instance = null;
        public static CategoryDilogView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CategoryDilogView();
                instance.ShowInTaskbar = false;
            }
            return instance;
        }

        public event EventHandler Save;
        public event EventHandler Cancel;

        public void Show(Form parentContainer)
        {
            this.ShowDialog(parentContainer);
        }
    }
}
