using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Library_Preferent
{
    public interface ILiraryPreferentView
    {
        string Company_name { get; set; }
        string Company_email { get; set; }
        string Company_phone { get; set; }
        string Company_address { get; set; }
        string Company_website { get; set; }
        Byte Logo { get; set; }

        void Show(Form parent);
        void Hide();
    }
}
