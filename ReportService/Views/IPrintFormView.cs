using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Presenters
{
    public interface IPrintFormView
    {
        ReportDocument reprotDocument { get; set; }
        void Show();
        void Hide();
        void Refresh();
    }
}
