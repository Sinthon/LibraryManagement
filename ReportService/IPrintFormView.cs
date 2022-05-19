using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Presenters
{
    public interface IPrintFormView
    {
        event EventHandler Print;
        event EventHandler ExportPDF;
        event EventHandler RefreshTemplate;

    }
}
