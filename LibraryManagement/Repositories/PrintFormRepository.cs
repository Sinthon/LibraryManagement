using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    public class PrintFormRepository : BaseRepository, IPrintFormRepository
    {
        public PrintFormRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

    }
}
