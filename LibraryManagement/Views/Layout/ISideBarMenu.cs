using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Views.Layout
{
    public interface ISideBarMenu
    {
        event EventHandler ShowDahsBoard;
        event EventHandler ShowBooks;
        event EventHandler ShowAuthor;
        event EventHandler ShowBorrower;
        event EventHandler ShowLibrarian;
        event EventHandler ShowCategory;
        event EventHandler ShowBorrowBook;
        event EventHandler ShowReturnBook;
        event EventHandler ShowSetting;
        void Visible(bool visible);
    }
}
