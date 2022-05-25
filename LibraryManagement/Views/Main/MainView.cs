using LibraryManagement.Views.Layout;
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
    public partial class MainView : Form, IMainView
    {

        public event EventHandler SetUp;
        public event EventHandler ShowPreference;
        public event EventHandler ShowMenuBar;

        public MainView()
        {
            InitializeComponent();
            Load += delegate
            {
                SetUp?.Invoke(this, EventArgs.Empty);
            };
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        public void IitialComponent()
        {
            this.Controls.Add(SideBarMenu.GetInstance());
            this.Controls.Add(this.menuStrip);
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            PreferenceToolStripMenuItem.Click += delegate
            {
                ShowPreference?.Invoke(this, EventArgs.Empty);
            };

            statusBarToolStripMenuItem.Click += delegate
            {
                ShowMenuBar?.Invoke(statusBarToolStripMenuItem, EventArgs.Empty);
            };
        }

        private static MainView instance;

        public string FormTitle { 
            get => this.Text; 
            set => this.Text = value.ToUpper(); 
        }

        public static MainView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new MainView();
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

        private void Event_ResizeEnd(object sender, EventArgs e)
        {
            if ((sender as Form).WindowState == FormWindowState.Normal)
            {
                (sender as Form).WindowState = FormWindowState.Maximized;
            }
        }
    }
}
