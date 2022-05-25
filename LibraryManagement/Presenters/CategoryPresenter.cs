using LibraryManagement.Models;
using LibraryManagement.Presenters.Commands;
using LibraryManagement.Views.Category;
using LibraryManagement.Views.Category.Dialog;
using LibraryManagement.Views.Main;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibraryManagement.Presenters
{
    public class CategoryPresenter
    {
        private ICategoryView _catview;
        private ICategoryRepository _repository;
        private ICategoryDialog _dialog;
        private BindingSource CategoryBindingSource;
        private IEnumerable<CategoryModel> categorylist;

        private ModelDataValidation validation;

        CategoryPresenter(ICategoryView _catview, ICategoryDialog _dialog ,ICategoryRepository _repository)
        {
            CategoryBindingSource = new BindingSource();
            validation = new ModelDataValidation();

            this._catview = _catview;
            this._repository = _repository;
            this._dialog = _dialog;

            _catview.Add += AddCategory;
            _catview.Edit += EditCategory;
            _catview.Load += ReloadList;
            _catview.Search += SearchBook;
            _catview.Delete += Delete;

            _dialog.Save += Save;
            _dialog.Cancel += Cancel;
            SetUp();
            _catview.SetBindingSource(CategoryBindingSource);
        }

        private void Delete(object sender, EventArgs e)
        {
            try
            {
                var single_record = (CategoryModel)CategoryBindingSource.Current;
                _repository.Delete(single_record.Id);

                categorylist = _repository.GetAll();
                CategoryBindingSource.DataSource = categorylist;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchBook(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_catview.sValue);
            try
            {
                if (emptyValue == false)
                    categorylist = _repository.GetByValue(_catview.sValue);
                else
                    categorylist = _repository.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CategoryBindingSource.DataSource = categorylist;
        }

        private void ReloadList(object sender, EventArgs e)
        {
            try
            {
                categorylist = _repository.GetAll();
                CategoryBindingSource.DataSource = categorylist;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditCategory(object sender, EventArgs e)
        {
            _dialog.IsEdit = true;
            _dialog.ErrorMessages = string.Empty;
            _dialog.DialogTitle = "Edit Category";

            var single_record = (CategoryModel)CategoryBindingSource.Current;
            _dialog.Id = single_record.Id;
            _dialog.Cat_Name = single_record.Name;
            _dialog.Description = single_record.Description;
            _dialog.Show(MainView.GetInstance());
        }

        private void Cancel(object sender, EventArgs e)
        {
            _dialog.Close();
        }

        private void Save(object sender, EventArgs e)
        {
            var model = new CategoryModel();
            model.Id = _dialog.Id;
            model.Name = _dialog.Cat_Name;
            model.Description = _dialog.Description;

            try
            {
                validation.Validate(model);

                if (_dialog.IsEdit)
                    _repository.Edit(model);
                else
                    _repository.Add(model);

                _dialog.Close();
                ReloadList(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _dialog.ErrorMessages = ex.Message;
            }
        }

        private void AddCategory(object sender, EventArgs e)
        {
            _dialog.IsEdit = false;
            _dialog.ErrorMessages = string.Empty;
            _dialog.DialogTitle = "Add Category";
            _dialog.Show(MainView.GetInstance());
        }

        private void SetUp()
        {
            categorylist = _repository.GetAll();
            CategoryBindingSource.DataSource = categorylist;
        }

        private static CategoryPresenter instance;
        public static CategoryPresenter GetInstance(ICategoryView _catview, ICategoryDialog _dialog, ICategoryRepository _repository)
        {
            if(instance == null)
            {
                instance = new CategoryPresenter(_catview, _dialog, _repository);
            }
            return instance;
        }
    }
}
