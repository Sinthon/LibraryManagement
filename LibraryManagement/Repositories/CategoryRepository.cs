using LibraryManagement.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
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
            
        }

        public void Delete(int id)
        {
            
        }

        public void Edit(CategoryModel model)
        {
            
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
                        Console.WriteLine(reader[0].ToString()+ reader[1].ToString()+ reader[2].ToString());
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
            throw new NotImplementedException();
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
