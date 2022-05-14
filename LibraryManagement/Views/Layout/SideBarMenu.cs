using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Layout
{
    public partial class SideBarMenu : UserControl, ISideBarMenu
    {
        public SideBarMenu()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            dashboard.Click += delegate
            {
                ShowDahsBoard?.Invoke(this, EventArgs.Empty);
            };

            book.Click += delegate
            {
                ShowBooks?.Invoke(this, EventArgs.Empty);
            };
            author.Click += delegate
            {
                ShowAuthor?.Invoke(this, EventArgs.Empty);
            };
            category.Click += delegate
            {
                ShowCategory?.Invoke(this, EventArgs.Empty);
            };
            borrower.Click += delegate
            {
                ShowBorrower?.Invoke(this, EventArgs.Empty);
            };
            borrow.Click += delegate
            {
                ShowBorrowBook?.Invoke(this, EventArgs.Empty);
            };
            returnbook.Click += delegate
            {
                ShowReturnBook?.Invoke(this, EventArgs.Empty);
            };
            librarian.Click += delegate
            {
                ShowLibrarian.Invoke(this, EventArgs.Empty);
            };
        }

        private static SideBarMenu instance;
        public static SideBarMenu GetInstance()
        {
            if (instance == null)
            {
                instance = new SideBarMenu();
                instance.Dock = DockStyle.Left;
            }
            return instance;
        }

        void ISideBarMenu.Visible(bool visible)
        {
            this.Visible = visible;
        }

        public event EventHandler ShowDahsBoard;
        public event EventHandler ShowBooks;
        public event EventHandler ShowAuthor;
        public event EventHandler ShowBorrower;
        public event EventHandler ShowLibrarian;
        public event EventHandler ShowCategory;
        public event EventHandler ShowBorrowBook;
        public event EventHandler ShowReturnBook;
    }
}
