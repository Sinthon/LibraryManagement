using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Presenters
{
    public class CategoryPresenter
    {
        ICategoryRepository _repository;
        private BindingSource CategoryBindingSource;
        private IEnumerable<CategoryModel> categorylist;

        CategoryPresenter(ICategoryRepository _repository)
        {
            CategoryBindingSource = new BindingSource();
            this._repository = _repository;
            SetUp();
        }

        private void SetUp()
        {
            categorylist = _repository.GetAll();
            CategoryBindingSource.DataSource = categorylist;
        }

        private static CategoryPresenter instance;
        public static CategoryPresenter GetInstance(ICategoryRepository _repository)
        {
            if(instance == null)
            {
                instance = new CategoryPresenter(_repository);
            }
            return instance;
        }
    }
}
