using LibraryManagement.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    public class BorrowerRepository : BaseRepository, IBorrowerRepository
    {
        public BorrowerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(BorrowerModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(BorrowerModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BorrowerModel> GetAll()
        {
            string sql = "SELECT * FROM TBLBORROWER";
            var list = new List<BorrowerModel>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.CommandText = sql;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new BorrowerModel();
                        model.Id = Convert.ToInt32(reader["BORROWERID"]);
                        model.Name = reader["BORROWERNAME"].ToString();
                        model.Gender = reader["BORROWERSEX"].ToString();
                        model.Dob = (DateTime)reader["BORROWERDOB"];
                        model.Address = reader["BORROWERADDRESS"].ToString();
                        model.Phone = reader["BORROWERTEL"].ToString();
                        model.Email = reader["BORROWEREMAIL"].ToString();
                        list.Add(model);
                    }
                }
                connection.Close();
            }
            return list;
        }

        public IEnumerable<BorrowerModel> GetByValue(string value)
        {
            var list = new List<BorrowerModel>();
            int id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string name = value;

            using (var connection = new OracleConnection(connectionString))
            using (var command = new OracleCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.CommandText = $"SELECT * FROM TBLBORROWER WHERE BORROWERID = :v1 OR BORROWERNAME LIKE '${name}'";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new OracleParameter("v1", id));

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new BorrowerModel();
                        model.Id = Convert.ToInt32(reader["BORROWERID"]);
                        model.Name = reader["BORROWERNAME"].ToString();
                        model.Gender = reader["BORROWERSEX"].ToString();
                        model.Dob = (DateTime)reader["BORROWERDOB"];
                        model.Address = reader["BORROWERADDRESS"].ToString();
                        model.Phone = reader["BORROWERTEL"].ToString();
                        model.Email = reader["BORROWEREMAIL"].ToString();
                        list.Add(model);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return list;
        }
    }
}
