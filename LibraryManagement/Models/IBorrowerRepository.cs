using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IBorrowerRepository
    {
        void Add(BorrowerModel model);
        void Edit(BorrowerModel model);
        void Delete(int id);
        IEnumerable<BorrowerModel> GetAll();
        IEnumerable<BorrowerModel> GetByValue(string value);
    }
}
