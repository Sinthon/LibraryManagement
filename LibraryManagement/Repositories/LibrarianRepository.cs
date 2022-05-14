using LibraryManagement.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    class LibrarianRepository : BaseRepository,ILibrarianRepository
    {
        public LibrarianRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(LibrarianModel model)
        {
            
        }

        public void Delete(int id)
        {
            
        }

        public void Edit(LibrarianModel model)
        {
            
        }

        public IEnumerable<LibrarianModel> GetAll()
        {
            var list = new List<LibrarianModel>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM TBLLIBRARIAN";
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new LibrarianModel();
                        model.Id = Convert.ToInt32(reader[0]);
                        model.Name = reader[1].ToString();
                        model.Gender = reader[2].ToString();
                        model.Dob = (DateTime)reader[3];
                        model.Address = reader[4].ToString();
                        model.Phone = reader[5].ToString();
                        list.Add(model);
                    }
                }
                connection.Close();
            }
            return list;
        }

        public IEnumerable<LibrarianModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }
    }
}
