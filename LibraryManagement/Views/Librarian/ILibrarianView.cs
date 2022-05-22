using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Librarian
{
    public interface ILibrarianView
    {
        void Show();

        void SetBindingSource(BindingSource bindingSource);
        void SetLibrarian(LibrarianModel model);
    }
}
