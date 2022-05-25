using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using System.Data;

namespace LibraryManagement.Repositories
{
    class AuthRepository : BaseRepository, IAuthRepository
    {
        public AuthRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetPreference()
        {
            DataTable table = new DataTable();
            string sql = "SELECT * FROM TBLLYBRARY FETCH FIRST 1 ROWS ONLY";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                using (OracleDataAdapter adapter = new OracleDataAdapter(sql, connection))
                {
                    adapter.Fill(table);
                    table.TableName = "REPORT_HEADER";
                }
                connection.Close();
            }
            return table;
        }

        public void Login(AuthModel model)
        {   
            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM TBLLIBRARIAN WHERE LIB_EMAIL= :email AND LIB_PWD= :password";
                command.Parameters.Add(new OracleParameter("email", model.Email));
                command.Parameters.Add(new OracleParameter("password", model.Password));
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read()) throw new Exception("The email or password you entered did not match our record.");
                }
                connection.Close();
            }
        }
    }
}
