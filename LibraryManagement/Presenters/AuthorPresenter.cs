using LibraryManagement.Presenters.Commands;
using LibraryManagement.Views.Author;
using LibraryManagement.Views.Author.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Presenters
{
    public class AuthorPresenter
    {
        private ModelDataValidation validation;
        IAuthorView _authorview;
        IAuthorDialog _dialog;
        AuthorPresenter(IAuthorView _authorview, IAuthorDialog _dialog)
        {
            validation = new ModelDataValidation();
        }

        private static AuthorPresenter instance;
        public static AuthorPresenter GetInstance(IAuthorView _authorview, IAuthorDialog _dialog)
        {
            if(instance == null)
            {
                instance = new AuthorPresenter(_authorview, _dialog);
            }
            return instance;
        }
    }
}
