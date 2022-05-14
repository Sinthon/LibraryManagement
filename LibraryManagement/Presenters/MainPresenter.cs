using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.Views.Login;
using LibraryManagement.Views.Main;
using LibraryManagement.Views.Layout;
using LibraryManagement.Views.Books;
using LibraryManagement.Views.Books.Dialog;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.Views.Dashboard;
using LibraryManagement.Views.Category;
using LibraryManagement.Views.Author;
using LibraryManagement.Views.Author.Dialog;
using LibraryManagement.Views.Librarian;

namespace LibraryManagement.Presenters
{
    class MainPresenter
    {
        private readonly string connectionString;
        private IMainView _mainview;
        private ISideBarMenu _sideBar;
        private IDashboardView _dashboard;

        public IBookDailog BookDialog { get; private set; }

        public MainPresenter(IMainView mainview, ISideBarMenu sideBar,string connectionString)
        {
            _mainview = mainview;
            _sideBar = sideBar;
            this.connectionString = connectionString;
            _mainview.SetUp += SetUp;
            _sideBar.ShowDahsBoard += ShowDashboard;
            _sideBar.ShowBooks += ShowBook;
            _sideBar.ShowAuthor += ShowAuthor;
            _sideBar.ShowCategory += ShowCategory;
            _sideBar.ShowLibrarian += ShowLibrarian;
        }

        private void ShowLibrarian(object sender, EventArgs e)
        {
            ILibrarianView librarianview = LibrarianView.GetInstace((Form)_mainview);
            ILibrarianRepository repository = new LibrarianRepository(connectionString);

            LibrarianPrecenter.GetInstance(librarianview, repository);
            librarianview.Show();
        }

        private void SetUp(object sender, EventArgs e)
        {
            ILoginView loginview = LoginView.GetInstance();
            IAuthRepository repository = new AuthRepository(connectionString);

            LoginPresenter.GetInstance(loginview, repository);
            (loginview as Form).ShowDialog((Form)_mainview);

            if (loginview.LoginSuccess)
            {
                _mainview.IitialComponent();

                SubScriptEvent();
            }
        }

        private void SubScriptEvent()
        {
            _dashboard = DashboardView.GetInstace((Form)_mainview);
            _dashboard.Show();

            _dashboard.ShowBooks += ShowBook;
            _dashboard.ShowAuthor += ShowAuthor;
        }


        private void ShowAuthor(object sender, EventArgs e)
        {
            IAuthorView authorview = AuthorView.GetInstace((Form)_mainview);
            IAuthorRepository authorRepository = AuthorRepository.GetInstance(connectionString);
            IAuthorDialog authordialog = AuthorDialog.GetInstance();

            AuthorPresenter.GetInstance(authorview, authordialog, authorRepository);
            authorview.Show();
        }

        private void ShowBook(object sender, EventArgs e)
        {
            IBookView bookview = BookView.GetInstace((Form)_mainview);
            IBookDailog dailog = BookDialogView.GetInstance();

            ICategoryRepository categoryRepository = CategoryRepository.GetInstance(connectionString);
            IBookRepository repository = new BookRepository(connectionString);

            BookPresenter.GetInstance(bookview,dailog,repository, categoryRepository);
            bookview.Show();
        }

        private void ShowDashboard(object sender, EventArgs e)
        {
            _dashboard = DashboardView.GetInstace((Form)_mainview);
            _dashboard.Show();
        }

        private void ShowCategory(object sender, EventArgs e)
        {
            ICategoryView catview = CategoryView.GetInstace((Form)_mainview);
            ICategoryRepository categoryRepository = CategoryRepository.GetInstance(connectionString);

            CategoryPresenter.GetInstance(categoryRepository, catview);
            catview.Show();
        }
    }
}
