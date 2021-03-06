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
    public class BookRepository : BaseRepository, IBookRepository
    {

        public BookRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(BookModel model)
        {
            using (var connection = new OracleConnection(connectionString))
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO TBLBOOK(BOOKID,BOOKTITLE, BOOKPAGE, BOOKTYPE, PUBLISHDATE, PUBLISHER, CATEGORYID) VALUES(:1, :2, :3, :4, :5, :6, :7);";
                command.Parameters.Add(new OracleParameter("1", model.Id));
                command.Parameters.Add(new OracleParameter("2", model.Title));
                command.Parameters.Add(new OracleParameter("3", model.Page));
                command.Parameters.Add(new OracleParameter("4", model.Type));
                command.Parameters.Add(new OracleParameter("5", model.Publisdate));
                command.Parameters.Add(new OracleParameter("6", model.Publisher));
                command.Parameters.Add(new OracleParameter("7", model.Category_id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new OracleConnection(connectionString))
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM TBLBOOK  WHERE BOOKID= :1";
                command.Parameters.Add(new OracleParameter("1", OracleDbType.Int32)).Value = id;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Edit(BookModel model)
        {
            
        }

        public IEnumerable<BookModel> GetAll()
        {
            string sql;
            if (File.Exists(@"Commands\vBook.sql"))
            {
                sql = File.ReadAllText(@"Commands\vBook.sql");
            }else
            {
                sql = "SELECT * FROM vBook";
            }
               
            var booklist = new List<BookModel>();
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
                        var model = new BookModel();
                        model.Id = (int)reader[0];
                        model.Title = reader[1].ToString();
                        model.Page = (int)reader[2];
                        //model.Publisdate = (DateTime)reader[3];
                        model.Publisher = reader[4].ToString();
                        //model.Category_id = (int)reader[5];
                        model.Category_name = reader[6].ToString();
                        model.Category_description = reader[7].ToString();
                        booklist.Add(model);
                    }
                }
                connecion.Close();
            }
            return booklist;
        }

        public IEnumerable<BookModel> GetByValue(string value)
        {
            var booklist = new List<BookModel>();
            int id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string title = value;

            using (var connection = new OracleConnection(connectionString))
            using (var command = new OracleCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM TBLBOOK WHERE BOOKID=:ID OR BOOKTITLE LIKE :TITLE +'%'";

                command.Parameters.Add(new OracleParameter(":ID", OracleDbType.Int32)).Value = id;
                command.Parameters.Add(new OracleParameter(":TITLE", OracleDbType.NVarchar2)).Value = title;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new BookModel();
                        model.Id = (int)reader[0];
                        model.Title = reader[1].ToString();
                        model.Page = (int)reader[2];
                        //model.Publisdate = (DateTime)reader[3];
                        model.Publisher = reader[4].ToString();
                        //model.Category_id = (int)reader[5];
                        model.Category_name = reader[6].ToString();
                        model.Category_description = reader[7].ToString();
                        booklist.Add(model);
                    }
                }
                connection.Close();
            }
            return booklist;
        }
    }
}
