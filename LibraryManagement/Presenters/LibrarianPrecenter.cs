using LibraryManagement.Models;
using LibraryManagement.Views.Librarian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Presenters
{
    class LibrarianPrecenter
    {
        private ILibrarianView _librarianview;
        private ILibrarianRepository _repository;

        private BindingSource BindingSource;
        private IEnumerable<LibrarianModel> list;

        LibrarianPrecenter(ILibrarianView _librarianview, ILibrarianRepository _repository)
        {
            BindingSource = new BindingSource();

            this._librarianview = _librarianview;
            this._repository = _repository;

            SetUp();
            _librarianview.SetBindingSource(BindingSource);
        }

        private void SetUp()
        {
            list = _repository.GetAll();
            BindingSource.DataSource = list;
        }

        private static LibrarianPrecenter instance;
        public static LibrarianPrecenter GetInstance(ILibrarianView _librarianview, ILibrarianRepository _repository)
        {
            if (instance == null)
                instance = new LibrarianPrecenter(_librarianview, _repository);
            return instance;
        }
    }
}
