using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Library_Preferent
{
    public partial class LiraryPreferentView : Form, ILiraryPreferentView
    {
        LiraryPreferentView()
        {
            InitializeComponent();
        }
        private static LiraryPreferentView instance;

        public string Company_name { 
            get => name.Text;
            set => name.Text = value;
        }
        public string Company_email { 
            get => email.Text; 
            set => email.Text = value; 
        }
        public string Company_phone { 
            get => phone.Text; 
            set => phone.Text = value; 
        }
        public string Company_address { 
            get => address.Text;
            set => address.Text = value; 
        }
        public string Company_website { 
            get => website.Text; 
            set => website.Text = value; 
        }
        public byte Logo { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }


        public void Show(Form parenContainer)
        {
            this.ShowDialog(parenContainer);
        }
        public static LiraryPreferentView GetInstnace()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new LiraryPreferentView();
                instance.ShowInTaskbar = false;
            }
            return instance;
        }
    }
}
