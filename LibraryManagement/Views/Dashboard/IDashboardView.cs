using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Views.Dashboard
{
    public interface IDashboardView
    {
        string Company_name { get; set; }
        string Company_email { get; set; }
        string Company_phone { get; set; }
        string Company_address { get; set; }
        string Company_website { get; set; }

        event EventHandler ShowBooks;
        event EventHandler ShowBorrow;
        event EventHandler ShowReturn;
        event EventHandler ShowAuthor;

        void Show();
    }
}
