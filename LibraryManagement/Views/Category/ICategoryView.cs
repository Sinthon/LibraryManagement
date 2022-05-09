using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Category
{
    public interface ICategoryView
    {
        string sValue { get; set; }

        event EventHandler Search;
        event EventHandler Add;
        event EventHandler Edit;
        event EventHandler Delete;
        event EventHandler Load;

        void SetBindingSource(BindingSource bindingSource);
        void Show();

    }
}
