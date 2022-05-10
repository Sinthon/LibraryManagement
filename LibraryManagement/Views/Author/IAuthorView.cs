using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Author
{
    public interface IAuthorView
    {
        string sValue { get; set; }

        event EventHandler Search;
        event EventHandler Add;
        event EventHandler Edit;
        event EventHandler Delete;
        event EventHandler Load;

        void SetBindingSource(BindingSource petList);
        void Show();
    }
}
