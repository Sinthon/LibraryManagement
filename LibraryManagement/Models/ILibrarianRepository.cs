using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface ILibrarianRepository
    {
        void Add(LibrarianModel model);
        void Edit(LibrarianModel model);
        void Delete(int id);
        IEnumerable<LibrarianModel> GetAll();
        IEnumerable<LibrarianModel> GetByValue(string value);
    }
}
