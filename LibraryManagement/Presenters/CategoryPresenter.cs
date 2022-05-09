using LibraryManagement.Models;
using LibraryManagement.Views.Category;
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
        private ICategoryView _catview;
        private ICategoryRepository _repository;

        private BindingSource CategoryBindingSource;
        private IEnumerable<CategoryModel> categorylist;

        CategoryPresenter(ICategoryRepository _repository, ICategoryView _catview)
        {
            CategoryBindingSource = new BindingSource();

            this._catview = _catview;
            this._repository = _repository;
               
            SetUp();
            _catview.SetBindingSource(CategoryBindingSource);
        }

        private void SetUp()
        {
            categorylist = _repository.GetAll();
            CategoryBindingSource.DataSource = categorylist;
        }

        private static CategoryPresenter instance;
        public static CategoryPresenter GetInstance(ICategoryRepository _repository, ICategoryView _catview)
        {
            if(instance == null)
            {
                instance = new CategoryPresenter(_repository, _catview);
            }
            return instance;
        }
    }
}
