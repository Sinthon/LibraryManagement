using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Books
{
    public interface IBookView
    {
        string sValue { get; set; }
        int category_id { get; set; }

        event EventHandler Search;
        event EventHandler Add;
        event EventHandler Edit;
        event EventHandler Delete;
        event EventHandler Load;
        event EventHandler CloseForm;
        
        void SetBookListBindingSource(BindingSource bindingSource);
        void CategoryBindingSource(BindingSource bindingSource);
        void Show();
        void Close();
    }
}
