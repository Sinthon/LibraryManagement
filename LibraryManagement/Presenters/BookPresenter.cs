using LibraryManagement.Models;
using LibraryManagement.Presenters.Commands;
using LibraryManagement.Repositories;
using LibraryManagement.Views.Books;
using LibraryManagement.Views.Books.Dialog;
using LibraryManagement.Views.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Presenters
{
    public class BookPresenter
    {
        private ModelDataValidation validation;
        
        private IBookView _bookview;
        private IBookDailog _dialog;
        private IBookRepository _repository;

        ICategoryRepository categoryRepository;

        private BindingSource booksBindingSource;
        private IEnumerable<BookModel> booklist;

        private BindingSource categoryBindingSource;
        private IEnumerable<CategoryModel> categorylist;

        BookPresenter(IBookView _bookview, IBookDailog _dialog, IBookRepository _repository, ICategoryRepository categoryRepository)
        {
            booksBindingSource = new BindingSource();
            categoryBindingSource = new BindingSource();
            validation = new ModelDataValidation();

            this.categoryRepository = categoryRepository;
            this._bookview = _bookview;
            this._dialog = _dialog;
            this._repository = _repository;

            _bookview.Search += SearchBook;
            _bookview.Add += AddBook;
            _bookview.Edit += EditBook;
            _bookview.Delete += DeleteBook;
            _bookview.Load += ReloadList;
            _bookview.CloseForm += CloseForm;
            _dialog.Save += Save;
            _dialog.Cancel += Cancel;
            
            SetUp();
            _bookview.SetBookListBindingSource(booksBindingSource);
            _bookview.CategoryBindingSource(categoryBindingSource);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            //_bookview.Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            _dialog.Close();
        }

        private void Save(object sender, EventArgs e)
        {
            var model = new BookModel();
            model.Id = _dialog.Id;
            model.Title = _dialog.Title;
            model.Page = _dialog.Page;
            model.Publisdate = _dialog.PublicDate;
            model.Publisher = _dialog.Publisher;
            model.Category_id = _dialog.Categiry_Id;

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
                _dialog.ErrorMessages = ex.Message;
            }
        }

        private void ReloadList(object sender, EventArgs e)
        {
            try
            {
                if (_bookview.category_id == 0)
                    booklist = _repository.GetAll();
                else
                    booklist = _repository.GetByCategory(_bookview.category_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            booksBindingSource.DataSource = booklist;
        }

        private void AddBook(object sender, EventArgs e)
        {
            _dialog.IsEdit = false;
            _dialog.ErrorMessages = string.Empty;
            _dialog.Categiry_Id = 1; //set default selected category
            _dialog.DialogTitle = "Add book"; // change title dialog
            _dialog.Show(MainView.GetInstance());
        }

        private void SetUp()
        {
            booklist = _repository.GetAll();
            booksBindingSource.DataSource = booklist;

            categorylist = categoryRepository.GetAll();
            categoryBindingSource.DataSource = categorylist;

            _dialog.CategoriessBindingSource(categoryBindingSource);
        }

        private void DeleteBook(object sender, EventArgs e)
        {
            try
            {
                var single_record = (BookModel)booksBindingSource.Current;
                _repository.Delete(single_record.Id);

                booklist = _repository.GetAll();
                booksBindingSource.DataSource = booklist;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void EditBook(object sender, EventArgs e)
        {
            _dialog.DialogTitle = "Edit book";
            _dialog.IsEdit = true;
            _dialog.ErrorMessages = string.Empty;

            var single_record = (BookModel)booksBindingSource.Current;
            _dialog.Id = single_record.Id;
            _dialog.Title = single_record.Title;
            _dialog.Page = single_record.Page;
            _dialog.PublicDate = (DateTime)single_record.Publisdate;
            _dialog.Publisher = single_record.Publisher;
            _dialog.Categiry_Id = single_record.Category_id;
            _dialog.Show(MainView.GetInstance());
        }

        private void SearchBook(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_bookview.sValue);
            try
            {
                if (emptyValue == false)
                    booklist = _repository.GetByValue(_bookview.sValue);
                else
                    booklist = _repository.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            booksBindingSource.DataSource = booklist;
        }

        private static BookPresenter instance;
        public static BookPresenter GetInstance(IBookView _bookview, IBookDailog _dialog, IBookRepository _repository, ICategoryRepository categoryRepository)
        {
            if(instance== null)
            {
                instance = new BookPresenter(_bookview, _dialog, _repository,categoryRepository);
            }
            return instance;
        }
    }
}
