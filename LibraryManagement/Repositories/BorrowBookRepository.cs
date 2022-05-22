using LibraryManagement.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace LibraryManagement.Repositories
{
    public class BorrowBookRepository : BaseRepository, IBorrowBookRepository
    {
        public BorrowBookRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetReprot(string[] reprot_id)
        {
            DataTable table = new DataTable();

            string sql = string.Empty;

            sql = "SELECT * FROM VIEW_BORROW_BOOK WHERE ";

            for (int i = 0; i < reprot_id.Length; i++)
            {
                sql += " BORROWBOOK_ID = " + reprot_id[i];
                if (reprot_id.Length > 1)
                {
                    if (i + 1 != reprot_id.Length)
                        sql += " OR ";
                }
            }

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                using (OracleDataAdapter adapter = new OracleDataAdapter(sql, connection))
                {
                    adapter.Fill(table);
                    table.TableName = "VIEW_BORROW_BOOK";
                }
                connection.Close();
            }

            return table;
        }
    }
}
