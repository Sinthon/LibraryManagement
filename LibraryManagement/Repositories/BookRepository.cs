using LibraryManagement.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

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
            string sql = @"INSERT INTO tblbook ( bookid, booktitle, bookpage, booktype, publishdate, publisher, categoryid) VALUES(:v0, :v1, :v2, :v3, :v4, :v5, :v6 )";
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
                command.Parameters.Add(new OracleParameter("v4", model.Type));
                command.Parameters.Add(new OracleParameter("v5", model.Publisdate));
                command.Parameters.Add(new OracleParameter("v6", model.Publisher));
                command.Parameters.Add(new OracleParameter("v7", model.Category_id));
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
            var sql = @"UPDATE TBLBOOK 
                            SET BOOKTITLE= :v1, BOOKPAGE=:v2, BOOKTYPE=:v3, PUBLISHDATE=:v4, PUBLISHER=:v5, CATEGORYID=:v6 
                            WHERE BOOKID = :v0";
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
                command.Parameters.Add(new OracleParameter("v3", model.Type));
                command.Parameters.Add(new OracleParameter("v4", model.Publisdate));
                command.Parameters.Add(new OracleParameter("v5", model.Publisher));
                command.Parameters.Add(new OracleParameter("v6", Convert.ToInt32(model.Category_id)));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public IEnumerable<BookModel> GetAll()
        {
            string sql;
            if (File.Exists(@"Commands\vBook.sql"))
            {
                sql = File.ReadAllText(@"Commands\vBook.sql");
            }else
            {
                sql = "SELECT * FROM VIEW_BOOKLIST";
            }
               
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
                        model.Id = (int)reader[0];
                        model.Title = reader[1].ToString();
                        model.Page = (int)reader[2];
                        model.Type = reader[3].ToString();
                        model.Publisdate = (DateTime)reader[4];
                        model.Publisher = reader[5].ToString();
                        model.Category_id = (int)reader[6];
                        model.Category_name = reader[7].ToString();
                        model.Category_description = reader[8].ToString();
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
                command.CommandText = $"SELECT * FROM VIEW_BOOKLIST WHERE BOOKID = :v1 OR BOOKTITLE LIKE '${title}'";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new OracleParameter("v1", id));

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new BookModel();
                        model.Id = (int)reader[0];
                        model.Title = reader[1].ToString();
                        model.Page = (int)reader[2];
                        model.Type = reader[3].ToString();
                        model.Publisdate = (DateTime)reader[4];
                        model.Publisher = reader[5].ToString();
                        model.Category_id = (int)reader[6];
                        model.Category_name = reader[7].ToString();
                        model.Category_description = reader[8].ToString();
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
                command.CommandText = $"SELECT * FROM VIEW_BOOKLIST WHERE CATEGORYID = :v1";
                command.Parameters.Add(new OracleParameter("v1", category_id));
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new BookModel();
                        model.Id = (int)reader[0];
                        model.Title = reader[1].ToString();
                        model.Page = (int)reader[2];
                        model.Type = reader[3].ToString();
                        model.Publisdate = (DateTime)reader[4];
                        model.Publisher = reader[5].ToString();
                        model.Category_id = (int)reader[6];
                        model.Category_name = reader[7].ToString();
                        model.Category_description = reader[8].ToString();
                        booklist.Add(model);
                        Console.WriteLine(reader[5].ToString());
                    }
                }
                connection.Close();
            }
            return booklist;
        }
    }
}
