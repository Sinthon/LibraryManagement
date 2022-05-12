using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface ILibraryRepository
    {
        void Add(LibraryModel model);
        void Edit(LibraryModel model);
        void Delete(int id);
        IEnumerable<LibraryModel> GetAll();
    }
}
