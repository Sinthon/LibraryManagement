using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Views.Dashboard
{
    public interface IDashboardView
    {
        event EventHandler ShowBooks;
        event EventHandler ShowBorrow;
        event EventHandler ShowReturn;
        event EventHandler ShowAuthor;

        void Show();
    }
}
