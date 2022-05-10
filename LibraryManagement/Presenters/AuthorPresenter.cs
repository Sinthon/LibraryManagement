using LibraryManagement.Models;
using LibraryManagement.Presenters.Commands;
using LibraryManagement.Views.Author;
using LibraryManagement.Views.Author.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Presenters
{
    public class AuthorPresenter
    {
        private ModelDataValidation validation;
        private IAuthorView _authorview;
        private IAuthorDialog _dialog;
        private IAuthorRepository _repository;

        BindingSource authorbindingsource;
        IEnumerable<AuthorModel> authorlist;

        AuthorPresenter(IAuthorView _authorview, IAuthorDialog _dialog, IAuthorRepository _repository)
        {
            validation = new ModelDataValidation();
            authorbindingsource = new BindingSource();

            this._authorview = _authorview;
            this._dialog = _dialog;
            this._repository = _repository;

            SetUp();
            _authorview.SetBindingSource(authorbindingsource);
        }
        private void SetUp()
        {
            var list = _repository.GetAll();
            authorbindingsource.DataSource = list;
        }

        private static AuthorPresenter instance;
        public static AuthorPresenter GetInstance(IAuthorView _authorview, IAuthorDialog _dialog, IAuthorRepository _repository)
        {
            if(instance == null)
            {
                instance = new AuthorPresenter(_authorview, _dialog, _repository);
            }
            return instance;
        }
    }
}
