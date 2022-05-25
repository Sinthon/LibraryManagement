using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Views.Main
{
    interface IMainView
    {
        string FormTitle { get; set; }
        event EventHandler SetUp;
        event EventHandler ShowPreference;
        event EventHandler ShowMenuBar;
        void IitialComponent();
        void Close();
    }
}
