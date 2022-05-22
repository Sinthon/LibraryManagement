using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Views.Main
{
    interface IMainView
    {
        event EventHandler SetUp;
        event EventHandler ShowPreference;
        void IitialComponent();
        void Close();
    }
}
