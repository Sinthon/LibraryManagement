using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.BorrowBook
{
    public interface IBorrowBookView
    {
        event EventHandler Search;
        event EventHandler Add;
        event EventHandler Edit;
        event EventHandler Delete;
        event EventHandler Load;
        event EventHandler CloseForm;
        event EventHandler Preview;
        event EventHandler Print;

        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }

        void SetBindingSource(BindingSource bindingSource);
        void Show();
        void Hide();
    }
}
