using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportService.Presenters
{
    public interface IPrintFormView
    {
        string Document_path { get; set; }
        ReportDocument reprotDocument { get; set; }
        void SetTemplate(BindingSource bindingsource);
        void Show();
        void Hide();
        void Refresh();
    }
}
