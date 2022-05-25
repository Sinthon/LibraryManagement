using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Category.Dialog
{
    public interface ICategoryDialog
    {
        int Id { get; set; }
        string Cat_Name { get; set; }
        string Description { get; set; }

        string ErrorMessages { get; set; }
        bool IsEdit { get; set; }

        string DialogTitle { get; set; }

        event EventHandler Save;
        event EventHandler Cancel;

        void Show(Form parentContainer);
        void Close();
    }
}
