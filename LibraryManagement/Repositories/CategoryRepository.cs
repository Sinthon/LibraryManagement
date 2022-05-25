using LibraryManagement.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(CategoryModel model)
        {
            string sql = "INSERT INTO TBLCATEGORY VALUES(:v1, :v2, :v3)";

            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new OracleParameter("v1", model.Id));
                command.Parameters.Add(new OracleParameter("v2", model.Name));
                command.Parameters.Add(new OracleParameter("v3", model.Description));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new OracleConnection(connectionString))
            using (var command = new OracleCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.CommandText = @"DELETE FROM TBLCATEGORY WHERE CATEGORYID = :v1";
                command.Parameters.Add(new OracleParameter("v1", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Edit(CategoryModel model)
        {
            string sql = "UPDATE TBLCATEGORY SET CATEGORYID = TO_NUMBER(:v0), CATEGORYNAME= :v1, CAT_DESC= :v2 WHERE CATEGORYID = TO_NUMBER(:v0)";
            using (var connection = new OracleConnection(connectionString))
            using (var command = new OracleCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.CommandText = sql;
                command.Parameters.Add(new OracleParameter("v0", model.Id));
                command.Parameters.Add(new OracleParameter("v1", model.Name));
                command.Parameters.Add(new OracleParameter("v2", model.Description));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            string sql = "SELECT * FROM TBLCATEGORY";
            var categoryList = new List<CategoryModel>();
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
                        //Console.WriteLine(reader[0].ToString()+ reader[1].ToString()+ reader[2].ToString());
                        var model = new CategoryModel();
                        model.Id = Convert.ToInt32(reader[0]);
                        model.Name = reader[1].ToString();
                        model.Description = reader[2].ToString();
                        categoryList.Add(model);
                    }
                }
                connecion.Close();
            }
            return categoryList;
        }

        
        public IEnumerable<CategoryModel> GetByValue(string value)
        {
            var list = new List<CategoryModel>();
            int id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string name = value;

            using (var connection = new OracleConnection(connectionString))
            using (var command = new OracleCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.CommandText = $"SELECT * FROM TBLCATEGORY WHERE CATEGORYID = :v1 OR CATEGORYNAME LIKE '${name}%'";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new OracleParameter("v1", id));

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new CategoryModel();
                        model.Id = Convert.ToInt32(reader[0]);
                        model.Name = reader[1].ToString();
                        model.Description = reader[2].ToString();
                        list.Add(model);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return list;
        }


        private static CategoryRepository instance;
        public  static CategoryRepository GetInstance(string connectionString)
        {
            if(instance == null)
            {
                instance = new CategoryRepository(connectionString);
            }
            return instance;
        }
    }
}
