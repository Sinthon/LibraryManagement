using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface ICategoryRepository
    {
        void Add(CategoryModel model);
        void Edit(CategoryModel model);
        void Delete(int id);
        IEnumerable<CategoryModel> GetAll();
        IEnumerable<CategoryModel> GetByValue(string value);
    }
}
