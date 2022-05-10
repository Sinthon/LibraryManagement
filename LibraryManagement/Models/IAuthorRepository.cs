using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IAuthorRepository
    {
        void Add(AuthorModel model);
        void Edit(AuthorModel model);
        void Delete(int id);
        IEnumerable<AuthorModel> GetAll();
        IEnumerable<AuthorModel> GetByValue(string value);
    }
}
