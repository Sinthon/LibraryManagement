using LibraryManagement.Models;
using LibraryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Setting
{
    public partial class SettingView : Form, ISettingView
    {
        public SettingView()
        {
            InitializeComponent();
        }

        private static SettingView instance;
        public static SettingView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SettingView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private void SettingView_Load(object sender, EventArgs e)
        {
            DataTable table;
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = ORCL))); User Id = LB_DB; Password = 123456; ";

            IBorrowBookRepository repository = new BorrowBookRepository(connectionString);
            table = repository.GetReprot(new string[] { "1" });
            table.WriteXml("Reporting/VIEW_BORROW_BOOK.xml", XmlWriteMode.WriteSchema);

            dataGridView1.DataSource = table;
        }
    }
}
