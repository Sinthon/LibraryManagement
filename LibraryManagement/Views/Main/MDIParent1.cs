using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Main
{
    public partial class MDIParent1 : Form, IMainView
    {
        private int childFormNumber = 0;

        public event EventHandler SetUp;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void Resize_End(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        public void IitialComponent()
        {
            this.Controls.Add(this.menuStrip);
        }

        private static MDIParent1 instance;
        public static MDIParent1 GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new MDIParent1();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Maximized;
                }
            }
            return instance;
        }
    }
}
