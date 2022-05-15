using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Views.PrintForms
{
    public interface IPrintFormView
    {
        event EventHandler print;
    }
}
