using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Author.Dialog
{
    public partial class AuthorDialog : Form, IAuthorDialog
    {
        public AuthorDialog()
        {
            InitializeComponent();
        }


        private static AuthorDialog instance = null;
        public static AuthorDialog GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AuthorDialog();
            }
            return instance;
        }

    }
}
