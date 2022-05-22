using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IBorrowBookRepository
    {
        DataTable GetReprot(string[] reprot_id);
    }
}
