using LibraryManagement.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        AuthorRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private static AuthorRepository instance;
        public static AuthorRepository GetInstance(string connectionString)
        {
            if (instance == null)
                instance = new AuthorRepository(connectionString);
            return instance;
        }

        public void Add(AuthorModel model)
        {
            
        }

        public void Edit(AuthorModel model)
        {
            
        }

        public void Delete(int id)
        {
            
        }

        public IEnumerable<AuthorModel> GetAll()
        {
            string sql = "SELECT * FROM TBLAUTHOR";
            var list = new List<AuthorModel>();
            using (OracleConnection connecion = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand())
            {
                connecion.Open();
                command.Connection = connecion;
                command.CommandText = sql;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new AuthorModel();
                        model.Id = Convert.ToInt32(reader[0]);
                        model.Name = reader[1].ToString();
                        model.Nation = reader[2].ToString();
                        model.Skill = reader[3].ToString();
                        list.Add(model);
                        Console.WriteLine(reader[0].ToString());
                    }
                }
                connecion.Close();
            }
            return list;
        }

        public IEnumerable<AuthorModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }
    }
}
