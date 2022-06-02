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
        private ReportDocument report;
        public PrintFormView()
        {
            InitializeComponent();
        }

        private static PrintFormView instance;

        public string Document_path
        {
            get => template.SelectedValue.ToString();
            set => template.SelectedValue = value;
        }

        ReportDocument IPrintFormView.reprotDocument
        { 
            get => report;
            set
            {
                report = value;
                crystalReportViewer1.ReportSource = report;
            }
        }

        public static PrintFormView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PrintFormView();
                instance.MdiParent = parentContainer;
                //instance.FormBorderStyle = FormBorderStyle.None;
                //instance.Dock = DockStyle.Fill;
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

        private void export_pdf_Click(object sender, EventArgs e)
        {
            try
            {
                report.PrintOptions.PrinterName = "Microsoft Print to PDF";
                report.PrintToPrinter(1, true, 1, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.Refresh();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                crystalReportViewer1.PrintReport();
                this.Cursor = Cursors.Default;
            }
            catch(Exception ex)
            {                
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        public void SetTemplate(BindingSource bindingsource)
        {
            template.DataSource = bindingsource.DataSource;
            template.DisplayMember = "Name";
            template.ValueMember = "String_path";
            template.SelectedValue = 0;
        }
    }
}
