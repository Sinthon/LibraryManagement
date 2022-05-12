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
