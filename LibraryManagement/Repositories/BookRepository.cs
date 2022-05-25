using LibraryManagement.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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
            string sql = @"INSERT INTO tblbook ( bookid, booktitle, bookpage, publishdate, publisher, categoryid) VALUES(:v0, :v1, :v2, :v3, :v4, :v5 )";
            using (var connection = new OracleConnection(connectionString))
            using (var command = new OracleCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new OracleParameter("v1", model.Id));
                command.Parameters.Add(new OracleParameter("v2", model.Title));
                command.Parameters.Add(new OracleParameter("v3", model.Page));
                command.Parameters.Add(new OracleParameter("v4", model.Publisdate));
                command.Parameters.Add(new OracleParameter("v5", model.Publisher));
                command.Parameters.Add(new OracleParameter("v6", model.Category_id));
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
                command.CommandText = @"DELETE FROM tblbook WHERE bookid = :v1";
                command.Parameters.Add(new OracleParameter("v1", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Edit(BookModel model)
        {
            var sql = @"UPDATE TBLBOOK SET BOOKID = :v0, BOOKTITLE = :v1, BOOKPAGE = TO_NUMBER(:v2), publishdate = TO_DATE( :v3, 'dd-mm-yyyy'), publisher = :v4,categoryid = :v5 WHERE bookid = :v0";
            using (var connection = new OracleConnection(connectionString))
            using (var command = new OracleCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new OracleParameter("v0", model.Id));
                command.Parameters.Add(new OracleParameter("v1", model.Title));
                command.Parameters.Add(new OracleParameter("v2", model.Page));
                command.Parameters.Add(new OracleParameter("v3", model.Publisdate.ToString("dd-MM-yyyy")));
                command.Parameters.Add(new OracleParameter("v4", model.Publisher));
                command.Parameters.Add(new OracleParameter("v5", Convert.ToInt32(model.Category_id)));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public IEnumerable<BookModel> GetAll()
        {
            string sql = "SELECT * FROM VIEW_BOOK ORDER BY BOOKID DESC";
            var booklist = new List<BookModel>();
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
                        var model = new BookModel();
                        model.Id = (int)reader["BOOKID"];
                        model.Title = reader[1].ToString();
                        model.Page = (int)reader[2];
                        model.Publisdate = (DateTime)reader[3];
                        model.Publisher = reader[4].ToString();
                        model.Category_id = Convert.ToInt32(reader["CATEGORYID"]);
                        model.Category_name = reader[6].ToString();
                        model.Category_description = reader[7].ToString();
                        booklist.Add(model);
                    }
                }
                connection.Close();
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
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.CommandText = $"SELECT * FROM VIEW_BOOK WHERE BOOKID = :v1 OR BOOKTITLE LIKE '${title}' ORDER BY BOOKID DESC";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new OracleParameter("v1", id));

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new BookModel();
                        model.Id = (int)reader["BOOKID"];
                        model.Title = reader[1].ToString();
                        model.Page = (int)reader[2];
                        model.Publisdate = (DateTime)reader[3];
                        model.Publisher = reader[4].ToString();
                        model.Category_id = Convert.ToInt32(reader["CATEGORYID"]);
                        model.Category_name = reader[6].ToString();
                        model.Category_description = reader[7].ToString();
                        booklist.Add(model);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return booklist;
        }

        public IEnumerable<BookModel> GetByCategory(int category_id)
        {
            var booklist = new List<BookModel>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.CommandText = $"SELECT * FROM VIEW_BOOK WHERE CATEGORYID = :v1  ORDER BY BOOKID DESC";
                command.Parameters.Add(new OracleParameter("v1", category_id));
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new BookModel();
                        model.Id = (int)reader["BOOKID"];
                        model.Title = reader[1].ToString();
                        model.Page = (int)reader[2];
                        model.Publisdate = (DateTime)reader[3];
                        model.Publisher = reader[4].ToString();
                        model.Category_id = Convert.ToInt32(reader["CATEGORYID"]);
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
