using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Borrower
{
    public interface IBorrowerView
    {
        string sValue { get; set; }

        event EventHandler Search;
        event EventHandler Add;
        event EventHandler Edit;
        event EventHandler Delete;
        event EventHandler CloseForm;

        void SetListBindingSource(BindingSource bindingSource);
        void Show();
        void Close();
    }
}
