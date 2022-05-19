using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using ReportService.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportService
{
    public partial class PrintFormView : Form, IPrintFormView
    {
        public PrintFormView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            print.Click += delegate {
                Print?.Invoke(this, EventArgs.Empty);
            };
            export_pdf.Click += delegate {
                ExportPDF?.Invoke(this, EventArgs.Empty);
            };
            refresh.Click += delegate {
                RefreshTemplate?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler RefreshTemplate;
        public event EventHandler Print;
        public event EventHandler ExportPDF;

        private static PrintFormView instance;
        public static PrintFormView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PrintFormView();
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

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
