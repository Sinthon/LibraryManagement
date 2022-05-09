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
            _bookview.SetBookListBindingSource(booksBindingSource);

            SetUp();
        }

        private void CloseForm(object sender, EventArgs e)
        {
            //_bookview.Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            _dialog.Hide();
        }

        private void Save(object sender, EventArgs e)
        {
            var model = new BookModel();
            model.Id = _dialog.Id;
            model.Title = _dialog.Title;
            model.Page = _dialog.Page;
            model.Type = _dialog.Type;
            model.Publisdate = _dialog.PublicDate;
            model.Publisher = _dialog.Publisher;
            model.Category_id = _dialog.Categiry_Id;

            if (_dialog.IsEdit)
            {
                try
                {
                    validation.Validate(model);
                    _dialog.Hide();
                }
                catch (Exception ex)
                {
                    _dialog.ErrorMessages = ex.Message;
                }
            }
            else
            {
                try
                {
                    validation.Validate(model);
                    _dialog.Hide();
                }
                catch (Exception ex)
                {
                    _dialog.ErrorMessages = ex.Message;
                }
            }

        }

        private void ReloadList(object sender, EventArgs e)
        {
            booklist = _repository.GetAll();
            booksBindingSource.DataSource = booklist;
        }

        private void AddBook(object sender, EventArgs e)
        {
            categorylist = categoryRepository.GetAll();
            categoryBindingSource.DataSource = categorylist;

            _dialog.CategoriessBindingSource(categoryBindingSource);
            _dialog.IsEdit = false;
            _dialog.DialogTitle = "Add book";
            _dialog.Show(MainView.GetInstance());
        }

        private void SetUp()
        {
            booklist = _repository.GetAll();
            booksBindingSource.DataSource = booklist;
        }

        private void DeleteBook(object sender, EventArgs e)
        {
            
        }

        private void EditBook(object sender, EventArgs e)
        {
            _dialog.DialogTitle = "Edit book";
            _dialog.IsEdit = true;
        }

        private void SearchBook(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_bookview.sValue);
            if (emptyValue == false)
            {
                booklist = _repository.GetByValue(_bookview.sValue);
            }
            else
            {
                booklist = _repository.GetAll();
                booksBindingSource.DataSource = booklist;
            }
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
