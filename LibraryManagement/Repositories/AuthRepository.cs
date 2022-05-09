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
                command.CommandText = $"select * from TBLLIBRARIAN where LIB_EMAIL= :email and LIB_Password= :password";
                command.Parameters.Add(new OracleParameter("email", model.Email));
                command.Parameters.Add(new OracleParameter("password", model.Password));
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[1].ToString());
                    }
                }
            }
        }
    }
}
