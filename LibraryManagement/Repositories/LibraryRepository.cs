using LibraryManagement.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    public class LibraryRepository : BaseRepository,ILibraryRepository
    {
        public LibraryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(LibraryModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(LibraryModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LibraryModel> GetAll()
        {
            var list = new List<LibraryModel>();
            using (OracleConnection connecion = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand())
            {
                connecion.Open();
                command.Connection = connecion;
                command.CommandText = " ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new LibraryModel();
                        model.Id = (int)reader["Id"];
                        model.Name = reader["Name"].ToString();
                        model.Website = reader["Website"].ToString();
                        model.Phone = reader["Phone"].ToString();
                        model.Logo = (byte)reader["Logo"];
                        //model.Publisdate = (DateTime)reader[4];
                        //model.Publisher = reader[5].ToString();
                        //model.Category_id = (int)reader[6];
                        //model.Category_name = reader[7].ToString();
                        //model.Category_description = reader[8].ToString();
                        list.Add(model);
                    }
                }
                connecion.Close();
            }
            return list;
        }
    }
}
