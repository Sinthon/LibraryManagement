using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IBookRepository
    {
        void Add(BookModel model);
        void Edit(BookModel model);
        void Delete(int id);
        IEnumerable<BookModel> GetAll();
        IEnumerable<BookModel> GetByValue(string value);
        IEnumerable<BookModel> GetByCategory(int value);
    }
}
