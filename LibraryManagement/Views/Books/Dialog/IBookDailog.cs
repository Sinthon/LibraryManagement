using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Books.Dialog
{
    public interface IBookDailog
    {
        int Id { get; set; }
        string Title { get; set; }
        int Page { get; set; }
        string Type { get; set; }
        DateTime PublicDate { get; set; }
        string Publisher { get; set; }
        int Categiry_Id { get; set; }

        string ErrorMessages { get; set; }
        bool IsEdit { get; set; }

        string DialogTitle { get; set; }

        event EventHandler Save;
        event EventHandler Cancel;

        void CategoriessBindingSource(BindingSource categories);

        void Show(Form parentContainer);
        void Hide();
    }
}
