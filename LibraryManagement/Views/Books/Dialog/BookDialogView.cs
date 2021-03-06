using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Books.Dialog
{
    public partial class BookDialogView : Form, IBookDailog
    {
        private bool isedit;
        public BookDialogView()
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

        public int Id { 
            get => Convert.ToInt32(id.Text); 
            set => id.Text = value.ToString(); 
        }
        public string Title { 
            get => title.Text; 
            set => title.Text = value; 
        }
        public int Page { 
            get{
                var value = page.Text;
                if (string.IsNullOrEmpty(value))
                    value = "0";
                return Convert.ToInt32(value);
            }
               
            set => page.Text = value.ToString(); 
        }
        public string Type { 
            get => type.Text; 
            set => type.Text = value; 
        }
        public DateTime PublicDate { 
            get => publish_date.Value;
            set => publish_date.Value = value; 
        }
        public string Publisher { 
            get => publisher.Text; 
            set => publisher.Text = value; 
        }
        public int Categiry_Id { 
            get => category_id.SelectedIndex; 
            set => category_id.SelectedIndex = value; 
        }
        public string ErrorMessages
        {
            get => ErrorMessage.Text;
            set => ErrorMessage.Text = value;
        }

        public bool IsEdit
        {
            get => isedit;
            set => isedit = value;
        }

        public string DialogTitle
        {
            get => dialogtitle.Text;
            set => dialogtitle.Text = value;
        }


        public event EventHandler Save;
        public event EventHandler Cancel;

        

        private static BookDialogView instance = null;
        public static BookDialogView GetInstance()
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new BookDialogView();
            }
            return instance;
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        public void Show(Form parent)
        {
            this.ShowDialog(parent);
        }

        public void AuthorsBindingSource(BindingSource authors)
        {
            category_id.DataSource = authors.DataSource;

            //adap = new SqlDataAdapter("Select * from tblAuthor", conn);
            //ds = new DataSet();

            //adap.Fill(ds, "author");
            //author.DataSource = ds.Tables["author"];
            //author.DisplayMember = "AuthorName";
            //author.ValueMember = "AuthorID";
        }
    }
}
